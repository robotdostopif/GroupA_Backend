using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PoweredSoft.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly HorrorContext _context;
        private readonly ILogger<GenreRepository> _logger;

        public GenreRepository(HorrorContext context, ILogger<GenreRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Genre>> GetAll(string genre, params string[] including)
        {
            _logger.LogInformation($"Fetching all genres from the database.");

            var movies = await GetAll(including);
           
            if(string.IsNullOrEmpty(genre) == false)
            {
                return movies.Where(m => m.Name.ToLower() == genre.ToLower()).ToList();
            }

            return movies.ToList();
            
        }

        public async Task<Genre> GetById(int id, bool includeMovies)
        {
            IQueryable<Genre> query = _context.Genres.Where(i => i.Id == id);

            if (includeMovies)
            {
                _logger.LogInformation($"Fetching genre with id number {id} and movies associated whit them");

                query = query.Where(i => i.Id == id).Include(x => x.Movies).ThenInclude(x => x.Castings).ThenInclude(x => x.Actor);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}