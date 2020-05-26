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

        public async Task<List<Movie>> GetAll(
            bool includeActors,
            bool includeDirector
            )
        {
            //_logger.LogInformation($"Getting all Movies");
            IQueryable<Movie> query = _context.Movies;

            if (includeActors && includeDirector)
            {
                query = query.Include(x => x.Director).Include(a => a.Castings).ThenInclude(b => b.Actor);
            }
            else if (includeDirector)
            {
                query = query.Include(c => c.Director);
            }
            else if (includeActors)
            {
                query = query.Include(a => a.Castings).ThenInclude(b => b.Actor);
            }

            query = query.OrderBy(y => y.Title);
            return await query.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id, bool includeActors, bool includeDirector)
        {
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