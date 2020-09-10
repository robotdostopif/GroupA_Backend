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
using Microsoft.AspNetCore.Authorization;
using PagedList.Core;

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
        /// Get all actors from the database.
        /// </summary>
        /// <param name="page">Page refers to which pagenumber will be displayed.</param>
        /// <param name="pagesize">Pagesize refers to objects per page.</param>
        /// <param name="firstName">Filter actors by firstname.</param>
        /// <param name="including">Dynamic inclusions which determine what foreign entities should be included in results.</param>
        /// <returns>A list of Actors that may or may not have been filtered by the user.</returns>
        [HttpGet(Name = "GetAllActors")]
        public async Task<ActionResult<ActorDTO[]>> GetAllActors(int? page, int pagesize = 3, [FromQuery]string firstName = "", [FromQuery]string[] including = null)
        {
            try
            {
                var results = await _repository.GetAll(firstName, page, pagesize < 50? pagesize : 50, including);
                var links = CreateLinksForCollection(results);
                var toReturn = results.Select(x => ExpandSingleItem(x));
                return Ok(new
                {
                    value = toReturn,
                    links = links
                });
            }
            catch (Exception e)
            {
                var result = new { Status = StatusCodes.Status500InternalServerError, Data = $"Failed to retrieve actors. Exception thrown when attempting to retrieve data from the database: {e.Message}"};
                return this.StatusCode(StatusCodes.Status500InternalServerError,result);
                    
            }
        }

        /// <summary>
        /// Get an actor by its Id.
        /// </summary>
        /// <param name="id">Actor primary key Id which needs to be valid.</param>
        /// <param name="including">Properties which will be included.</param>
        /// <returns>An Actor object which matched given Id.</returns>
        [HttpGet("{id}", Name = "GetActorById")]
        public async Task<ActionResult<ActorDTO>> GetActorById(int id, [FromQuery]string[] including = null)
        {
            try
            {
                var result = await _repository.Get<Actor>(id, including);
                return Ok(ExpandSingleItem(result));
            }
            catch (Exception e)
            {
                var result = new { Status = StatusCodes.Status500InternalServerError, Data = $"Failed to retrieve the actor with id {id}. Exception thrown when attempting to retrieve data from the database: {e.Message}"};
                return this.StatusCode(StatusCodes.Status500InternalServerError,result);             
            }
            
        }

        /// <summary>
        /// Create an actor by using its Id and ActorForUpdateDTO containing its data.
        /// </summary>
        /// <param name="actorDTO">DTO of an Actor object which contains its data (refer to schema-documentation for more information).</param>
        /// <returns>Returns status code 201 (Created) if the Actor was successfully created.</returns>
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
                var result = new { Status = StatusCodes.Status500InternalServerError, Data = $"Failed to create the actor. Exception thrown when attempting to add data to the database: {e.Message}"};
                return this.StatusCode(StatusCodes.Status500InternalServerError,result);
                    
            }
        }

        /// <summary>
        /// Update an actor by using its Id and ActorForUpdateDTO containing its updated data.
        /// </summary>
        /// <param name="id">Actor primary key Id which needs to be valid.</param>
        /// <param name="actorForUpdateDto">DTO of an Actor object which contains its data (refer to schema-documentation for more information).</param>
        /// <returns>Returns status code 204 (NoContent) if the Actor was successfully updated.</returns>
        [HttpPut("{id}", Name = "UpdateActorDetails")]
        public async Task<IActionResult> UpdateActorDetails(int id, [FromBody] ActorForUpdateDTO actorForUpdateDto)
        {
            try
            {
                var actorFromRepo = await _repository.Get<Actor>(id);

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
                var result = new { Status = StatusCodes.Status500InternalServerError, Data = $"Failed to update the actor. Exception thrown when attempting to update data in the database: {e.Message}"};
                return this.StatusCode(StatusCodes.Status500InternalServerError,result);
                    
            }
        }

        /// <summary>
        /// Delete an actor by using its Id.
        /// </summary>
        /// <param name="id">Actor primary key Id which needs to be valid.</param>
        /// <returns>Returns status code 204 (NoContent) if the Actor was successfully deleted.</returns>
        [HttpDelete("{id}", Name = "DeleteActorById")]
        public async Task<IActionResult> DeleteActorById(int id)
        {
            try
            {
                var actor = await _repository.Get<Actor>(id);

                if (actor == null)
                {
                    return NotFound($"Could not delete actor. Actor with Id {id} was not found.");
                }
                await _repository.Delete<Actor>(id);

                return NoContent();
            }
            catch (Exception e)
            {
                var result = new { Status = StatusCodes.Status500InternalServerError, Data = $"Failed to delete the actor. Exception thrown when attempting to delete data from the database: {e.Message}"};
                return this.StatusCode(StatusCodes.Status500InternalServerError,result);
                    
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

        private List<LinkDto> CreateLinksForCollection(IPagedList pageList)
        {
            var links = new List<LinkDto>();


            // self 
            links.Add(
             new LinkDto(_urlHelper.Link(nameof(GetAllActors), new
             {
                 pagesize = pageList.PageCount,
                 page = pageList.PageNumber
             }), "current page", "GET"));

            links.Add(new LinkDto(_urlHelper.Link(nameof(GetAllActors), new
            {
                pagesize = pageList.PageCount,
                page = 1,
            }), "first", "GET"));

            links.Add(new LinkDto(_urlHelper.Link(nameof(GetAllActors), new
            {
                pagesize = pageList.PageCount,
                page = pageList.PageCount,
            }), "last", "GET"));

            if (!pageList.IsLastPage)
            {
                links.Add(new LinkDto(_urlHelper.Link(nameof(GetAllActors), new
                {
                    pagesize = pageList.PageCount,
                    page = pageList.PageNumber + 1,
                }), "next", "GET"));
            }

            if (!pageList.IsFirstPage)
            {
                links.Add(new LinkDto(_urlHelper.Link(nameof(GetAllActors), new
                {
                    pagesize = pageList.PageCount,
                    page = pageList.PageNumber - 1,
                }), "previous", "GET"));
            }

            return links;
        }
    }
}