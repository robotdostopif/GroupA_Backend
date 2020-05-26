using System.Threading.Tasks;
using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace HorrorMovieAPI.Services
{
    public class Repository<T> : IRepository<T>
    where T : class, IEntity
    
    {
        private readonly HorrorContext _context;
        private readonly ILogger _logger;

        public Repository(HorrorContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<T> Add(T entity)
        {
            _logger.LogInformation($"Adding object of type {entity.GetType()}");
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            _logger.LogInformation($"Deleting object of type {entity.GetType()}");
            _context.Set<T>().Remove(entity);
            await Save();
            return entity;
        }

        public async Task<T> Get(int id)
        {
            _logger.LogInformation($"Getting object with id {id}");
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Save()
        {
            _logger.LogInformation("Saving changes");
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<T> Update(T entity)
        {
            _logger.LogInformation($"Updating object of type {entity.GetType()}");
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<Director> GetDirectorById(int id) 
        {
            return await _context.Set<Director>().FindAsync(id);
        }
        public async Task<Genre> GetGenreById(int id)
        {
            return await _context.Set<Genre>().FindAsync(id);
        }
    }
}