using HorrorMovieAPI.Services;

namespace HorrorMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class FakeController : ControllerBase
    {
        private readonly FakeRepository _repository;
        public FakeController(FakeRepository repository)
        {
            _repository = repository;
        }

        // api/v1.0/Fake
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fake>>> Get()
        {
            return await _repository.GetAll();
        }

        // api/v1.0/Fake/<id>
        [HttpGet("{id}")]
        public async Task<ActionResult<Fake>> Get(int id)
        {
            throw new NotImplementedException();
        }

    }
}