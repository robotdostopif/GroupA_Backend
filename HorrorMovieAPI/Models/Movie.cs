using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HorrorMovieAPI.Models
{
    public class Movie : BaseEntity
    {
        public Genre Genre { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public int BudgetInUsd { get; set; }
        public int Length { get; set; }
        public int Year { get; set; }
        public Director Director { get; set; }
        public ICollection<Casting> Castings { get; set; }
    }
}