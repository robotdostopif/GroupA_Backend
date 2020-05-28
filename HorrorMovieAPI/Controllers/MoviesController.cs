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

namespace HorrorMovieAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
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

        [HttpGet]
        public async Task<ActionResult<MovieDTO[]>> GetAll(string movieTitle = "", bool includeActors = false, bool includeDirector = false)
        {
            try
            {
                var results = await _repository.GetAll(movieTitle, includeActors, includeDirector);
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
                var result = await _repository.GetMovieById(id, includeActors, includeDirector);
                return Ok(ExpandSingleItem(result));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to retrieve the movie with id: {id}. Exception thrown: {e.Message}");
            }
        }

        [HttpPost(Name = "AddMovie")]
        public async Task<ActionResult<MovieDTO>> AddMovie(MovieToCreateDTO movieToCreateDTO)
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
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to create the movie. Exception thrown when attempting to add data to the database: {e.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{id}", Name = "UpdateMovie")]
        public async Task<ActionResult> UpdateMovie(int id, MovieToCreateDTO movieDTO)
        {
            try
            {
                var movieToUpdate = await _repository.Get(id);
                if (movieToUpdate == null)
                {
                    return NotFound($"Could not find the movie with the id {id}");
                }

                var updatedMovie = _mapper.Map(movieDTO, movieToUpdate);
                var movieFromRepo = await _repository.Update(updatedMovie);
                if (movieFromRepo != null)
                {
                    return NoContent();
                }
            }

            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Failed to update the movie. Exception thrown: {e.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{id}", Name = "DeleteMovie")]
        public async Task<ActionResult> DeleteMovie(int movieId)
        {
            try
            {
                var movieToDelete = await _repository.Get(movieId);
                if (movieToDelete == null)
                {
                    return NotFound($"Could not found the movie with the id: {movieId}");
                }

                var movieFromRepo = await _repository.Delete(movieToDelete);
                if (movieFromRepo != null)
                {
                    return NoContent();
                }
            }

            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to delete the movie with the id: {movieId}. Exception thrown: {e.Message}");
            }
            return BadRequest();
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
              new LinkDto(_urlHelper.Link(nameof(DeleteMovie), new { id = movie.Id }),
              "delete",
              "DELETE"));

            links.Add(
               new LinkDto(_urlHelper.Link(nameof(UpdateMovie), new { id = movie.Id }),
               "update",
               "PUT"));

            links.Add(
              new LinkDto(_urlHelper.Link(nameof(AddMovie), null),
              "create",
              "POST"));

            return links;
        }

    }
}
