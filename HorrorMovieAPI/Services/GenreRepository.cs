using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public class GenreRepository : IRepository<Genre>, IGenreRepository
    {
        private readonly HorrorContext _context;

        public GenreRepository(HorrorContext context)
        {
            _context = context;
        }

        public async Task<Genre> Add(Genre entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Genre> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Genre> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Genre>> GetAll()
        {
            return await _context.Set<Genre>().ToListAsync();
        }


        public async Task<Genre> GetGenreByIdIncludeActors(int id, bool includeActors)
        {
            throw new NotImplementedException();
        }

        public async Task<Genre> GetGenreByIdIncludeMovies(int id, bool includeMovies)
        {
            throw new NotImplementedException();
        }

        public async Task<Genre> Update(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}