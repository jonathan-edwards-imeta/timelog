using System;
using Timelog.Common.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.Common
{

    public class TimeEntryDataService : DataService<TimeEntry>, ITimeEntryDataService
    {
        public TimeEntryDataService(IDbContextScopeFactory dbContextScopeFactory, ITimeEntryRepository TimeEntryRepository) :
             base(dbContextScopeFactory, TimeEntryRepository)
        { }

        public TimeEntry Put(TimeEntry timeEntry)
        {
            if (timeEntry == null)
                throw new ArgumentNullException("TimeEntry");

            using (var dbContextScope = DbContextScopeFactory.Create())
            {               
                ((ITimeEntryRepository)Repository).Update(timeEntry);
                dbContextScope.SaveChanges();
            }
            return GetById(timeEntry.Id);
        }
    }
}
