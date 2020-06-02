using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using HorrorMovieAPI.Dto;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;

namespace HorrorMovieAPI.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorRepository _repository;
        private readonly IUrlHelper _urlHelper;
        private readonly IMapper _mapper;

        public ActorsController(IUrlHelper urlHelper, IActorRepository repository, IMapper mapper)
        {
            _urlHelper = urlHelper;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all actors, possible to filter on first name and include movies
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="includeMovies"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ActorDTO[]>> GetAll(string firstName = "", bool includeMovies = false)
        {
            try
            {
                var results = await _repository.GetAll(firstName, includeMovies);
                var toReturn = results.Select(x => ExpandSingleItem(x));
                return Ok(toReturn);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to retrieve actors. Exception thrown when attempting to retrieve data from the database: {e.Message}");
            }
        }

        /// <summary>
        /// Get actor by Id, possible to filter on movies
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeMovies"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetActorById")]
        public async Task<ActionResult<ActorDTO>> GetActorById(int id, bool includeMovies = false)
        {
            try
            {
                var result = await _repository.GetById(id, includeMovies);
                return Ok(ExpandSingleItem(result));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to retrieve the actor with id {id}. Exception thrown when attempting to retrieve data from the database: {e.Message}");
            }
        }

        /// <summary>
        /// Delete actor by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteActorById")]
        public async Task<IActionResult> DeleteActorById(int id)
        {
            try
            {
                var actor = await _repository.GetById(id, false);

                if (actor == null)
                {
                    return NotFound($"Could not delete actor. Actor with Id {id} was not found.");
                }
                await _repository.Delete(actor);

                return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to delete the actor. Exception thrown when attempting to delete data from the database: {e.Message}");
            }
        }

        /// <summary>
        /// Update actor by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="actorForUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}", Name = "UpdateActorDetails")]
        public async Task<IActionResult> UpdateActorDetails(int id, [FromBody] ActorForUpdateDTO actorForUpdateDto)
        {
            try
            {
                var actorFromRepo = await _repository.GetById(id, false);

                if (actorFromRepo == null)
                {
                    return NotFound($"Could not update actor. Actor with Id {id} was not found.");
                }
                var actorForUpdate = _mapper.Map(actorForUpdateDto, actorFromRepo);

                await _repository.Update(actorForUpdate);

                return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to update the actor. Exception thrown when attempting to update data in the database: {e.Message}");
            }
        }

        /// <summary>
        /// Create actor
        /// </summary>
        /// <param name="actorDTO"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateActor")]
        public async Task<IActionResult> CreateActor([FromBody] ActorDTO actorDTO)
        {
            try
            {
                var actor = _mapper.Map<Actor>(actorDTO);

                var actorFromRepo = await _repository.Add(actor);
                if (actorFromRepo != null)
                {
                    return CreatedAtAction(nameof(GetActorById), new { id = actor.Id }, actor);
                }
                return BadRequest("Failed to create actor.");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to create the actor. Exception thrown when attempting to add data to the database: {e.Message}");
            }
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

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(DeleteActorById), new { id = actor.Id }),
              "delete",
              "DELETE"));

            links.Add(
               new LinkDto(_urlHelper.Link(nameof(UpdateActorDetails), new { id = actor.Id }),
               "update",
               "PUT"));

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(CreateActor), null),
              "create",
              "POST"));

            return links;
        }
    }
}