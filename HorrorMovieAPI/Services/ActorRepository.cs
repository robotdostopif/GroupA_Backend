using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{

    public class ActorRepository : Repository, IActorRepository
    {
        private readonly HorrorContext _context;
        private readonly ILogger<ActorRepository> _logger;



        public ActorRepository(HorrorContext context, ILogger<ActorRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IPagedList<Actor>> GetAll(string firstName, int? page, int pagesize, params string[] including)
        {
            _logger.LogInformation($"Fetching all movies from the database.");

            var actors = await GetAll<Actor>(including);

            if (string.IsNullOrEmpty(firstName) == false)
            {
                return actors.Where(w => w.FirstName == firstName).ToList().ToPagedList(page ?? 1, pagesize);
            }

            return actors.ToList().ToPagedList(page ?? 1, pagesize);
        }

        public async Task<Actor> GetById(int id, bool includeMovies)
        {
            _logger.LogInformation($"Fetching actor with id {id}, " + (includeMovies ? "including" : "excluding") + "movies.");
            IQueryable<Actor> query = _context.Actors;
            query = query.Where(d => d.Id == id);

            if (includeMovies)
            {
                query = query.Where(a => a.Id == id).Include(m => m.Castings).ThenInclude(m => m.Movie);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}