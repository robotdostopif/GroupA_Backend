using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HorrorMovieAPI.Dto;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using PagedList.Mvc;
using PoweredSoft.Types;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

namespace HorrorMovieAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    [Authorize]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUrlHelper _urlHelper;

        public GenresController(IUrlHelper urlHelper, IGenreRepository repository, IMapper mapper)
        {
            _urlHelper = urlHelper;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all the genres with possibility to include movies
        /// </summary>

        [HttpGet(Name="GetAll")]
        public async Task<ActionResult<GenreDTO[]>> GetAll(int? page,int pagesize=3, [FromQuery]string genre = "", [FromQuery] string[] including = null)
        {
            try
            {
                var results = await _repository.GetAll(genre, page, pagesize, including);
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
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        /// <summary>
        /// Gets the genre with a specific ID and possibility to include other properties
        /// </summary>
        [HttpGet("{id}", Name = "GetGenreById")]

        public async Task<ActionResult<GenreDTO>> GetGenreById(int id, [FromQuery] string[] including = null)
        {
            try
            {
                var result = await _repository.Get<Genre>(id, including);
                return Ok(ExpandSingleItem(result));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Failed to retrieve the genre with id {id}. Exception thrown when attempting to retrieve data from the database: {e.Message}");
            }
        }
        /// <summary>
        /// Detete the genre with a specific ID 
        /// </summary>
        [HttpDelete("{id}", Name = "DeleteGenreById")]
        public async Task<ActionResult> DeleteGenreById(int id)
        {
            try
            {
                var genre = await _repository.Get<Genre>(id);
                if (genre == null)
                {
                    return BadRequest($"Could not delete genre. Genre with Id {id} was not found.");
                }
                await _repository.Delete<Genre>(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Failed to delete the genre. Exception thrown when attempting to delete data from the database: {e.Message}");
            }
        }

        /// <summary>
        /// Change the genre with a specific ID 
        /// </summary>
        [HttpPut("{id}", Name = "UpdateGenreDetails")]
        public async Task<ActionResult> UpdateGenreDetails(int id, [FromBody] GenreForUpdateDTO genreForUpdateDto)
        {
            try
            {
                var genreFromRepo = await _repository.Get<Genre>(id);

                if (genreFromRepo == null)
                {
                    return NotFound($"Could not update genre. Genre with Id {id} was not found.");
                }

                var genreForUpdate = _mapper.Map(genreForUpdateDto, genreFromRepo);

                await _repository.Update(genreForUpdate);

                return NoContent();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Failed to update the genre. Exception thrown when attempting to update data in the database: {e.Message}");
            }
        }
        /// <summary>
        /// Create a new genre
        /// </summary>
        [HttpPost(Name = "CreateGenre")]

        public async Task<ActionResult> CreateGenre([FromBody] GenreDTO genreDTO)
        {
            try
            {
                var genre = _mapper.Map<Genre>(genreDTO);
                var genreFromRepo = await _repository.Add(genre);

                if (genreFromRepo != null)
                {
                    return CreatedAtAction(nameof(GetGenreById), new { id = genre.Id }, genre);
                }
                return BadRequest("Failed to create genre.");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Failed to create the genre. Exception thrown when attempting to add data to the database: {e.Message}");
            }

        }
        private dynamic ExpandSingleItem(Genre genre)
        {
            var links = GetLinks(genre);
            GenreDTO genreDTO = _mapper.Map<GenreDTO>(genre);

            var resourceToReturn = genreDTO.ToDynamic() as IDictionary<string, object>;
            resourceToReturn.Add("links", links);

            return resourceToReturn;
        }

        private IEnumerable<LinkDto> GetLinks(Genre genre)
        {
            var links = new List<LinkDto>();

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(GetGenreById), new { id = genre.Id }),
              "self",
              "GET"));

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(DeleteGenreById), new { id = genre.Id }),
              "delete",
              "DELETE"));

            links.Add(
               new LinkDto(_urlHelper.Link(nameof(UpdateGenreDetails), new { id = genre.Id }),
               "update",
               "PUT"));

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(CreateGenre), null),
              "create",
              "POST"));

            return links;
        }
        private List<LinkDto> CreateLinksForCollection(IPagedList pageList)
        {
            var links = new List<LinkDto>();


            // self 
            links.Add(
             new LinkDto(_urlHelper.Link(nameof(GetAll), new
             {
                 pagecount = pageList.PageCount,
                 page = pageList.PageNumber
             }), "current page", "GET"));

            links.Add(new LinkDto(_urlHelper.Link(nameof(GetAll), new
            {
                pagecount = pageList.PageCount,
                page = 1,
            }), "first", "GET"));

            links.Add(new LinkDto(_urlHelper.Link(nameof(GetAll), new
            {
                pagecount = pageList.PageCount,
                page = pageList.PageCount,
            }), "last", "GET"));

            if (!pageList.IsLastPage)
            {
                links.Add(new LinkDto(_urlHelper.Link(nameof(GetAll), new
                {
                    pagecount = pageList.PageCount,
                    page = pageList.PageNumber + 1,
                }), "next", "GET"));
            }

            if (!pageList.IsFirstPage)
            {
                links.Add(new LinkDto(_urlHelper.Link(nameof(GetAll), new
                {
                    pagecount = pageList.PageCount,
                    page = pageList.PageNumber - 1,
                }), "previous", "GET"));
            }

            return links;
        }
    }
}