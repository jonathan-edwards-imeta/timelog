using System;
using Timelog.Common.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataService
{

    public class UserDataService : GetAllDataService<User>, IUserDataService
    {
        public UserDataService(IDbContextScopeFactory dbContextScopeFactory, IUserRepository UserRepository) :
             base(dbContextScopeFactory, UserRepository)
        { }

        public User Put(User timeEntry)
        {
            if (timeEntry == null)
                throw new ArgumentNullException("User");

            using (var dbContextScope = DbContextScopeFactory.Create())
            {
                ((IUserRepository)Repository).Update(timeEntry);
                dbContextScope.SaveChanges();
            }
            return GetById(timeEntry.Id);
        }
    }
}
