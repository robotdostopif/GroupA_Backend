using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Dto
{
    public class MovieToCreateDTO
    {
        public string Title { get; set; }
        public int DirectorID { get; set; }
        public int GenreID { get; set; }
        public int Length { get; set; }
        public int Year { get; set; }
    }
}
