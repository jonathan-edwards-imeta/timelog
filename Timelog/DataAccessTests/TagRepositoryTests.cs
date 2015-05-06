using Microsoft.Practices.Unity;
using NUnit.Framework;
using System;
using System.Linq;
using Timelog.DataAccess;
using Timelog.DataAccess.Repositories;
using Timelog.TestData;

namespace TimeLog.DataAccessTests
{
    [TestFixture]
    public class TagRepositoryTests : BaseTest
    {
        [Test]
        public void GetAllTagsFromTheRepositoryReturnsAllTags()
        {
            var tr = new TagRepository(Sut.Context);
            var allRepositoryTags = tr.GetAll().ToList();

            Assert.AreEqual(TagsTagTreesBookingCodes.Tags.Count(), allRepositoryTags.Count());
            
            foreach( var originalTag in TagsTagTreesBookingCodes.Tags)
            {
                Assert.IsNotNull(allRepositoryTags.FirstOrDefault(t => t.TagType == originalTag.TagType && t.Text == originalTag.Text));
            }                                    
        }
    }
}
