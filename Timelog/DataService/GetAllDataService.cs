using System;
using System.Collections.Generic;
using Timelog.Common.Interface;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.Common
{
    public abstract class GetAllDataService<T> : DataService<T>, IGetAllDataService <T>
    {
        private readonly IGetAllRepository<T> _getAllRepository;

        public GetAllDataService(IDbContextScopeFactory dbContextScopeFactory, IGetAllRepository<T> repository): base(dbContextScopeFactory,repository)
        {
            _getAllRepository = repository;
        }       

        public IEnumerable<T> GetAll()
        {
            using (var dbContextScope = DbContextScopeFactory.CreateReadOnly())
            {              
                var result = _getAllRepository.GetAll();
                return result;
            }
        }
                
    }
}
