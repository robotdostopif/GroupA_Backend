using System.Collections.Generic;
using System.Threading.Tasks;
using HorrorMovieAPI.Models;

namespace HorrorMovieAPI.Services
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<List<Movie>> GetAll(bool includeActors, bool includeDirector);

        Task<Movie> GetMovieById(int id, bool includeActors, bool includeDirector);
    }
}