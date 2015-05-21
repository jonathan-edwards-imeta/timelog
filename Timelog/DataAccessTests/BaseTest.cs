using System;
using NUnit.Framework;
using Timelog.Common;
using Timelog.Common;
using Timelog.TestData;
using TimeLog.EntityFramework.Implementation;

namespace TimeLog.DataAccessTests
{
    public class SubjectUnderTest
    {
        public SubjectUnderTest()
        {
            _dataGeneratorFactory = new Lazy<IDataGeneratorFactory>(() => new TestDataGeneratorFactory());
            _timeLogContextInitializer = new Lazy<ITimeLogContextInitializer>(() => new TimeLogContextDropCreateDatabaseAlwaysInitializer(_dataGeneratorFactory.Value));
            //_context = new Lazy<TimeLogContext>(() => new TimeLogContext(_timeLogContextInitializer.Value));

            _timeLogDbContextFactory = new Lazy<TimeLogDbContextFactory>(() => new TimeLogDbContextFactory(_timeLogContextInitializer.Value));
            _dbContextScopeFactory = new Lazy<DbContextScopeFactory>(()=> new DbContextScopeFactory(_timeLogDbContextFactory.Value));
            _ambientDbContextLocator = new Lazy<AmbientDbContextLocator>(()=>new AmbientDbContextLocator());

        }
        
        private readonly Lazy<TimeLogDbContextFactory> _timeLogDbContextFactory;
        private readonly Lazy<DbContextScopeFactory> _dbContextScopeFactory;
        private readonly Lazy<AmbientDbContextLocator> _ambientDbContextLocator;

        // private readonly Lazy<TimeLogContext> _context;
        private readonly Lazy<ITimeLogContextInitializer> _timeLogContextInitializer;
        private readonly Lazy<IDataGeneratorFactory> _dataGeneratorFactory;

        //public TimeLogContext Context
        //{
        //    get { return _context.Value; }
        //}
        public AmbientDbContextLocator MyAmbientDbContextLocator { get { return _ambientDbContextLocator.Value; } }
        public DbContextScopeFactory MyDbContextScopeFactory { get { return _dbContextScopeFactory.Value; } }
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