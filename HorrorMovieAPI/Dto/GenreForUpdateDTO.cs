using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Models
{
    public class GenreForUpdateDTO
    {
       public  IPagedList<dynamic> genres { get; set; }
        public int pages { get; set; }

    }
}
