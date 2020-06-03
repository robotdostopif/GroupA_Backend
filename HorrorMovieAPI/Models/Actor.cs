using System;
using System.Collections;
using System.Collections.Generic;

namespace HorrorMovieAPI.Models
{
    public class Actor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string BirthTown { get; set; }
        public string BirthCountry { get; set; }
        public ICollection<Casting> Castings { get; set; }
    }

}
