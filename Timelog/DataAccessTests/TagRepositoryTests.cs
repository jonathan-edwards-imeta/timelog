using Microsoft.Practices.Unity;
using NUnit.Framework;
using System;
using System.Linq;
using Timelog.Common;
using Timelog.DataAccess;
using Timelog.DataAccess.Repositories;
using Timelog.TestData;

namespace TimeLog.DataAccessTests
{
    [TestFixture]
    public class TagRepositoryTests
    {
        private UnityContainer _container;

        [SetUp]
        public void Setup()
        {
            _container = new UnityContainer();
            _container.RegisterType<TimeLogContext, TimeLogContext>();
            _container.RegisterType<IDataSeeder, DataSeeder>();
            _container.RegisterType<IDataGenerator, DataGenerator>();
        }

        [Test]
        public void GetAllTagsFromTheRepositoryReturnsAllTags()
        {
            TagRepository tr = new TagRepository(_container, _container.Resolve<TimeLogContext>());
            var allRepositoryTags = tr.GetAll().ToList();

            Assert.AreEqual(TagsTagTreesBookingCodes.Tags.Count(), allRepositoryTags.Count());
            
            foreach( var originalTag in TagsTagTreesBookingCodes.Tags)
            {
                Assert.IsNotNull(allRepositoryTags.FirstOrDefault(t => t.TagType == originalTag.TagType && t.Text == originalTag.Text));
            }                                    
        }
    }
}
