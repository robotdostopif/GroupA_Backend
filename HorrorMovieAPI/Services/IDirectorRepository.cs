using HorrorMovieAPI.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public interface IDirectorRepository : IRepository
    {
        Task<IPagedList<Director>> GetAll(string birthCountry,int? page, int pagesize, params string[] including);
    }
}