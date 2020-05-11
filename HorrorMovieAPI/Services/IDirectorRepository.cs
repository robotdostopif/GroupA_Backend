using HorrorMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public interface IDirectorRepository
    {
        Task<List<Director>> GetAll(string birthTown, string birthCountry, bool includeMovies);
    }
}