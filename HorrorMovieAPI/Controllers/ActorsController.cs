using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;

namespace HorrorMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ActorRepository _repository;
        private readonly IMapper _mapper;
        public ActorsController(ActorRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ActorDTO[]>> GetAll(string firstName = "", bool includeMovies = false)
        {
            var results = await _repository.GetAll(firstName, includeMovies);
            var mappedResults = _mapper.Map<ActorDTO[]>(results);
            return Ok(mappedResults);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDTO>> GetById(int id, bool includeMovies = false)
        {
            var result = await _repository.GetById(id, includeMovies);
            var mappedResult = _mapper.Map<ActorDTO>(result);
            return Ok(mappedResult);
        }
    }
}