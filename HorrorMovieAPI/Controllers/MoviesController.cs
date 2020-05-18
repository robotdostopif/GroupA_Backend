using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieRepository _repository;

        public MoviesController(MovieRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Movie[]>> GetAll(bool includeActors = false, bool includeDirector = false)
        {
            var result = await _repository.GetAll(includeActors,includeDirector);
            return Ok (result);
        }
    }
}