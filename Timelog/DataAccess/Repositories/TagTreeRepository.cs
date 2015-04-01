using System;
using System.Collections.Generic;
using System.Linq;
using Timelog.DataService.Interface;
using Timelog.Model;

namespace Timelog.DataAccess.Repositories
{
    public class TagTreeRepository : ITagTreeRepository, IDisposable
    {
        private TimeLogContext db = new TimeLogContext();

        public IEnumerable<TagTree> GetAll()
        {
            return db.TagTrees;
        }
        public TagTree GetById(int id)
        {
            return db.TagTrees.FirstOrDefault(p => p.Id == id);
        }
        public void Add(TagTree TagTree)
        {
            db.TagTrees.Add(TagTree);
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
