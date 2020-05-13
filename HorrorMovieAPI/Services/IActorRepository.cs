using HorrorMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetAll(string firstname, bool includeMovies);
    }
}