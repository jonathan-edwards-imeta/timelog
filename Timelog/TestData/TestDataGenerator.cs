using Timelog.Common;

namespace Timelog.TestData
{
    public class TestDataGenerator : IDataGenerator
    {
        private readonly IDataSeeder _dataSeeder;
      
        public TestDataGenerator(IDataSeeder dataSeeder)
        {
            _dataSeeder = dataSeeder;                        
        }

        public void GenerateBookingCodes()
        {
            _dataSeeder.SeedBookingCodes(TagsTagTreesBookingCodes.BookingCodes);
        }

        public void GenerateTags()
        {
            _dataSeeder.SeedTags(TagsTagTreesBookingCodes.Tags);
        }

        public void GenerateTagTrees()
        {
            _dataSeeder.SeedTagTrees(TagsTagTreesBookingCodes.TagTrees);
        }

        public void GenerateTimeEntries()
        {            
            _dataSeeder.SeedTimeEntries(TimeEntries.TimeBookings);
        }

        public void GenerateUsers()
        {
            _dataSeeder.SeedUsers(Users.IMetaUsers);
        }
    }
}
