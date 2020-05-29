using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;

namespace HorrorMovieAPI.Services
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IList<Movie>> GetAllMovies(string movieTitle, int exactYear ,int afterYear, params string[] including);

        Task<Movie> GetById(int id, bool includeActors, bool includeDirector);
    }
}