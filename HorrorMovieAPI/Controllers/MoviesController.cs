using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace HorrorMovieAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieRepository _repository;
        private readonly IMapper _mapper;

        public MoviesController(MovieRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<MovieDTO[]>> GetAll(bool includeActors = false, bool includeDirector = false)
        {
            var result = await _repository.GetAll(includeActors,includeDirector);
            var mappedResults = _mapper.Map<MovieDTO[]>(result);
            return Ok (mappedResults);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetById(int id, bool includeActors = false, bool includeDirector = false)
        {
            var result = await _repository.GetById(id, includeActors, includeDirector);
            var mappedResult = _mapper.Map<MovieDTO>(result);
            return Ok(mappedResult);
        }
    }
}