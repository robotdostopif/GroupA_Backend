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
    public class GenreRepository : Repository<Genre, HorrorContext>, IGenreRepository
    {
        private readonly HorrorContext _context;
        private readonly ILogger<GenreRepository> _logger;

        public GenreRepository(HorrorContext context, ILogger<GenreRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Genre>> GetAll(bool includeMovies)
        {
            IQueryable<Genre> query = _context.Genres;

            if (includeMovies)
            {
                query = query.Include(x => x.Movies).ThenInclude(x => x.Castings).ThenInclude(x => x.Actor);
            }

            query = query.OrderBy(y => y.Name);
            return await query.ToListAsync();
        }

        public async Task<Genre> GetById(int id, bool includeMovies)
        {
            IQueryable<Genre> query = _context.Genres.Where(i => i.Id == id);

            if (includeMovies)
            {
                query = query.Where(i => i.Id == id).Include(x => x.Movies).ThenInclude(x => x.Castings).ThenInclude(x => x.Actor);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}