using System;
using System.Collections.Generic;
using System.Linq;
using Timelog.Common;
using Timelog.Common.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataAccess.Repositories
{
    public class TagTreeRepository : ITagTreeRepository
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

        public TagTreeRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            if (ambientDbContextLocator == null) throw new ArgumentNullException("ambientDbContextLocator");
            _ambientDbContextLocator = ambientDbContextLocator;
        }

        private IEnumerable<TagTree> GetAllInternal()
        {
            var result = DbContext.TagTrees.IncludeMultiple(x => x.Tag, y => y.RelatedTagTree);
            //foreach (var tagTree in result)
            //{
            //    var related = tagTree.RelatedTagTree;
            //    while (related != null)
            //    {
            //        related = related.RelatedTagTree;
            //    }
            //}

            return result;
        }

        public IEnumerable<TagTree> GetAll()
        {
            //var result = db.TagTrees.Include(x => x.Tag);
            //var result = db.TagTrees.ToList();

            var result = GetAllInternal();

            return result;
        }
        public TagTree GetById(int id)
        {
            //var result = db.TagTrees.IncludeMultiple(x => x.Tag, y => y.RelatedTagTree).FirstOrDefault(p => p.Id == id);
            //var result = db.TagTrees.IncludeMultiple(x=>x.Tag, y=>y.RelatedTagTree).FirstOrDefault(p => p.Id == id);
            //var result = db.TagTrees.Where(x => x.Id == id).Include(x => x.Tag).ToList().FirstOrDefault();
            //var result = db.TagTrees.Where(x => x.Id == id).IncludeMultiple(x => x.Tag, y=>y.RelatedTagTree).ToList().FirstOrDefault();
            
            //var qryTrees = from q in db.TagTrees
            //                    where q.Id == id
            //                    select new
            //                    {
            //                        TagTree = q,
            //                        Id = q.Id,
            //                        Items = q.RelatedTagTree,
            //                        Bob = q.Tag
            //                    };

            //var result = qryTrees.FirstOrDefault().TagTree;

            var result = GetAllInternal();

            return result.FirstOrDefault(x => x.Id == id);
        }

        public void Add(TagTree tagTree)
        {
            DbContext.TagTrees.Add(tagTree);
        }
        public bool Delete(int tagTreeToDelete)
        {
            var got = GetById(tagTreeToDelete);
            if (got == null)
                return false;
            DbContext.TagTrees.Remove(got);
            return true;
        }
    }
}
