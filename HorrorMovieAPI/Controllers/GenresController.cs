using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HorrorMovieAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly GenreRepository _repository;
        private readonly IMapper _mapper;

        public GenresController(GenreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<GenreDTO[]>> GetAll(bool includeMovies = false)
        {
            try
            {
                var results = await _repository.GetAll(includeMovies);
                var mappedResults = _mapper.Map<GenreDTO[]>(results);
                if (results.Count == 0)
                {
                    return NotFound(results);
                }
                else
                {

                    return Ok(mappedResults);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> GetById(int id, bool includeMovies = false)
        {
            try
            {
                var result = await _repository.GetById(id, includeMovies);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {

                    var mappedResults = _mapper.Map<GenreDTO>(result);
                    return Ok(mappedResults);
                }

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var entity = await _repository.Delete(id);
                if (entity == null)
                {
                    return NotFound();
                }
                return Ok();

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Genre genre)
        {
            try
            {
                if (id != genre.Id)
                {
                    return NotFound();
                }
                await _repository.Update(genre);
                return Ok();

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post(Genre genre)
        {
            try
            {
                await _repository.Add(genre);
                if (await _repository.Save())
                {
                    return Created("", genre);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }

        }
    }
}