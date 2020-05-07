using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HorrorMovieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
         private readonly GenreRepository _repository;
        public GenresController(GenreRepository repository)
        {
            _repository = repository;
        }
    }
}