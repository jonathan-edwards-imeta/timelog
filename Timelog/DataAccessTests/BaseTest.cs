using System;
using NUnit.Framework;
using Timelog.Common;
using Timelog.DataAccess;
using Timelog.TestData;

namespace TimeLog.DataAccessTests
{
    public class SubjectUnderTest
    {
        public SubjectUnderTest()
        {
            _dataGeneratorFactory = new Lazy<IDataGeneratorFactory>(() => new TestDataGeneratorFactory());
            _timeLogContextInitializer = new Lazy<ITimeLogContextInitializer>(() => new TimeLogContextDropCreateDatabaseAlwaysInitializer(_dataGeneratorFactory.Value));
            _context = new Lazy<TimeLogContext>(() => new TimeLogContext(_timeLogContextInitializer.Value));
        }

        private readonly Lazy<TimeLogContext> _context;
        private readonly Lazy<ITimeLogContextInitializer> _timeLogContextInitializer;
        private readonly Lazy<IDataGeneratorFactory> _dataGeneratorFactory;

        public TimeLogContext Context
        {
            get { return _context.Value; }
        }
    }

    public abstract class BaseTest
    {
        protected SubjectUnderTest Sut { get; private set; }
        
        [TestFixtureSetUp]
        public void Setup()
        {
            Sut = new SubjectUnderTest();
        }
    }
}