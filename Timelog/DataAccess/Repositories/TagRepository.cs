using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using Timelog.DataService.Interface;
using Timelog.Model;

namespace Timelog.DataAccess.Repositories
{
    public class TagRepository : ITagRepository, IDisposable
    {
        private IUnityContainer _unityContainer;
        private TimeLogContext _db;

        public TagRepository(IUnityContainer unityContainer, TimeLogContext db)
        {
            _unityContainer = unityContainer;
            _db = db;
        }

        public IEnumerable<Tag> GetAll()
        {
            return _db.Tags;
        }
        public Tag GetById(int id)
        {
            return _db.Tags.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Tag tag)
        {
            _db.Tags.Add(tag);
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
