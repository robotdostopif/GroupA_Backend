using System.Threading.Tasks;
using HorrorMovieAPI.Models;
using HorrorMovieAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HorrorMovieAPI.Controllers
{
    public class ControllerCRUD<TEntity, TRepository> : ControllerBase, IControllerCRUD<TEntity>
    where TEntity : class, IEntity
    where TRepository : class, IRepository<TEntity>
    {
        private readonly TRepository _repository;
        public ControllerCRUD(TRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var entity = await _repository.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        // api.com/v1.0/[controller]/<id>
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await _repository.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        public Task<ActionResult> Post(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TEntity entity)
        {
            
            if(id != entity.Id)
            {
                return NotFound();
            }
            e = await _repository.Update(entity);
            return NoContent();
        }
    }
}