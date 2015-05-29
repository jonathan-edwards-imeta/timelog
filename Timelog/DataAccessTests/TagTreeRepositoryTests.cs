using NUnit.Framework;
using Timelog.DataAccess.Repositories;
using Timelog.TestData;

namespace TimeLog.DataAccessTests
{
    [TestFixture]
    public class TagTreeRepositoryTests : BaseTest
    {
        [TestCase(1)]
        [TestCase(11)]
        [TestCase(14)]
        [TestCase(20)]
        public void GetTagTreeFromTheRepositoryReturnsValidTagTree(int id)
        {           
            var ttr = new TagTreeRepository(Sut.MyAmbientDbContextLocator);
            using (var dbContextScope = Sut.MyDbContextScopeFactory.Create())
            {
                var tt = ttr.GetById(id);

                var originalTagTree = TagsTagTreesBookingCodes.TagTrees[id - 1];

                Assert.IsNotNull(originalTagTree, "originalTagTree is null");
                Assert.AreEqual(tt.TagTreePath, originalTagTree.TagTreePath);
            }
        }
    }
}