using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Actor>> GetAll(string firstName, bool includeMovies)
        {
            IQueryable<Actor> query = _context.Actors;
            if (string.IsNullOrEmpty(firstName) == false)
            {
                query = query.Where(w => w.FirstName == firstName);
            }

            if (includeMovies)
            {
                query = query.Include(p => p.Castings).ThenInclude(m => m.Movie);
            }

            query = query.OrderBy(y => y.LastName);
            return await query.ToListAsync();
        }
    }
}