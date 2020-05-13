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
        public ActorRepository(HorrorContext context, ILogger logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<Actor>> GetAll(string firstName, bool includeMovies)
        {
            IQueryable<Actor> query = _context.Actors;
            if(string.IsNullOrEmpty(firstName) == false)
            {
                query.Where(w => w.FirstName == firstName);
            }

            if (includeMovies)
            {
                query = query.Include(p => p.Movies);
            }

            query = query.OrderBy(y => y.LastName);
            return await query.ToListAsync();
        }
    }
}