using System.Collections.Generic;
using System.Threading.Tasks;
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
        public GenresController(GenreRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetAll(bool includeMovies = false, bool includeActors = false)
        {
            return await _repository.GetAll(includeMovies, includeActors);
        }
    }
}