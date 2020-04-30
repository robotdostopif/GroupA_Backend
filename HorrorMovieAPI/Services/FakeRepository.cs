using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HorrorMovieAPI.Services
{
    public class FakeRepository : IRepository<Fake>
    {
        private readonly HorrorContext _context;

        public FakeRepository(HorrorContext context)
        {
            _context = context;
        }

        public async Task<Fake> Add(Fake fake)
        {
            _context.Set<Fake>().Add(fake);
            await _context.SaveChangesAsync();
            return fake;
        }

        public async Task<Fake> Delete(int id)
        {
            var fake = await _context.Set<Fake>().FindAsync(id);
            if (fake == null)
            {
                return fake;
            }
            _context.Set<Fake>().Remove(fake);
            await _context.SaveChangesAsync();
            return fake;
        }

        public async Task<Fake> Get(int id) => await _context.Set<Fake>().FindAsync(id);

        public async Task<List<Fake>> GetAll()
        {
          return await _context.Set<Fake>().ToListAsync();
        }

        public async Task<Fake> Update(Fake fake)
        {
            _context.Entry(fake).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return fake;
        }
    }
}