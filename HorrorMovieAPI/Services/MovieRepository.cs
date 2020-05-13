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
    public class MovieRepository : Repository<Movie, HorrorContext>, IMovieRepository
    {
        private readonly HorrorContext _context;
        private readonly ILogger<MovieRepository> _logger;
        public MovieRepository(HorrorContext context, ILogger<MovieRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Movie>> GetAll(
            bool includeActors,
            bool includeDirector
            )
        {
            //_logger.LogInformation($"Getting all Movies");
            IQueryable<Movie> query = _context.Movies;
           
            if(includeActors)
            {
                query = query.Include(a => a.Castings).ThenInclude(b => b.Actor);
            }

            if(includeDirector)
            {
                query = query.Include(a => a.Castings).ThenInclude(b => b.Movie).ThenInclude(c => c.Director);
            }

            query = query.OrderBy(y => y.Title);
            return await query.ToListAsync();
        }
    }
} 