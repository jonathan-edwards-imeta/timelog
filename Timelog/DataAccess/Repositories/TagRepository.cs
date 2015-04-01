using System;
using System.Collections.Generic;
using System.Linq;
using Timelog.DataService.Interface;
using Timelog.Model;

namespace Timelog.DataAccess.Repositories
{
    public class TagRepository : ITagRepository, IDisposable
    {
        private TimeLogContext db = new TimeLogContext();

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags;
        }
        public Tag GetById(int id)
        {
            return db.Tags.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Tag tag)
        {
            db.Tags.Add(tag);
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
