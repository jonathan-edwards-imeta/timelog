using NUnit.Framework;
using System.Linq;
using Timelog.DataAccess.Repositories;
using Timelog.TestData;

namespace TimeLog.DataAccessTests
{
    [TestFixture]
    public class TimeEntryTests : BaseTest
    {
        [TestCase(200)]
        [TestCase(11)]
        [TestCase(1)]
        public void GetTimeEntryFromTheRepositoryReturnsValidTimeEntry(int id)
        {   
            var ter = new TimeEntryRepository(Sut.MyAmbientDbContextLocator);
            using (var dbContextScope = Sut.MyDbContextScopeFactory.Create())
            {
                var te = ter.GetById(id);

                var originalTimeEntry = TimeEntries.TimeBookings.ToList()[id - 1];

                Assert.IsNotNull(originalTimeEntry, "originalTimeEntry is null");
                Assert.AreEqual(originalTimeEntry.BookingCode.TagTree.TagTreePath, te.BookingCode.TagTree.TagTreePath);
            }
        }
    }
}