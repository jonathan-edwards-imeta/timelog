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
        public void Add(TimeEntry timeEntry)
        {
            db.TimeEntries.Add(timeEntry);
            db.SaveChanges();
        }

        public TimeEntry Put(TimeEntry timeEntry)
        {
            if (timeEntry == null)
                throw new Exception(string.Format("TimeEntry {0} was not supplied."));
            
            var t = GetById(timeEntry.Id);

            if (t == null)
                throw new Exception(string.Format("TimeEntry with id {0} does not exist.", timeEntry.Id));

            t.BookingCode = timeEntry.BookingCode;
            t.TimeEntryCreated = timeEntry.TimeEntryCreated;
            t.TimeEntryCreator = timeEntry.TimeEntryCreator;
            t.TimeEntryDate = timeEntry.TimeEntryDate;
            t.TimeEntryDescription = timeEntry.TimeEntryDescription;
            t.TimeEntryDuration = timeEntry.TimeEntryDuration;
            t.TimeEntryUser = timeEntry.TimeEntryUser;
            db.SaveChanges();

            return t;
        }

        public bool Delete(int id)
        {
            var t = GetById(id);

            if (t == null)
                return false;

            db.TimeEntries.Remove(t);
            db.SaveChanges();

            return true;
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
