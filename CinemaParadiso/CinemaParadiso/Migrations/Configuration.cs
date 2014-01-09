namespace CinemaParadiso.Migrations
{
    using CinemaParadiso.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

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
            CinemaParadisoDb.InitializeDatabaseConnection();
            context.Movies.AddOrUpdate(
                p => p.Name,
                new Movie
                {
                    Name = "The Illusionist",
                    Year = 2006,
                    Creator = "admin",
                    Approved = true,
                    CoverUrl = @"http://ia.media-imdb.com/images/M/MV5BMTM1MjQyMDkzN15BMl5BanBnXkFtZTcwNzAyNTQzMQ@@._V1_SX640_SY720_.jpg"
                }
               );
            SeedMemberShipData();
        }

        private void SeedMemberShipData()
        {
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if(!roles.RoleExists("admin"))
            {
                roles.CreateRole("admin");
            }
            if (!roles.RoleExists("user"))
            {
                roles.CreateRole("user");
            }
            if(membership.GetUser("admin",false) == null)
            {
                membership.CreateUserAndAccount("admin", "123456");
            }
            if(!roles.GetRolesForUser("admin").Contains("admin"))
            {
                roles.AddUsersToRoles(new string[]{"admin"},new string[] {"admin","user"});
            }
        }
    }
}
