using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using HorrorMovieAPI.Dto;
using System.Linq;

namespace HorrorMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ActorRepository _repository;
        private readonly IUrlHelper _urlHelper;
        private readonly IMapper _mapper;
        public ActorsController(IUrlHelper urlHelper, ActorRepository repository, IMapper mapper) 
        {
            _urlHelper = urlHelper;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ActorDTO[]>> GetAll(string firstName = "", bool includeMovies = false)
        {
            var results = await _repository.GetAll(firstName, includeMovies);
            var toReturn = results.Select(x => ExpandSingleItem(x));
            return Ok(toReturn);
        }

        [HttpGet("{id}", Name = "GetActorById")]
        public async Task<ActionResult<ActorDTO>> GetActorById(int id, bool includeMovies = false)
        {
            var result = await _repository.GetById(id, includeMovies);
            return Ok(ExpandSingleItem(result));
        }

        private dynamic ExpandSingleItem(Actor actor)
        {
            var links = GetLinks(actor);
            ActorDTO actorDto = _mapper.Map<ActorDTO>(actor);

            var resourceToReturn = actorDto.ToDynamic() as IDictionary<string, object>;
            resourceToReturn.Add("links", links);

            return resourceToReturn;
        }

        private IEnumerable<LinkDto> GetLinks(Actor actor)
        {
            var links = new List<LinkDto>();

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(GetActorById), new { id = actor.Id }),
              "self",
              "GET"));

            // links.Add(
            //   new LinkDto(_urlHelper.Link(nameof(DeletePostById), new { id = post.Id }),
            //   "delete",
            //   "DELETE"));

            // links.Add(
            //    new LinkDto(_urlHelper.Link(nameof(UpdatePostText), new { id = post.Id }),
            //    "update",
            //    "PUT"));

            // links.Add(
            //   new LinkDto(_urlHelper.Link(nameof(CreatePost), null),
            //   "create",
            //   "POST"));
              
            return links;
        }
    }
}