using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelog.Common;

namespace Timelog.TestData
{
    public class DataGenerator : IDataGenerator
    {
        private IDataSeeder _dataSeeder;
      
        public DataGenerator(IDataSeeder dataSeeder)
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
