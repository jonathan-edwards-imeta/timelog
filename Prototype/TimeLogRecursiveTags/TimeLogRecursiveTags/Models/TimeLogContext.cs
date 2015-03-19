using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TimeLogRecursiveTags.Models.Conventions;

namespace TimeLogRecursiveTags.Models
{
    public class TimeLogContext : DbContext
    {
        //public TimeLogContext() : base()
        //{
        //    Database.SetInitializer<TimeLogContext>(new DropCreateDatabaseAlways<TimeLogContext>());
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.AddBefore<ForeignKeyIndexConvention>(new ForeignKeyNamingConvention());

            modelBuilder.Properties<int>().Where(x => x.Name == "Id").Configure(x => x.IsKey().HasColumnOrder(1));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TimeEntry> TimeEntries { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<BookingCode> BookingCodes { get; set; }

    }
}