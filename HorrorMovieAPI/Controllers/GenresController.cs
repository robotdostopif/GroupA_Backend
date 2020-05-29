using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HorrorMovieAPI.Dto;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HorrorMovieAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
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

        [HttpGet]
        public async Task<ActionResult<GenreDTO[]>> GetAll([FromQuery]string genre = "", [FromQuery] string [] including = null)
        {
            try
            {
                var results = await _repository.GetAll(genre, including);
                var toReturn = results.Select(x => ExpandSingleItem(x));
                return Ok(toReturn);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetGenreById")]
        public async Task<ActionResult<GenreDTO>> GetGenreById(int id, bool includeMovies = false)
        {
            try
            {
                var result = await _repository.GetById(id, includeMovies);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ExpandSingleItem(result));
                }

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }

        [HttpDelete("{id}", Name = "DeleteGenreById")]
        public async Task<ActionResult> DeleteGenreById(int id)
        {
            try
            {
                var entity = await _repository.Delete(id);
                if (entity == null)
                {
                    return NotFound();
                }
                return Ok();

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }
        [HttpPut("{id}", Name = "UpdateGenreDetails")]
        public async Task<ActionResult> UpdateGenreDetails(int id, Genre genre)
        {
            try
            {
                if (id != genre.Id)
                {
                    return NotFound();
                }
                await _repository.Update(genre);
                return Ok();

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
            }
        }
        [HttpPost(Name = "CreateGenre")]
        public async Task<ActionResult> CreateGenre(Genre genre)
        {
            try
            {
                await _repository.Add(genre);
                if (await _repository.Save())
                {
                    return Created("", genre);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database failure: {e.Message}");
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
    }
}