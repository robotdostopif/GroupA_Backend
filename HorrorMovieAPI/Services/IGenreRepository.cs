using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;

namespace HorrorMovieAPI.Services
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAll(bool includeMovies, bool includeActors);

        Task<Genre> GetById(int id, bool includeMovies, bool includeActors);
    }
}