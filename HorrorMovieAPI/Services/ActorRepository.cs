using HorrorMovieAPI.DB_Context;
using HorrorMovieAPI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Services
{
    public class ActorRepository : Repository<Actor, HorrorContext>, IActorRepository
    {
        public ActorRepository(HorrorContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task<List<Actor>> GetAll(string roleName, string town, string country, bool includeMovies)
        {
            throw new NotImplementedException();
        }
    }
}