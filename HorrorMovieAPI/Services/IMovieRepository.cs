using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;

namespace HorrorMovieAPI.Services
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAll(
            int year,
            int maxLength,
            int minLength,
            bool includeActors,
            bool includeDirector,
            int genreId
            );
    }
}