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

        public async Task<List<Genre>> GetAll(bool includeMovies, bool includeActors)
        {
            return await _context.Set<Genre>().ToListAsync();
        }
    }
}