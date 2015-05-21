using System;
using System.Collections.Generic;
using Timelog.Common;
using Timelog.Common.Interface;
using Timelog.Common.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.Common
{
    public class TagDataService : GetAllDataService<Tag>, ITagDataService
    {
        public TagDataService(IDbContextScopeFactory dbContextScopeFactory, ITagRepository tagRepository) :
             base(dbContextScopeFactory, tagRepository)
        { }               
    }
}
