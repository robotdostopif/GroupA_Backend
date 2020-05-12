using System.Threading.Tasks;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HorrorMovieAPI.Controllers
{
    public class ControllerCRUD<T, TRepository> : ControllerBase, IControllerCRUD<T>
    where T : class, IEntity
    where TRepository : class, IRepository<T>
    {
        private readonly TRepository _repository;
        public ControllerCRUD(TRepository repository)
        {
            _repository = repository;
        }

        public Task<ActionResult<T>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<T>> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult> Post(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult> Put(int id, T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}