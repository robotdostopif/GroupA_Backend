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

        public async Task<ActionResult<T>> Delete(int id)
        {
            var entity = await _repository.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
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

        public async Task<ActionResult> Put(int id, T entity)
        {
            var ent = await _repository.Get(id);
            if(ent == null)
            {
                return NotFound();
            }
            ent = await _repository.Update(entity);
            return ent(id, entity);
        }
    }
}