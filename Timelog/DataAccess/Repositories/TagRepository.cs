using System;
using System.Collections.Generic;
using System.Linq;
using Timelog.DataAccess.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataAccess.Repositories
{
    public class TagRepository : ITagRepository
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

        public TagRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null) throw new ArgumentNullException("ambientDbContextLocator");
            _ambientDbContextLocator = ambientDbContextLocator;
        }

        public IEnumerable<Tag> GetAll()
        {
            return DbContext.Tags.ToArray();
        }
        public Tag GetById(int id)
        {
            return DbContext.Tags.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Tag tag)
        {
            DbContext.Tags.Add(tag);           
        }
        public bool Delete(int tagToDelete)
        {
            var got = GetById(tagToDelete);
            if (got == null)
                return false;
            DbContext.Tags.Remove(got);
            return true;
        }
    }
}
