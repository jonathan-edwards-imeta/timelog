using Microsoft.Practices.Unity;
using NUnit.Framework;
using Timelog.Common;
using Timelog.DataAccess;
using Timelog.TestData;

namespace TimeLog.DataAccessTests
{
    public abstract class BaseTest
    {
        protected UnityContainer Container { get; private set; }

        [TestFixtureSetUp]
        public void Setup()
        {
            Container = new UnityContainer();
            Container.RegisterType<TimeLogContext, TimeLogContext>();
            Container.RegisterType<IDataSeeder, DataSeeder>();
            Container.RegisterType<IDataGenerator, DataGenerator>();

            TimeEntries.BuildTimeBookings(500);
        }
    }
}