using Microsoft.AspNetCore.Mvc;
using HorrorMovieAPI.Services;

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
    }
}