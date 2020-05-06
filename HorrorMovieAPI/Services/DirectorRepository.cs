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

        public Task<Director> Add(Director entity)
        {
            throw new NotImplementedException();
        }

        public Task<Director> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Director> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Director>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Director> Update(Director entity)
        {
            throw new NotImplementedException();
        }
    }
}