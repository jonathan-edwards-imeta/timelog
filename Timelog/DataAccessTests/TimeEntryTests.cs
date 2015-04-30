using System.Linq;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using Timelog.DataAccess;
using Timelog.DataAccess.Repositories;
using Timelog.TestData;

namespace TimeLog.DataAccessTests
{
    [TestFixture]
    public class TimeEntryTests : BaseTest
    {
        [TestCase(1)]
        public void GetTimeEntryFromTheRepositoryReturnsValidTimeEntry(int id)
        {
            var ter = new TimeEntryRepository(Container, Container.Resolve<TimeLogContext>());
            var te = ter.GetById(id);

            var originalTimeEntry = TimeEntries.TimeBookings.ToList()[id - 1];

            Assert.IsNotNull(originalTimeEntry, "originalTimeEntry is null");
            Assert.AreEqual(te.BookingCode.TagTree.TagTreePath, originalTimeEntry.BookingCode.TagTree.TagTreePath);
        }
    }
}