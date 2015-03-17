using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLogRecursiveTags.Models;
using System.Linq;
using System.Data.Entity;

namespace TestTimeLogRecursiveTags
{
    [TestClass]
    public class UnitTest1
    {

        [TestInitialize]
        public void Init()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<TimeLogContext>());
            //using (var db = new TimeLogContext())
            //{                
            //    db.Database.Initialize(true);                
            //    db.Database.Create();
            //}
        }
                

        [TestMethod]
        public void TestMethod1()
        {
            using (var db = new TimeLogContext())
            {
                var bmoTag = new Tag() { Text = "BMO", TagType = TagType.Customer, };

                var tdTag = new Tag() { Text = "TD", TagType = TagType.Customer, };
                var phase1Tag = new Tag() { Text = "Phase1", TagType = TagType.Phase };
                var specTag = new Tag() { Text = "Spec", TagType = TagType.Project };
                var implTag = new Tag() { Text = "Implementation", TagType = TagType.Project };
                var downstreamTag = new Tag() { Text = "Downstream", TagType = TagType.Task, };
                var mqTag = new Tag() { Text = "Mq", TagType = TagType.SubTask };

                db.Tags.Add(bmoTag);

                db.Tags.Add(tdTag);
                db.Tags.Add(phase1Tag);
                db.Tags.Add(specTag);
                db.Tags.Add(implTag);
                db.Tags.Add(downstreamTag);
                db.Tags.Add(mqTag);
                db.SaveChanges();

                var tdPhase1SpecBookingCode = new BookingCode() { TagTree = new TagTree() { Tag = specTag, RelatedTagTree = new TagTree() { Tag = phase1Tag, RelatedTagTree = new TagTree() { Tag = tdTag } } } };
                var tdPhase1SpecDownstreamBookingCode = new BookingCode() { TagTree = new TagTree() { Tag = downstreamTag, RelatedTagTree = new TagTree() { Tag = specTag, RelatedTagTree = new TagTree() { Tag = phase1Tag, RelatedTagTree = new TagTree() { Tag = tdTag } } } } };
                var tdPhase1ImplBookingCode = new BookingCode() { TagTree = new TagTree() { Tag = implTag, RelatedTagTree = new TagTree() { Tag = phase1Tag, RelatedTagTree = new TagTree() { Tag = tdTag } } } };
                var tdPhase1ImplDownstreamBookingCode = new BookingCode() { TagTree = new TagTree() { Tag = downstreamTag, RelatedTagTree = new TagTree() { Tag = implTag, RelatedTagTree = new TagTree() { Tag = phase1Tag, RelatedTagTree = new TagTree() { Tag = tdTag } } } } };
                var tdPhase1ImplDownstreamMqBookingCode = new BookingCode() { TagTree = new TagTree() { Tag = mqTag, RelatedTagTree = new TagTree() { Tag = downstreamTag, RelatedTagTree = new TagTree() { Tag = implTag, RelatedTagTree = new TagTree() { Tag = phase1Tag, RelatedTagTree = new TagTree() { Tag = tdTag } } } } } };

                db.BookingCodes.Add(tdPhase1SpecBookingCode);
                db.BookingCodes.Add(tdPhase1SpecDownstreamBookingCode);
                db.BookingCodes.Add(tdPhase1ImplBookingCode);
                db.BookingCodes.Add(tdPhase1ImplDownstreamBookingCode);
                db.BookingCodes.Add(tdPhase1ImplDownstreamMqBookingCode);
                db.SaveChanges();

                var userJon = new User() { Name = "Jon" };
                var userMark = new User() { Name = "Mark" };
                var userSteve = new User() { Name = "Steve" };
                var userNia = new User() { Name = "Nia" };
                db.Users.Add(userJon);
                db.Users.Add(userMark);
                db.Users.Add(userSteve);
                db.Users.Add(userNia);
                db.SaveChanges();

                var bks = new[] { tdPhase1SpecBookingCode,
                                    tdPhase1SpecDownstreamBookingCode,
                                  tdPhase1ImplBookingCode,
                    tdPhase1ImplDownstreamBookingCode,
                    tdPhase1ImplDownstreamMqBookingCode
                                };

                var us = new[] { userJon, userMark, userSteve, userNia};

                for (var i=0; i< 200; i++)
                {
                    var bk = (i % 5 ) ;
                    var u = (i % 4) ;
                    var h = (i % 8) ;

                    var v = new TimeEntry() {
                        TimeEntryDate = DateTime.Now.AddDays(-1 * i),
                        TimeEntryDuration = h,
                        BookingCode = bks[bk],
                        //TimeEntryCreator = us[u],
                        TimeEntryUser = us[u],
                        TimeEntryCreated = DateTime.Now
                        };
                    db.TimeEntries.Add(v);
                    db.SaveChanges();
                }

                var query = from t in db.TimeEntries
                            orderby t.TimeEntryDuration
                            select t;

                Assert.AreEqual(200, query.Count());

            };
                                   
        }
    }
}
