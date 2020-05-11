using HorrorMovieAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Controllers
{
    public interface IControllerCRUD<T> where T : class, IEntity
    {
        Task<ActionResult<T>> Get(int id);

        Task<ActionResult<T>> Delete(int id);

        Task<ActionResult> Post(T entity);

        Task<ActionResult> Put(int id, T entity);
    }
}