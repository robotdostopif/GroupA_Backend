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
        public async Task<ActionResult<IEnumerable<GenreDTO[]>>> GetAll(bool includeMovies = false, bool includeActors = false)
        {
            var results = await _repository.GetAll(includeMovies, includeActors);
            var mappedResults = _mapper.Map<GenreDTO>(results);
            return Ok(mappedResults);
        }
    }
}