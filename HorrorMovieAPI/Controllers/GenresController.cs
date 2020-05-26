using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
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
            var results = await _repository.GetAll(includeMovies);
            var mappedResults = _mapper.Map<GenreDTO[]>(results);
            return Ok(mappedResults);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> GetById(int id, bool includeMovies = false)
        {
            var results = await _repository.GetById(id, includeMovies);
            var mappedResults = _mapper.Map<GenreDTO>(results);
            return Ok(mappedResults);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _repository.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }
            await _repository.Update(genre);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Genre genre)
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
    }
}