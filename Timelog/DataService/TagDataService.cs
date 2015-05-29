using System;
using Timelog.Common;
using Timelog.Common.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataService
{
    public class TagDataService : GetAllDataService<Tag>, ITagDataService
    {
        public TagDataService(IDbContextScopeFactory dbContextScopeFactory, ITagRepository tagRepository) :
             base(dbContextScopeFactory, tagRepository)
        { }

        public Tag Patch(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException("TimeEntry");

            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                ((ITagRepository)Repository).Update(tag);
                dbContextScope.SaveChanges();
            }
            return GetById(tag.Id);
        }
    }
}
