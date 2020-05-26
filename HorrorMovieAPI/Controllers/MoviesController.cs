using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System;
using Microsoft.AspNetCore.Http;
using HorrorMovieAPI.Dto;

namespace HorrorMovieAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieRepository _repository;
        private readonly IMapper _mapper;

        public MoviesController(MovieRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<MovieDTO[]>> GetAll(bool includeActors = false, bool includeDirector = false)
        {
            var result = await _repository.GetAll(includeActors,includeDirector);
            var mappedResults = _mapper.Map<MovieDTO[]>(result);
            return Ok (mappedResults);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetById(int id, bool includeActors = false, bool includeDirector = false)
        {
            var result = await _repository.GetMovieById(id, includeActors, includeDirector);
            var mappedResult = _mapper.Map<MovieDTO>(result);
            return Ok(mappedResult);
        }

        [HttpPost(Name = "AddMovie")]
        public async Task<ActionResult<MovieDTO>> AddMovie(MovieToCreateDTO movieToCreateDTO)
        {
            try
            {
                Director director = await _repository.GetDirectorById(movieToCreateDTO.DirectorID);

                Genre genre = await _repository.GetGenreById(movieToCreateDTO.GenreID);
                if(director == null )
                {
                    return BadRequest($"The director with the id: {director.Id} could not be found.");
                }
                if(genre == null)
                {
                    return BadRequest($"The genre with the id: {genre.Id} could not be found.");
                }

                Movie movie = new Movie
                {
                    Title = movieToCreateDTO.Title,
                    Director = director,
                    Genre = genre
                };
                await _repository.Add(movie);
                
                if (await _repository.Save())
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
    }
}
