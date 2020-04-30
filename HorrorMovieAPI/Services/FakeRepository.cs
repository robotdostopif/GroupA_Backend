using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HorrorMovieAPI.Services
{
    public class FakeRepository : IRepository<Fake>
    {
        private readonly HorrorContext _context;

        public FakeRepository(HorrorContext context)
        {
            _context = context;
        }

        public Task<Fake> Add(Fake fake)
        {
            throw new System.NotImplementedException();
        }
        public Task<Fake> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
        public Task<Fake> Get(int id)
        {
            throw new System.NotImplementedException();
        }
        public Task<List<Fake>> GetAll()
        {
            throw new System.NotImplementedException();
        }
        
        public Task<Fake> Update(Fake fake)
        {
            throw new System.NotImplementedException();
        }
    }

}