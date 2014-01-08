using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaParadiso.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string CoverUrl { get; set; }
        public string Creator { get; set; }
        public bool Approved { get; set; }
        public ICollection<MovieReview> reviews { get; set; }

        public Movie()
        {
            Approved = false;
        }
    }
}