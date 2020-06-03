using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;

namespace HorrorMovieAPI.Services
{
    public interface IRepository
    {
        Task<bool> Save();
        Task<T> Add<T>(T entity) where T : class;
        Task<T> Update<T>(T entity) where T : class;
        Task<T> Delete<T>(int id) where T : class;
        Task<IList<T>> GetAll<T>(params string[] including) where T : class;
        Task<T> Get<T>(int id, params string[] including) where T : BaseEntity;
    }
}