using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Security.Infrastructure;

namespace Security.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Security.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Security.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "SuperPowerUser",
                Email = "test@imeta.co.uk",
                EmailConfirmed = true,
                FirstName = "John",
                LastName = "Smith",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-4)
            };

            manager.Create(user, "MySuperP@ssword!");
        }
    }
}
