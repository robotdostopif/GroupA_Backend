using HorrorMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public interface IDirectorRepository : IRepository<Director>
    {
        Task<List<Director>> GetAll(string birthCountry, bool includeMovies);
        Task<Director> GetById(int id, bool includeMovies);
    }
}