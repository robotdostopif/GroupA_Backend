using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}