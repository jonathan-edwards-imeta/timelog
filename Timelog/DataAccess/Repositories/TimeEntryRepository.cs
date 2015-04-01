using System;
using System.Collections.Generic;
using System.Linq;
using Timelog.DataService.Interface;
using Timelog.Model;

namespace Timelog.DataAccess.Repositories
{
    public class TimeEntryRepository : ITimeEntryRepository, IDisposable
    {
        private TimeLogContext db = new TimeLogContext();

        public IEnumerable<TimeEntry> GetAll()
        {
            return db.TimeEntries;
        }
        public TimeEntry GetById(int id)
        {
            return db.TimeEntries.FirstOrDefault(p => p.Id == id);
        }
        public void Add(TimeEntry TimeEntry)
        {
            db.TimeEntries.Add(TimeEntry);
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
