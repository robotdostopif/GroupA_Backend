using HorrorMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public interface IDirectorRepository
    {
        Task<List<Director>> GetDirectorsByBirthTown(string birthTown);

        Task<List<Director>> GetDirectorsByBirthCountry(string birthCountry);

        Task<List<Director>> GetDirectorsAndIncludeMovies(bool includeMovies);
    }
}