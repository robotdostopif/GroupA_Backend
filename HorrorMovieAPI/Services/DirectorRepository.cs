using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public class DirectorRepository : Repository<Director, HorrorContext>, IDirectorRepository
    {
        public DirectorRepository(HorrorContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task<List<Director>> GetAll(string birthTown, string birthCountry, bool includeMovies)
        {
            throw new NotImplementedException();
        }
    }
}