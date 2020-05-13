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
            int year,
            int maxLength,
            int minLength,
            bool includeActors,
            bool includeDirector,
            int genreId
            )
       {
            // _logger.LogInformation($"Getting all Movies");
            // IQueryable<Movie> query = _context.Movies;
            // IQueryable<Casting> castingQuery = _context.Castings;
           
            // if(includeActors)
            // {
            //     query = query.Include(a => a.Castings
            //     .Join());



            //     castingQuery = castingQuery.Include(b => b.Actor);
            // }

            // if(includeDirector)
            // {
            //     query = query.Include(a => a.Castings);
            //     castingQuery = castingQuery.Include(b => b.Actor);
            // }
            // query = query.OrderBy(y => y.Title);
            return new Movie
        }
    }
}