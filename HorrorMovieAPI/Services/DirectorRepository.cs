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
    public class DirectorRepository : Repository<Director, HorrorContext>, IDirectorRepository
    {
        private readonly HorrorContext _context;
        private readonly ILogger<DirectorRepository> _logger;
        public DirectorRepository(HorrorContext context, ILogger<DirectorRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Director>> GetAll(string birthCountry, bool includeMovies)
        {
            IQueryable<Director> query = _context.Directors;

            if (string.IsNullOrEmpty(birthCountry) == false)
            {
                _logger.LogInformation("Fetching with BirthCountry specified");
                query = query.Where(d => d.BirthCountry == birthCountry);
            }
            else
            {
                _logger.LogInformation("Fetching with BirthCountry NOT specified");
            }

            if (includeMovies)
            {
                query = query.Include(m => m.Movies);
            }

            query = query.OrderBy(d => d.LastName);
            return await query.ToListAsync();
        }

        public async Task<Director> GetDirectorById( int id,bool includeMovies)
        {
            var query= await _context.Directors.Where(d => d.Id == id).FirstOrDefaultAsync();
            if (includeMovies)
            {
                query = await _context.Directors.Where(d => d.Id == id).Include(m=>m.Movies).FirstOrDefaultAsync();
            }
          
            return query;
        }
    }
}