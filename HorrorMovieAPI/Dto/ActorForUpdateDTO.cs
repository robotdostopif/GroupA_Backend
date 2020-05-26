using System;

namespace HorrorMovieAPI.Dto
{
    public class ActorForUpdateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string BirthTown { get; set; }
        public string BirthCountry { get; set; }
    }
}