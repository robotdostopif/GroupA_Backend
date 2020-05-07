using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public class DirectorRepository : IRepository<Director>, IDirectorRepository
    {
        private readonly HorrorContext _context;

        public DirectorRepository(HorrorContext context)
        {
            _context = context;
        }

        public async Task<Director> Add(Director entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Director> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Director> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Director>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Director>> GetDirectorsAndIncludeMovies(bool includeMovies)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Director>> GetDirectorsByBirthCountry(string birthCountry)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Director>> GetDirectorsByBirthTown(string birthTown)
        {
            throw new NotImplementedException();
        }

        public async Task<Director> Update(Director entity)
        {
            throw new NotImplementedException();
        }
    }
}