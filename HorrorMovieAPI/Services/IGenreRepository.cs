using System.Threading.Tasks;
using HorrorMovieAPI.Models;

namespace HorrorMovieAPI.Services
{
    public interface IGenreRepository
    {
        Task<Genre> GetGenreByIdIncludeMovies(int id, bool includeMovies);
        Task<Genre> GetGenreByIdIncludeActors(int id, bool includeActors);
    }
}