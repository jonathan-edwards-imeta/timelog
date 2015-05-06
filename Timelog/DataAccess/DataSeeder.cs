using System;
using System.Collections.Generic;
using Timelog.Common;
using Timelog.Model;

namespace Timelog.DataAccess
{
    public class DataSeeder : IDataSeeder
    {
        private readonly TimeLogContext _context;
        public DataSeeder(TimeLogContext context)
        {
             _context = context;
        }

        public void SeedUsers(IEnumerable<User> user)
        {
            foreach (var u in user)
            {
                _context.Users.Add(u);
            }
            _context.SaveChanges();
        }

        public void SeedTags(IEnumerable<Tag> tags)
        {
            foreach (var t in tags)
            {
                _context.Tags.Add(t);
            }
            _context.SaveChanges();
        }

        public void SeedTagTrees(IEnumerable<TagTree> tagTrees)
        {
            foreach (var t in tagTrees)
            {
                _context.TagTrees.Add(t);
            }
            _context.SaveChanges();
        }

        public void SeedBookingCodes(IEnumerable<BookingCode> bookingCodes)
        {
            foreach (var b in bookingCodes)
            {
                _context.BookingCodes.Add(b);
            }
            _context.SaveChanges();
        }

        public void SeedTimeEntries(IEnumerable<TimeEntry> timeEntries)
        {
            foreach (var b in timeEntries)
            {
                _context.TimeEntries.Add(b);
            }
            _context.SaveChanges();
        }             
    }
}
