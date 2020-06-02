using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;
using PagedList;

namespace HorrorMovieAPI.Services
{
    public interface IGenreRepository : IRepository
    {
        Task<IPagedList<Genre>> GetAll(string genre, int? page,int pagesize, params string[] including);
    }
}