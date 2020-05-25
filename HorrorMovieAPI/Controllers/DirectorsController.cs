using AutoMapper;
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
        private readonly IMapper _mapper;
        public DirectorsController(DirectorRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<DirectorDTO[]>> GetAll(string birthCountry = "", bool includeMovies = false)
        {
            var results = await _repository.GetAll(birthCountry, includeMovies);
            var mappedResults = _mapper.Map<DirectorDTO[]>(results);
            return Ok(mappedResults);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDTO>> GetDirectorById(int id, bool includeMovies = false)
        {
            var result = await _repository.GetDirectorById(id, includeMovies);
            var mappedResult = _mapper.Map<DirectorDTO>(result);
            return Ok(mappedResult);
        }
    }
}