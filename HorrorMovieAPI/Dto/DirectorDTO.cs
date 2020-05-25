using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorrorMovieAPI.Models
{
    public class DirectorDTO : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string BirthThown { get; set; }
        public string BirthCountry { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}