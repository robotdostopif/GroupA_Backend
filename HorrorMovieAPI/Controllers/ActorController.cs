using Microsoft.AspNetCore.Mvc;
using HorrorMovieAPI.Services;

namespace HorrorMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly ActorRepository _repository;
        public ActorController(ActorRepository repository)
        {
            _repository = repository;
        }
    }
}