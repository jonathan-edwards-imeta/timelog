using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.Common
{
    public interface IDataSeeder
    {
        void SeedUsers(IEnumerable<User>users);

        void SeedTags(IEnumerable<Tag> tags);

        void SeedTagTrees(IEnumerable<TagTree> tagTrees);

        void SeedBookingCodes(IEnumerable<BookingCode> bookingCodes);

        void SeedTimeEntries(IEnumerable<TimeEntry> timeEntries);
    }
}
