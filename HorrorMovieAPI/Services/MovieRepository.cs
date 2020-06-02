using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace HorrorMovieAPI.Services
{
    public class MovieRepository : Repository, IMovieRepository
    {
        private readonly HorrorContext _context;
        private readonly ILogger<MovieRepository> _logger;

        public MovieRepository(HorrorContext context, ILogger<MovieRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Movie>> GetAll(string movieTitle, int exactYear, int afterYear, params string[] including)
        {
            _logger.LogInformation($"Fetching all movies from the database.");
            var movies = await GetAll<Movie>(including);

            if (exactYear != default)
            {
                movies = movies.Where(m => m.Year == exactYear).ToList();
            }
            if (afterYear > 1888)
            {
                movies = movies.Where(m => m.Year >= afterYear).ToList();
            }
                              
            return await Task.FromResult(movies.Where(m => m.Title.Contains(movieTitle)).ToList());
        }

        public async Task<Movie> GetById(int id, bool includeActors, bool includeDirector)
        {
            _logger.LogInformation($"Getting movie with the id {id}");
            IQueryable<Movie> query = _context.Movies.Where(i => i.Id == id);
            
            if (includeActors)
            {
                query = query.Include(a => a.Castings).ThenInclude(b => b.Actor);
            }
            if (includeDirector)
            {
                query = query.Include(x => x.Director);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}