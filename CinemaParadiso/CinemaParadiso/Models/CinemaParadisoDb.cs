using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaParadiso.Models
{
    public class CinemaParadisoDb : DbContext
    {
        public CinemaParadisoDb()
            : base("name=DefaultConnection")
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieReview> MovieReviews { get; set; }
    }
}