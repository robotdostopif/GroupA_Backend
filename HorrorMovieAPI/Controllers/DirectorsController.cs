using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly DirectorRepository _repository;

        public DirectorsController(DirectorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(string birthCountry = "", bool includeMovies = false)
        {
            var result = await _repository.GetAll(birthCountry, includeMovies);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDirectorById(int id, bool includeMovies = false)
        {
            var result = await _repository.GetDirectorById(id, includeMovies);

            return Ok(result);
        }
    }
}