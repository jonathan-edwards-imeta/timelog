//#define SEED_TIME_LOG_ENTRIES

using System;
using System.Threading.Tasks;
using EfEnumToLookup.LookupGenerator;
using System.Data.Entity;

namespace Timelog.Model
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

            SeedImetaUsers(context);
            SeedStandardTagsTagTreesAndBookingCodes(context);
            
#if SEED_TIME_LOG_ENTRIES    
            SeedTimeLogEntries(context);
#endif
        }

        private void SeedImetaUsers(TimeLogContext context)
        {
            context.Users.Add(new User() { Name = "Jonathan" });           
            context.Users.Add(new User() { Name = "Steve" });
            context.Users.Add(new User() { Name = "Phil" });
            context.Users.Add(new User() { Name = "Jason" });
            context.Users.Add(new User() { Name = "Mark N" });
            context.Users.Add(new User() { Name = "David WL" });
            context.Users.Add(new User() { Name = "David G" });
            context.Users.Add(new User() { Name = "Nia" });
            context.Users.Add(new User() { Name = "Simon" });
            context.Users.Add(new User() { Name = "James W" });
            context.Users.Add(new User() { Name = "James A" });
            context.Users.Add(new User() { Name = "Adrian" });
            context.Users.Add(new User() { Name = "Mark G" });
            context.Users.Add(new User() { Name = "Julie" });
            context.Users.Add(new User() { Name = "Julia" });
            context.Users.Add(new User() { Name = "Nick" });
            context.Users.Add(new User() { Name = "Ben M" });
            
          

            context.Users.Add(new User() { Name = "Ben T" });
            context.Users.Add(new User() { Name = " Michael E" });

            context.SaveChanges();
        }

        private void SeedStandardTagsTagTreesAndBookingCodes(TimeLogContext context)
        {
            var lloydsTag = new Tag() { Text = "Lloyds", TagType = TagType.Customer, };
            var barcapTag = new Tag() { Text = "Barcap", TagType = TagType.Customer, };
            var creditSuisseTag = new Tag() { Text = "Credit Suisse", TagType = TagType.Customer, };
            var hsbcTag = new Tag() { Text = "HSBC", TagType = TagType.Customer, };
            var scbTag = new Tag() { Text = "SCB", TagType = TagType.Customer, };

            var bmoTag = new Tag() { Text = "BMO", TagType = TagType.Customer, };
            var tdTag = new Tag() { Text = "TD", TagType = TagType.Customer, };
            var phase1Tag = new Tag() { Text = "Phase1", TagType = TagType.Phase };
            var specTag = new Tag() { Text = "Spec", TagType = TagType.Project };
            var implTag = new Tag() { Text = "Implementation", TagType = TagType.Project };
            var downstreamTag = new Tag() { Text = "Downstream", TagType = TagType.Task, };
            var mqTag = new Tag() { Text = "Mq", TagType = TagType.SubTask };

            context.Tags.Add(lloydsTag);
            context.Tags.Add(barcapTag);
            context.Tags.Add(creditSuisseTag);
            context.Tags.Add(hsbcTag);
            context.Tags.Add(scbTag);
            context.Tags.Add(bmoTag);
            context.Tags.Add(tdTag);
            context.Tags.Add(phase1Tag);
            context.Tags.Add(specTag);
            context.Tags.Add(implTag);
            context.Tags.Add(downstreamTag);
            context.Tags.Add(mqTag);
            context.SaveChanges();
        
            var tdTagTree = new TagTree() { Tag = tdTag };
            var tdPhase1TagTree = new TagTree() { Tag = phase1Tag, RelatedTagTree = tdTagTree };
            var tdPhase1SpecTagTree = new TagTree() { Tag = specTag, RelatedTagTree = tdPhase1TagTree };
            var tdPhase1SpecDownStreamTagTree = new TagTree() { Tag = downstreamTag, RelatedTagTree = tdPhase1SpecTagTree };
            var tdPhase1ImplementationTagTree = new TagTree() { Tag = implTag, RelatedTagTree = tdPhase1TagTree };
            var tdPhase1ImplementationDownStreamTagTree = new TagTree() { Tag = downstreamTag, RelatedTagTree = tdPhase1ImplementationTagTree };
            var tdPhase1ImplementationDownStreamMqTagTree = new TagTree() { Tag = mqTag, RelatedTagTree = tdPhase1ImplementationDownStreamTagTree };

            var bmoTagTree = new TagTree() { Tag = bmoTag };
            var bmoPhase1TagTree = new TagTree() { Tag = phase1Tag, RelatedTagTree = bmoTagTree };
            var bmoPhase1SpecTagTree = new TagTree() { Tag = specTag, RelatedTagTree = bmoPhase1TagTree };
            var bmoPhase1SpecDownStreamTagTree = new TagTree() { Tag = downstreamTag, RelatedTagTree = bmoPhase1SpecTagTree };
            var bmoPhase1ImplementationTagTree = new TagTree() { Tag = implTag, RelatedTagTree = bmoPhase1TagTree };
            var bmoPhase1ImplementationDownStreamTagTree = new TagTree() { Tag = downstreamTag, RelatedTagTree = bmoPhase1ImplementationTagTree };
            var bmoPhase1ImplementationDownStreamMqTagTree = new TagTree() { Tag = mqTag, RelatedTagTree = bmoPhase1ImplementationDownStreamTagTree };

            var tdPhase1SpecBookingCode = new BookingCode() { TagTree = tdPhase1SpecTagTree };
            var tdPhase1SpecDownstreamBookingCode = new BookingCode() { TagTree = tdPhase1SpecDownStreamTagTree };
            var tdPhase1ImplBookingCode = new BookingCode() { TagTree = tdPhase1ImplementationTagTree };
            var tdPhase1ImplDownstreamBookingCode = new BookingCode() { TagTree = tdPhase1ImplementationDownStreamTagTree };
            var tdPhase1ImplDownstreamMqBookingCode = new BookingCode() { TagTree = tdPhase1ImplementationDownStreamMqTagTree };

            var bmoPhase1SpecBookingCode = new BookingCode() { TagTree = bmoPhase1SpecTagTree };
            var bmoPhase1SpecDownstreamBookingCode = new BookingCode() { TagTree = bmoPhase1SpecDownStreamTagTree };
            var bmoPhase1ImplBookingCode = new BookingCode() { TagTree = bmoPhase1ImplementationTagTree };
            var bmoPhase1ImplDownstreamBookingCode = new BookingCode() { TagTree = bmoPhase1ImplementationDownStreamTagTree };
            var bmoPhase1ImplDownstreamMqBookingCode = new BookingCode() { TagTree = bmoPhase1ImplementationDownStreamMqTagTree };

            context.BookingCodes.Add(tdPhase1SpecBookingCode);
            context.BookingCodes.Add(tdPhase1SpecDownstreamBookingCode);
            context.BookingCodes.Add(tdPhase1ImplBookingCode);
            context.BookingCodes.Add(tdPhase1ImplDownstreamBookingCode);
            context.BookingCodes.Add(tdPhase1ImplDownstreamMqBookingCode);
            
            context.BookingCodes.Add(bmoPhase1SpecBookingCode);
            context.BookingCodes.Add(bmoPhase1SpecDownstreamBookingCode);
            context.BookingCodes.Add(bmoPhase1ImplBookingCode);
            context.BookingCodes.Add(bmoPhase1ImplDownstreamBookingCode);
            context.BookingCodes.Add(bmoPhase1ImplDownstreamMqBookingCode);
            
            context.SaveChanges();
        }

        private static void SeedTimeLogEntries(TimeLogContext context)
        {
            var us = context.Users.ToArrayAsync().GetAwaiter().GetResult();
            var bks = context.BookingCodes.ToArrayAsync().GetAwaiter().GetResult();

            for (var i = 0; i < 500; i++)
            {
                var bk = (i%bks.Length);
                var u = (i%us.Length);
                var h = (i%8);

                var v = new TimeEntry()
                {
                    TimeEntryDate = DateTime.Now.AddDays(-1*i),
                    TimeEntryDuration = h,
                    BookingCode = bks[bk],
                    TimeEntryUser = us[u],
                    TimeEntryCreated = DateTime.Now
                };
                context.TimeEntries.Add(v);
                context.SaveChanges();
            }
        }
    }
}
