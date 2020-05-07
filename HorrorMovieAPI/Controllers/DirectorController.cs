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
    public class DirectorController : ControllerBase
    {
        private readonly DirectorRepository _repository;

        public DirectorController(DirectorRepository repository)
        {
            _repository = repository;
        }
    }
}