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
        public Task<Movie> Add(Movie entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Movie>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> GetMovieByIdWithActors(int id, bool includeActors)
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> GetMovieByIdWithDirector(int id, bool includeDirector)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Movie>> GetMoviesByGenre(int genreId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Movie>> GetMoviesByMaxLength(int length)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Movie>> GetMoviesByMinLength(int length)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Movie>> TaskGetMoviesByYear(int year)
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> Update(Movie entity)
        {
            throw new System.NotImplementedException();
        }
    }
}