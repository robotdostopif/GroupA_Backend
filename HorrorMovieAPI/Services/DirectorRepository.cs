using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public class DirectorRepository : Repository, IDirectorRepository
    {
        private readonly HorrorContext _context;
        private readonly ILogger<DirectorRepository> _logger;
        public DirectorRepository(HorrorContext context, ILogger<DirectorRepository> logger) : base(context,logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IPagedList<Director>> GetAll(string birthCountry, int? page, int pagesize, params string[] including)
        {
            var query = await GetAll<Director>(including);
            _logger.LogInformation("Fetching all directors.");

            if (string.IsNullOrEmpty(birthCountry) == false)
            {
                _logger.LogInformation("Fetching with BirthCountry specified");
                query = query.Where(d => d.BirthCountry == birthCountry).ToList();
            }
            else
            {
                _logger.LogInformation("Fetching with BirthCountry NOT specified");
            }

          

            query = query.OrderBy(d => d.LastName).ToList();
            return query.ToPagedList(page ?? 1, pagesize);
        }
    }
}