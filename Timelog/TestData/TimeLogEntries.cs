using System;
using System.Collections.Generic;
using System.Linq;
using Timelog.Model;

namespace Timelog.TestData
{
    public class TimeEntries
    {
        public static int Volume { get; set; }

        public static IEnumerable<TimeEntry> TimeBookings
        {
            get
            {
                List<TimeEntry> timeEntries = new List<TimeEntry>();

                for (var i = 0; i < Volume; i++)
                {
                    var us = Users.IMetaUsers.ToArray();
                    var bks = TagsTagTreesBookingCodes.BookingCodes.ToArray();

                    var bk = (i % bks.Length);
                    var u = (i % us.Length);
                    var h = (i % 8);

                    var v = new TimeEntry()
                    {
                        TimeEntryDate = DateTime.Now.AddDays(-1 * i),
                        TimeEntryDuration = h,
                        BookingCode = bks[bk],
                        TimeEntryUser = us[u],
                        TimeEntryCreated = DateTime.Now
                    };
                    timeEntries.Add(v);                   
                }
                return timeEntries;
            }
        }
    }
}
