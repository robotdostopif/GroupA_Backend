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
        public DirectorRepository(HorrorContext context, ILogger logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<Director>> GetAll(string birthCountry, bool includeMovies)
        {
            IQueryable<Director> query = _context.Directors;

            if (string.IsNullOrEmpty(birthCountry) == false)
            {
                query.Where(d => d.BirthCountry == birthCountry);
            }

            if (includeMovies)
            {
                query = query.Include(m => m.Movies);
            }

            query = query.OrderBy(d => d.LastName);
            return await query.ToListAsync();
        }
    }
}