using System;
using System.Collections.Generic;
using System.Linq;
using Timelog.Common;
using Timelog.Common.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataAccess.Repositories
{
    public class BookingCodeRepository : IBookingCodeRepository
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

        public BookingCodeRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null) throw new ArgumentNullException("ambientDbContextLocator");
            _ambientDbContextLocator = ambientDbContextLocator;
        }

        private IQueryable<BookingCode> GetAllInternal()
        {
            //var result = db.BookingCodes.IncludeMultiple(x => x.TagTree, y=> y.TagTree.Tag, z=>z.TagTree.RelatedTagTree, a=>a.TagTree.RelatedTagTree.Tag, b=>b.TagTree.RelatedTagTree.RelatedTagTree, c=>c.TagTree.RelatedTagTree.RelatedTagTree.Tag);
            //foreach (var bookingCode in result)
            //{
            //    var tagTree = bookingCode.TagTree;
            //    var related = tagTree.RelatedTagTree;
            //    while (related != null)
            //    {
            //        related = related.RelatedTagTree;
            //    }
            //}

            //var result = db.Database.SqlQuery<BookingCode>("select * from cfGetChildTags(null) cf join tag t on t.Id = cf.tagId join bookingCode bc on bc.TagTreeId = cf.id");


            var result = DbContext.BookingCodes.IncludeMultiple(x => x.TagTree, y => y.TagTree.Tag, z => z.TagTree.RelatedTagTree, a => a.TagTree.RelatedTagTree.Tag, b => b.TagTree.RelatedTagTree.RelatedTagTree, c => c.TagTree.RelatedTagTree.RelatedTagTree.Tag, d => d.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, e => e.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag, f => f.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, g => g.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , h => h.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, i => i.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , j => j.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, k => k.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , l => l.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, m => m.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                );

            return result;
        }
        
        
        public IEnumerable<BookingCode> GetAll()
        {
            var result = GetAllInternal().ToArray();
            return result;
        }
        
        public BookingCode GetById(int id)
        {
           
            var result = GetAllInternal();

            return result.FirstOrDefault(x => x.Id == id);
        }

        public void Add(BookingCode BookingCode)
        {
            DbContext.BookingCodes.Add(BookingCode);
        }
               
        public bool Delete(int bookingCodeIdToDelete)
        {
            var got = GetById(bookingCodeIdToDelete);
            if (got == null)
                return false;
            DbContext.BookingCodes.Remove(got);
            return true;
        }
    }
}
