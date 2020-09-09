using System.Net;
using AutoMapper;
using HorrorMovieAPI.Dto;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PagedList.Core;

namespace HorrorMovieAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    [Authorize]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUrlHelper _urlHelper;
        public DirectorsController(IDirectorRepository repository, IMapper mapper, IUrlHelper urlHelper)
        {
            _repository = repository;
            _mapper = mapper;
            _urlHelper = urlHelper;
        }

        /// <summary>
        /// Get all directors from the database.
        /// </summary>
        /// <param name="page">Page refers to which pagenumber will be displayed.</param>
        /// <param name="pagesize">Pagesize refers to objects per page.</param>
        /// <param name="birthCountry">Filter directors by birthcountry</param>
        /// <param name="including"></param>
        /// <returns>A list of Directors that may or may not have been filtered by the user.</returns>
        [HttpGet(Name = "GetAllDirectors")]
        public async Task<ActionResult<DirectorDTO[]>> GetAllDirectors(int? page, int pagesize = 3, string birthCountry = "", [FromQuery] string[] including = null)
        {
            try
            {
                var results = await _repository.GetAll(birthCountry,page, pagesize < 50? pagesize : 50, including);
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
                var result = new { Status = StatusCodes.Status500InternalServerError, Data = $"Failed to retrieve directors. Exception thrown: {e.Message} " };
                return this.StatusCode(StatusCodes.Status500InternalServerError, result);

            }

        }

        /// <summary>
        /// Get a director by its Id.
        /// </summary>
        /// <param name="id">Director primary key Id which needs to be valid.</param>
        /// <param name="including">Properties which will be included.</param>
        /// <returns>A Director object which matched given Id.</returns>
        [HttpGet("{id}", Name = "GetDirectorById")]
        public async Task<ActionResult<DirectorDTO>> GetDirectorById(int id, [FromQuery] string[] including = null)
        {
            try
            {
                var result = await _repository.Get<Director>(id, including);
                return Ok(ExpandSingleItem(result));
            }
            catch (Exception e)
            {
                var result = new { Status = StatusCodes.Status500InternalServerError, Data = $"Failed to retrieve director with id {id}. Exception thrown: {e.Message} "};
                return this.StatusCode(StatusCodes.Status500InternalServerError,result);
                    
            }

        }

        /// <summary>
        /// Create a director by using its Id and DirectorForUpdateDTO containing its data.
        /// </summary>
        /// <param name="directorDto">DTO of a Director object which contains its data (refer to schema-documentation for more information).</param>
        /// <returns>Returns status code 201 (Created) if the Movie was successfully created.</returns>
        [HttpPost(Name = "CreateDirector")]
        public async Task<IActionResult> CreateDirector([FromBody] DirectorForUpdateDTO directorDto)
        {
            try
            {
                var director = _mapper.Map<Director>(directorDto);

                var directorFromRepo = await _repository.Add(director);

                if (directorFromRepo != null)
                {
                    return CreatedAtAction(nameof(GetDirectorById), new { id = director.Id }, director);
                }
                return BadRequest("Failed to create director.");

            }
            catch (Exception e)
            {
                var result = new { Status = StatusCodes.Status500InternalServerError, Data = $"Failed to update the director. Exception thrown when attempting to update data in the database: {e.Message}"};
                return this.StatusCode(StatusCodes.Status500InternalServerError,result);
                    
            }
        }

        /// <summary>
        /// Update a director by using its Id and DirectorForUpdateDTO containing its updated data.
        /// </summary>
        /// <param name="id">Movie primary key Id which needs to be valid.</param>
        /// <param name="directorForUpdateDto">DTO of a Director object which contains updated data (refer to schema-documentation for more information).</param>
        /// <returns>Returns status code 204 (NoContent) if the Movie was successfully updated.</returns>
        [HttpPut("{id}", Name = "UpdateDirectorDetails")]
        public async Task<IActionResult> UpdateDirectorDetails(int id, [FromBody] DirectorForUpdateDTO directorForUpdateDto)
        {
            try
            {
                var directorFromRepo = await _repository.Get<Director>(id);

                if (directorFromRepo == null)
                {
                    return BadRequest($"Could not update director. Director with Id {id} was not found.");
                }
                var directorForUpdate = _mapper.Map(directorForUpdateDto, directorFromRepo);

                await _repository.Update(directorForUpdate);

                return NoContent();
            }
            catch (Exception e)
            {
                var result = new { Status = StatusCodes.Status500InternalServerError, Data = $"Failed to update the director. Exception thrown when attempting to update data in the database: {e.Message}"};
                return this.StatusCode(StatusCodes.Status500InternalServerError,result);
                    
            }
        }

        /// <summary>
        /// Delete a movie by using its Id.
        /// </summary>
        /// <param name="id">Movie primary key Id which needs to be valid.</param>
        /// <returns>Returns status code 204 (NoContent) if the Director was successfully deleted.</returns>
        [HttpDelete("{id}", Name = "DeleteDirectorById")]
        public async Task<IActionResult> DeleteDirectorById(int id)
        {
            try
            {
                var director = await _repository.Get<Director>(id);

                if (director == null)
                {
                    return BadRequest($"Could not delete director. Director with Id {id} was not found.");
                }
                await _repository.Delete<Director>(id);

                return NoContent();
            }
            catch (Exception e)
            {
                var result = new { Status = StatusCodes.Status500InternalServerError, Data = $"Failed to delete the director. Exception thrown when attempting to delete data from the database: {e.Message}"};
                return this.StatusCode(StatusCodes.Status500InternalServerError,result);
                    
            }

        }

        private dynamic ExpandSingleItem(Director director)
        {
            var links = GetLinks(director);
            DirectorDTO directorDto = _mapper.Map<DirectorDTO>(director);

            var resourceToReturn = directorDto.ToDynamic() as IDictionary<string, object>;
            resourceToReturn.Add("links", links);

            return resourceToReturn;
        }

        private IEnumerable<LinkDto> GetLinks(Director director)
        {
            var links = new List<LinkDto>();

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(GetDirectorById), new { id = director.Id }),
              "self",
              "GET"));

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(DeleteDirectorById), new { id = director.Id }),
              "delete",
              "DELETE"));

            links.Add(
               new LinkDto(_urlHelper.Link(nameof(UpdateDirectorDetails), new { id = director.Id }),
               "update",
               "PUT"));

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(CreateDirector), null),
              "create",
              "POST"));

            return links;
        }

        private List<LinkDto> CreateLinksForCollection(IPagedList pageList)
        {
            var links = new List<LinkDto>();


            // self 
            links.Add(
             new LinkDto(_urlHelper.Link(nameof(GetAllDirectors), new
             {
                 pagesize = pageList.PageCount,
                 page = pageList.PageNumber
             }), "current page", "GET"));

            links.Add(new LinkDto(_urlHelper.Link(nameof(GetAllDirectors), new
            {
                pagesize = pageList.PageCount,
                page = 1,
            }), "first", "GET"));

            links.Add(new LinkDto(_urlHelper.Link(nameof(GetAllDirectors), new
            {
                pagesize = pageList.PageCount,
                page = pageList.PageCount,
            }), "last", "GET"));

            if (!pageList.IsLastPage)
            {
                links.Add(new LinkDto(_urlHelper.Link(nameof(GetAllDirectors), new
                {
                    pagesize = pageList.PageCount,
                    page = pageList.PageNumber + 1,
                }), "next", "GET"));
            }

            if (!pageList.IsFirstPage)
            {
                links.Add(new LinkDto(_urlHelper.Link(nameof(GetAllDirectors), new
                {
                    pagesize = pageList.PageCount,
                    page = pageList.PageNumber - 1,
                }), "previous", "GET"));
            }

            return links;
        }
    }
}