using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;

namespace HorrorMovieAPI.Services
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<bool> Save();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<T> Delete(T entity);
        Task<Genre> GetGenreById(int id);
        Task<Director> GetDirectorById(int id);
        Task<IList<T>> GetAll(params string[] including);
    }
}