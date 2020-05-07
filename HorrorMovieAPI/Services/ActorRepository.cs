using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public class ActorRepository : IRepository<Actor>, IActorRepository
    {
        private readonly HorrorContext _context;

        public ActorRepository(HorrorContext context)
        {
            _context = context;
        }

        public async Task<Actor> Add(Actor entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Actor> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Actor> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Actor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Actor> Update(Actor entity)
        {
            throw new NotImplementedException();
        }
    }
}