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

        /// <summary>
        /// Gets all movies from the database.
        /// </summary>
        /// <param name="movieTitle">Filter by Movies by title.</param>
        /// <param name="exactYear">Filter Movies by exact release year.</param>
        /// <param name="afterYear">Filter Movies which were created after this year.</param>
        /// <param name="including">Dynamic inclusions which determine what foreign entities should be included in results.</param>
        /// <returns>A list of Movies that may or may not have been filtered by the user.</returns>
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

        /// <summary>
        /// Get a movie by its Id.
        /// </summary>
        /// <param name="id">Movie primary key Id which needs to be valid.</param>
        /// <param name="includeActors">Include list of Actors in the Movie.</param>
        /// <param name="includeDirector">Include who directed the Movie.</param>
        /// <returns>A Movie object which matched given Id.</returns>
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

        /// <summary>
        /// Delete a movie by using its Id.
        /// </summary>
        /// <param name="id">Movie primary key Id which needs to be valid.</param>
        /// <returns>Returns status code 204 (NoContent) if the Movie was successfully deleted.</returns>
        [HttpDelete("{id}", Name = "DeleteMovieById")]
        public async Task<ActionResult> DeleteMovieById(int id)
        {
            try
            {
                var movie = await _repository.Get<Movie>(id);

                if (movie == null)
                {
                    return NotFound($"Could not delete movie. Movie with Id {id} was not found.");
                }
                await _repository.Delete<Movie>(id);

                return NoContent();
            }

            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Failed to delete the movie with the id: {id}. Exception thrown: {e.Message}");
            }
        }

        /// <summary>
        /// Update a movie by using its Id and MovieForUpdateDTO containing its updated data.
        /// </summary>
        /// <param name="id">Movie primary key Id which needs to be valid.</param>
        /// <param name="movieDTO">DTO of a Movie object which contains updated data (refer to schema-documentation for more information).</param>
        /// <returns>Returns status code 204 (NoContent) if the Movie was successfully updated.</returns>
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

        /// <summary>
        /// Create a movie by using its Id and MovieForUpdateDTO containing its data.
        /// </summary>
        /// <param name="movieToCreateDTO">DTO of a Movie object which contains its data (refer to schema-documentation for more information).</param>
        /// <returns>Returns status code 201 (Created) if the Movie was successfully created.</returns>
        [HttpPost(Name = "CreateMovie")]
        public async Task<ActionResult<MovieDTO>> CreateMovie(MovieForUpdateDTO movieToCreateDTO)
        {
            try
            {
                Director director = await _repository.Get<Director>(movieToCreateDTO.DirectorID);

                Genre genre = await _repository.Get<Genre>(movieToCreateDTO.GenreID);
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
