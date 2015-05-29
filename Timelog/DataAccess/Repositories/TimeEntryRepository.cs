using System;
using System.Linq;
using Timelog.Common;
using Timelog.Common.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataAccess.Repositories
{
    public class TimeEntryRepository : ITimeEntryRepository
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;

        private TimeLogContext DbContext
        {
            get
            {
                var dbContext = _ambientDbContextLocator.Get<TimeLogContext>();

                if (dbContext == null)
                    throw new InvalidOperationException("No ambient DbContext of type TimeLogContext found. This means that this repository method has been called outside of the scope of a DbContextScope. A repository must only be accessed within the scope of a DbContextScope, which takes care of creating the DbContext instances that the repositories need and making them available as ambient contexts. This is what ensures that, for any given DbContext-derived type, the same instance is used throughout the duration of a business transaction. To fix this issue, use IDbContextScopeFactory in your top-level business logic service method to create a DbContextScope that wraps the entire business transaction that your service method implements. Then access this repository within that scope. Refer to the comments in the IDbContextScope.cs file for more details.");

                return dbContext;
            }
        }

        public TimeEntryRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null) throw new ArgumentNullException("ambientDbContextLocator");
            _ambientDbContextLocator = ambientDbContextLocator;
        }

        private IQueryable<TimeEntry> GetAllInternal()
        {
            var result = DbContext.TimeEntries.IncludeMultiple(xx => xx.BookingCode, x => x.BookingCode.TagTree, y => y.BookingCode.TagTree.Tag, z => z.BookingCode.TagTree.RelatedTagTree, a => a.BookingCode.TagTree.RelatedTagTree.Tag, b => b.BookingCode.TagTree.RelatedTagTree.RelatedTagTree, c => c.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.Tag, d => d.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, e => e.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag, f => f.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, g => g.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , h => h.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, i => i.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , j => j.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, k => k.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , l => l.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, m => m.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , n => n.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, o => o.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , p => p.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, q => q.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , r => r.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, s => s.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , t => t.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, u => u.BookingCode.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                );

            return result;
        }


        public TimeEntry GetById(int id)
        {
             var result = GetAllInternal();

            return result.FirstOrDefault(x => x.Id == id);
        }

        public void Add(TimeEntry timeEntry)
        {
            DbContext.TimeEntries.Add(timeEntry);            
        }

        public TimeEntry Update(TimeEntry timeEntry)
        {
            if (timeEntry == null)
                throw new Exception("TimeEntry was not supplied.");
            
            var t = GetById(timeEntry.Id);

            if (t == null)
                throw new Exception($"TimeEntry with id {timeEntry.Id} does not exist.");

            t.BookingCode = timeEntry.BookingCode;
            t.TimeEntryCreated = timeEntry.TimeEntryCreated;
            t.TimeEntryCreator = timeEntry.TimeEntryCreator;
            t.TimeEntryDate = timeEntry.TimeEntryDate;
            t.TimeEntryDescription = timeEntry.TimeEntryDescription;
            t.TimeEntryDuration = timeEntry.TimeEntryDuration;
            t.TimeEntryUser = timeEntry.TimeEntryUser;
            
            return t;
        }

        public bool Delete(int id)
        {
            var t = GetById(id);

            if (t == null)
                return false;

            DbContext.TimeEntries.Remove(t);
            
            return true;
        }
    }
}
