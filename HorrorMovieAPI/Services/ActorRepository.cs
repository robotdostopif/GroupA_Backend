using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public class ActorRepository : Repository<Actor, HorrorContext>, IActorRepository
    {
        private readonly HorrorContext _context;
        private readonly ILogger<ActorRepository> _logger;

        public ActorRepository(HorrorContext context, ILogger<ActorRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<List<Actor>> GetAll(string roleName, string town, string country, bool includeMovies)
        {
            throw new NotImplementedException();
        }
    }
}