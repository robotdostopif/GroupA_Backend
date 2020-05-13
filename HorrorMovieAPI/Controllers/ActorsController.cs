using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace HorrorMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ActorRepository _repository;
        public ActorsController(ActorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Actor>>> GetAll(string roleName, string town, string country, bool includeMovies )
        {
            return await _repository.GetAll(roleName, town, country, includeMovies);
        }
    }
}