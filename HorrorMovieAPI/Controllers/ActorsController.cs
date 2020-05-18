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
    public class ActorsController : ControllerCRUD<Actor, ActorRepository>
    {
        private readonly ActorRepository _repository;
        private readonly IMapper _mapper;
        public ActorsController(ActorRepository repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Actor>>> GetAll(string firstName = "", bool includeMovies = false)
        {
            var results = await _repository.GetAll(firstName, includeMovies);
            var mappedResults = _mapper.Map<ActorDTO[]>(results);
            return Ok(mappedResults);
        }
    }
}