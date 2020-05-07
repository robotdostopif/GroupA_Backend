using HorrorMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetActorsByRoleName(string roleName);

        Task<List<Actor>> GetActorsByBirthTown(string town);

        Task<List<Actor>> GetActorsByBirthCountry(string country);

        Task<List<Actor>> GetActorsAndIncludeMovies(bool includeMovies);
    }
}