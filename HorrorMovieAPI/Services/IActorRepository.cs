using HorrorMovieAPI.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public interface IActorRepository : IRepository
    {
        Task<IPagedList<Actor>> GetAll(string firstname, int? page, int pagesize, params string[] including);
    }
}