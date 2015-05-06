using System;
using System.Collections.Generic;
using System.Linq;
using Timelog.DataService.Interface;
using Timelog.Model;

namespace Timelog.DataAccess.Repositories
{
    public class TimeEntryRepository : ITimeEntryRepository, IDisposable
    {
        private TimeLogContext _db;

        public TimeEntryRepository(TimeLogContext db)
        {
            _db = db;
        }

        private IEnumerable<TimeEntry> GetAllInternal()
        {
            var result = _db.TimeEntries.IncludeMultiple(xx => xx.BookingCode, x => x.BookingCode.TagTree, y => y.BookingCode.TagTree.Tag, z => z.BookingCode.TagTree.RelatedTagTree, a => a.BookingCode.TagTree.RelatedTagTree.Tag, b => b.BookingCode.TagTree.RelatedTagTree.RelatedTagTree, c => c.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.Tag, d => d.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, e => e.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag, f => f.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, g => g.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , h => h.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, i => i.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , j => j.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, k => k.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , l => l.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, m => m.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                );

            return result;
        }


        public IEnumerable<TimeEntry> GetAll()
        {
            //return db.BookingCodes.Include(x=>x.TagTree);
            var result = GetAllInternal();
            return result;
        }

        public TimeEntry GetById(int id)
        {
             var result = GetAllInternal();

            return result.FirstOrDefault(x => x.Id == id);
        }

        public void Add(TimeEntry timeEntry)
        {
            _db.TimeEntries.Add(timeEntry);
            _db.SaveChanges();
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
            _db.SaveChanges();

            return t;
        }

        public bool Delete(int id)
        {
            var t = GetById(id);

            if (t == null)
                return false;

            _db.TimeEntries.Remove(t);
            _db.SaveChanges();

            return true;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
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
