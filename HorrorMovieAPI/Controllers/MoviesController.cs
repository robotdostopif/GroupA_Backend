using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System;
using Microsoft.AspNetCore.Http;
using HorrorMovieAPI.Dto;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace HorrorMovieAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    [Authorize]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUrlHelper _urlHelper;

        public MoviesController(IMovieRepository repository, IMapper mapper, IUrlHelper urlHelper)
        {
            _mapper = mapper;
            _repository = repository;
            _urlHelper = urlHelper;
        }

        // Example requests (Case sensitive includes):
        // https://localhost:5001/api/v1.0/movies?movieTitle=hall
        // https://localhost:5001/api/v1.0/movies?including=Director&movieTitle=hall
        // https://localhost:5001/api/v1.0/movies?including=Director&including=Genre&movieTitle=hall
        // https://localhost:5001/api/v1.0/movies?including=Director&including=Genre
        [HttpGet]
        public async Task<ActionResult<MovieDTO[]>> GetAll([FromQuery] string movieTitle = "", [FromQuery] int exactYear = default, [FromQuery] int afterYear = default, [FromQuery] string[] including = null)
        {
            try
            {
                var results = await _repository.GetAll(movieTitle, exactYear, afterYear, including);
                var toReturn = results.Select(x => ExpandSingleItem(x));
                return Ok(toReturn);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to retrieve movies. Exception thrown: {e.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetMovieById")]
        public async Task<ActionResult<MovieDTO>> GetMovieById(int id, bool includeActors = false, bool includeDirector = false)
        {
            try
            {
                var result = await _repository.GetById(id, includeActors, includeDirector);
                return Ok(ExpandSingleItem(result));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to retrieve the movie with id: {id}. Exception thrown: {e.Message}");
            }
        }

        [HttpDelete("{id}", Name = "DeleteMovieById")]
        public async Task<ActionResult> DeleteMovieById(int id)
        {
            try
            {
                var movie = await _repository.GetById(id,false,false);

                if (movie == null)
                {
                    return NotFound($"Could not delete movie. Movie with Id {id} was not found.");
                }
                await _repository.Delete(movie);

                return NoContent();
            }

            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to delete the movie with the id: {id}. Exception thrown: {e.Message}");
            }
        }

        [HttpPut("{id}", Name = "UpdateMovieDetails")]
        public async Task<ActionResult> UpdateMovieDetails(int id, MovieForUpdateDTO movieDTO)
        {
            try
            {
                var movieFromRepo = await _repository.GetById(id,false,false);
                if (movieFromRepo == null)
                {
                    return NotFound($"Could not find the movie with the id {id}");
                }

                var movieForUpdate = _mapper.Map(movieDTO, movieFromRepo);

                await _repository.Update(movieForUpdate);
        
                return NoContent();
            }

            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Failed to update the movie. Exception thrown: {e.Message}");
            }
        }

        [HttpPost(Name = "CreateMovie")]
        public async Task<ActionResult<MovieDTO>> CreateMovie(MovieForUpdateDTO movieToCreateDTO)
        {
            try
            {
                Director director = await _repository.GetDirectorById(movieToCreateDTO.DirectorID);

                Genre genre = await _repository.GetGenreById(movieToCreateDTO.GenreID);
                if (director == null)
                {
                    return BadRequest($"The director with the id: {movieToCreateDTO.DirectorID} could not be found.");
                }
                if (genre == null)
                {
                    return BadRequest($"The genre with the id: {movieToCreateDTO.GenreID} could not be found.");
                }

                Movie movie = new Movie
                {
                    Title = movieToCreateDTO.Title,
                    Length = movieToCreateDTO.Length,
                    Year = movieToCreateDTO.Year,
                    Director = director,
                    Genre = genre
                };
                var movieFromRepo = await _repository.Add(movie);

                if (movieFromRepo != null)
                {
                    return Created($"/api/v1.0/movies/{movie.Id}", _mapper.Map<MovieDTO>(movie));
                }
                return BadRequest("Failed to create movie.");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to create the movie. Exception thrown when attempting to add data to the database: {e.Message}");
            }
        }

        private dynamic ExpandSingleItem(Movie movie)
        {
            var links = GetLinks(movie);
            MovieDTO movieDto = _mapper.Map<MovieDTO>(movie);

            var resourceToReturn = movieDto.ToDynamic() as IDictionary<string, object>;
            resourceToReturn.Add("links", links);

            return resourceToReturn;
        }

        private IEnumerable<LinkDto> GetLinks(Movie movie)
        {
            var links = new List<LinkDto>();

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(GetMovieById), new { id = movie.Id }),
              "self",
              "GET"));

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(DeleteMovieById), new { id = movie.Id }),
              "delete",
              "DELETE"));

            links.Add(
               new LinkDto(_urlHelper.Link(nameof(UpdateMovieDetails), new { id = movie.Id }),
               "update",
               "PUT"));

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(CreateMovie), null),
              "create",
              "POST"));

            return links;
        }

    }
}
