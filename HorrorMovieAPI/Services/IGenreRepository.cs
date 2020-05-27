using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;

namespace HorrorMovieAPI.Services
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<List<Genre>> GetAll(bool includeMovies);

        Task<Genre> GetById(int id, bool includeMovies);
    }
}