using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;

namespace HorrorMovieAPI.Services
{
    public interface IMovieRepository
    {
        Task<List<Movie>> TaskGetMoviesByYear(int year);
        Task<List<Movie>> GetMoviesByMinLength(int length);
        Task<List<Movie>> GetMoviesByMaxLength(int length);
        Task<List<Movie>> GetMoviesByGenre(int genreId);
        Task<Movie> GetMovieByIdWithActors(int id, bool includeActors);
        Task<Movie> GetMovieByIdWithDirector(int id, bool includeDirector);
    }
}