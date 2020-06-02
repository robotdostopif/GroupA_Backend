using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;
using PagedList;

namespace HorrorMovieAPI.Services
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IPagedList<Genre>> GetAll(string genre, int? page,int pagesize, params string[] including);

        Task<Genre> GetById(int id, bool includeMovies);
    }
}