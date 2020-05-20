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
    }
}