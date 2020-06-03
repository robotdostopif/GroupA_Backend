using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;
using PagedList;

namespace HorrorMovieAPI.Services
{
    public interface IMovieRepository : IRepository
    {
        Task<IPagedList<Movie>> GetAll(int? page, int pagesize, string movieTitle, int exactYear ,int afterYear, params string[] including);
    }
}