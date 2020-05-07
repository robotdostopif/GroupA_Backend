using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;

namespace HorrorMovieAPI.Services
{
    public class MovieRepository : IRepository<Movie>, IMovieRepository
    {
        private readonly HorrorContext _context;
        public MovieRepository(HorrorContext context)
        {
            _context = context;
        }
        public async Task<Movie> Add(Movie entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Movie> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Movie> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Movie>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Movie> GetMovieByIdWithActors(int id, bool includeActors)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Movie> GetMovieByIdWithDirector(int id, bool includeDirector)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Movie>> GetMoviesByGenre(int genreId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Movie>> GetMoviesByMaxLength(int length)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Movie>> GetMoviesByMinLength(int length)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Movie>> TaskGetMoviesByYear(int year)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Movie> Update(Movie entity)
        {
            throw new System.NotImplementedException();
        }
    }
}