using AutoMapper;
using HorrorMovieAPI.Dto;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly DirectorRepository _repository;
        private readonly IMapper _mapper;
        public DirectorsController(DirectorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<DirectorDTO[]>> GetAll(string birthCountry = "", bool includeMovies = false)
        {
            try
            {
                var results = await _repository.GetAll(birthCountry, includeMovies);
                var mappedResults = _mapper.Map<DirectorDTO[]>(results);
                return Ok(mappedResults);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to retrieve directors. Exception thrown: {e.Message} ");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDTO>> GetDirectorById(int id, bool includeMovies = false)
        {
            try
            {
                var result = await _repository.GetDirectorById(id, includeMovies);
                var mappedResult = _mapper.Map<DirectorDTO>(result);
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to retrieve director with id {id}. Exception thrown: {e.Message} ");
            }
            
        }

        [HttpDelete("{id}", Name ="DeleteDirector")]
        public async Task<IActionResult> DeleteDirector(int id)
        {
            try
            {
                var director = await _repository.GetDirectorById(id);
                if (director == null)
                {
                    return BadRequest($"Could not delete director. Director with Id {id} was not found.");
                }
                await _repository.Delete(director);
                return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to delete the director. Exception thrown when attempting to delete data from the database: {e.Message}");
            }

        }

        [HttpPut("{id}", Name = "UpdateDirector")]
        public async Task<IActionResult> UpdateDirectorDetails(int id, [FromBody] DirectorForUpdateDTO directorForUpdateDto)
        {
            try
            {
                var directorFromRepo = await _repository.GetDirectorById(id);

                if (directorFromRepo == null)
                {
                    return BadRequest($"Could not update director. Director with Id {id} was not found.");
                }
                _mapper.Map(directorForUpdateDto, directorFromRepo);

                await _repository.Update(directorFromRepo);

                return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to update the director. Exception thrown when attempting to update data in the database: {e.Message}");
            }
        }

        [HttpPost(Name = "CreateDirector")]
        public async Task<IActionResult> CreateDirector([FromBody] DirectorForUpdateDTO directorDto)
        {
            try
            {
                var director = _mapper.Map<Director>(directorDto);

                await _repository.Add(director);

                if (await _repository.Save())
                {
                    return CreatedAtAction(nameof(GetDirectorById), new { id = director.Id }, director);
                }
                return BadRequest("Failed to create director.");

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to update the director. Exception thrown when attempting to update data in the database: {e.Message}");
            }
        }
    }
}