using Timelog.Common;
using Timelog.Common.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataService
{
    public class TagTreeDataService : GetAllDataService<TagTree>, ITagTreeDataService
    {
        public TagTreeDataService(IDbContextScopeFactory dbContextScopeFactory, ITagTreeRepository TagTreeRepository) :
            base(dbContextScopeFactory, TagTreeRepository)
        {
        }
    }
}
