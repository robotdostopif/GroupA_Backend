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
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly HorrorContext _context;
        private readonly ILogger<MovieRepository> _logger;

        public MovieRepository(HorrorContext context, ILogger<MovieRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Movie>> GetAllMovies(string movieTitle, int afterYear, params string[] including)
        {
            _logger.LogInformation($"Fetching all movies from the database.");
            var movies = await GetAll(including);

            if (afterYear > 1888)
            {
                movies = movies.Where(m => m.Year > afterYear).ToList();
            }
                              
            return movies.Where(m => m.Title.Contains(movieTitle)).ToList();
        }

        public async Task<Movie> GetMovieById(int id, bool includeActors, bool includeDirector)
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