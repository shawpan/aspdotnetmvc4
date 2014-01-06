namespace CinemaParadiso.Migrations
{
    using CinemaParadiso.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CinemaParadiso.Models.CinemaParadisoDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CinemaParadiso.Models.CinemaParadisoDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Movies.AddOrUpdate(
                p => p.Name,
                new Movie { Name = "The Fountain", Year = 2004 },
                new Movie { Name = "The Illusionist", Year = 2006 },
                new Movie { Name = "Eternal Sunshine of the Spotless Mind", Year = 2004 },
                new Movie { Name = "Troy", Year = 2004 },
                new Movie { Name = "The Great gatsby", Year = 2012 },
                new Movie { Name = "Nine 1/2 Weeks", Year = 1986 },
                new Movie { Name = "Reds", Year = 1981 }
                );
        }
    }
}
