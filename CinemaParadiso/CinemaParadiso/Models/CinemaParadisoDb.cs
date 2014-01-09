using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace CinemaParadiso.Models
{
    public class CinemaParadisoDb : DbContext
    {
        public CinemaParadisoDb()
            : base("name=DefaultConnection")
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieReview> MovieReviews { get; set; }

        public static void InitializeDatabaseConnection()
        {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }
    }
}