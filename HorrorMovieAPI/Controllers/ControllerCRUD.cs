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

        [HttpPost]
        public async Task<ActionResult> Post(TEntity entity)
        {
            await _repository.Add(entity);
            if (await _repository.Save())
            {
                return Created("", entity);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }
            await _repository.Update(entity);
            return Ok();
        }
    }
}