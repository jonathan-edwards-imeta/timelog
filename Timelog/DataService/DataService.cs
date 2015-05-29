using System;
using Timelog.Common.Interface;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataService
{
    public abstract class DataService <T> : IDataService <T>
    {
        protected readonly IDbContextScopeFactory DbContextScopeFactory;
        protected readonly IRepository<T> Repository;

        public DataService(IDbContextScopeFactory dbContextScopeFactory, IRepository<T> repository)
        {
            if (dbContextScopeFactory == null) throw new ArgumentNullException("dbContextScopeFactory");
            if (repository == null) throw new ArgumentNullException("repository");
            DbContextScopeFactory = dbContextScopeFactory;
            Repository = repository;
        }

        public void Add(T t)    
        {
            if (t == null)
                throw new ArgumentNullException("t");

            using (var dbContextScope = DbContextScopeFactory.Create())
            {               
                Repository.Add(t);
                dbContextScope.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                var item = Repository.GetById(id);
                if (item == null)
                    return false;
                Repository.Delete(id);
                dbContextScope.SaveChanges();
                return true;
            }
        }       

        public T GetById(int id)
        {
            using (var dbContextScope = DbContextScopeFactory.CreateReadOnly())
            {               
                var result = Repository.GetById(id);
                return result;
            }
        }
    }
}
