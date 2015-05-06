using System;
using System.Collections.Generic;
using System.Linq;
using Timelog.DataService.Interface;
using Timelog.Model;

namespace Timelog.DataAccess.Repositories
{
    public class BookingCodeRepository : IBookingCodeRepository, IDisposable
    {
        private TimeLogContext _db; 

        public BookingCodeRepository(TimeLogContext db)
        {
            _db = db;
        }

        private IEnumerable<BookingCode> GetAllInternal()
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


            var result = _db.BookingCodes.IncludeMultiple(x => x.TagTree, y => y.TagTree.Tag, z => z.TagTree.RelatedTagTree, a => a.TagTree.RelatedTagTree.Tag, b => b.TagTree.RelatedTagTree.RelatedTagTree, c => c.TagTree.RelatedTagTree.RelatedTagTree.Tag, d => d.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, e => e.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag, f => f.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, g => g.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , h => h.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, i => i.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , j => j.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, k => k.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                , l => l.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree, m => m.TagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.RelatedTagTree.Tag
                );

            return result;
        }
        
        
        public IEnumerable<BookingCode> GetAll()
        {
            //return db.BookingCodes.Include(x=>x.TagTree);
            var result = GetAllInternal();
            return result;
        }
        
        public BookingCode GetById(int id)
        {
            //var result = db.BookingCodes.Include(x => x.TagTree);
            //var singleItem = result.FirstOrDefault(p => p.Id == id);
            //return singleItem;
            
            var result = GetAllInternal();

            return result.FirstOrDefault(x => x.Id == id);
        }

        public void Add(BookingCode BookingCode)
        {
            _db.BookingCodes.Add(BookingCode);
            _db.SaveChanges();
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
