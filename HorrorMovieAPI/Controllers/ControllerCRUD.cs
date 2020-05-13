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
        public Task<ActionResult<T>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        // api.com/v1.0/[controller]/<id>
        public async Task<ActionResult<T>> Get(int id)
        {
            var entity = await _repository.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
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