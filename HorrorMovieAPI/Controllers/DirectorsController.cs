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
        public async Task<ActionResult<ICollection<Director>>> GetAll(string birthCountry, bool includeMovies)
        {
            return await _repository.GetAll(birthCountry, includeMovies);
        }
    }
}