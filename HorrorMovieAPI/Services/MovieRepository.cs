using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
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

        public Task<List<Movie>> GetAll(
            int year,
            int maxLength,
            int minLength,
            bool includeActors,
            bool includeDirector,
            int genreId
            )
        {
            throw new System.NotImplementedException();
        }
    }
}