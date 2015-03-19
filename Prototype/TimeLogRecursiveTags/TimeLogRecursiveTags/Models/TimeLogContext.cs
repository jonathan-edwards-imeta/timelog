using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EfEnumToLookup.LookupGenerator;
using TimeLogRecursiveTags.Models.Conventions;

namespace TimeLogRecursiveTags.Models
{
    public class TimeLogContextInitializer : DropCreateDatabaseAlways<TimeLogContext>
    {
        protected override void Seed(TimeLogContext context)
        {
            //Add some initial data...
            //IList<Standard> defaultStandards = new List<Standard>();

            //defaultStandards.Add(new Standard() { StandardName = "Standard 1", Description = "First Standard" });
            //defaultStandards.Add(new Standard() { StandardName = "Standard 2", Description = "Second Standard" });
            //defaultStandards.Add(new Standard() { StandardName = "Standard 3", Description = "Third Standard" });

            //foreach (Standard std in defaultStandards)
            //    context.Standards.Add(std);

            base.Seed(context);

            //Build enumeration tables.
            var enumToLookup = new EnumToLookup();
            enumToLookup.Apply(context);
        }
    }


    public class TimeLogContext : DbContext
    {
        public TimeLogContext() : base()
        {
            Database.SetInitializer(new TimeLogContextInitializer());
        }

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