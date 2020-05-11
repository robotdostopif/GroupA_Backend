using System.Threading.Tasks;
using HorrorMovieAPI.DB_Context;
using Microsoft.Extensions.Logging;

namespace HorrorMovieAPI.Services
{

    public class Repository : IRepository<T>
    {
        protected readonly HorrorContext _horrorContext;
        protected readonly ILogger<Repository> _logger;

        public Repository(HorrorContext horrorContext, ILogger<Repository> logger)
        {
            _horrorContext = horrorContext;
            _logger = logger;
        }

        public Task<T> Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }

   
}