using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace HorrorMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ActorsController : ControllerCRUD<Actor, ActorRepository>
    {
        private readonly ActorRepository _repository;
        public ActorsController(ActorRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Actor>>> GetAll(string firstName,bool includeMovies)
        {
            return await _repository.GetAll(firstName, includeMovies);
        }
    }
}