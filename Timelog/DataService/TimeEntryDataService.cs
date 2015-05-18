using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelog.DataAccess;
using Timelog.DataAccess.Interface;
using Timelog.DataService.Interface;
using Timelog.Model;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataService
{
    public class TimeEntryDataService : ITimeEntryDataService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        ITimeEntryRepository _TimeEntryRepository;

        public TimeEntryDataService(IDbContextScopeFactory dbContextScopeFactory, ITimeEntryRepository TimeEntryRepository)
        {
            if (dbContextScopeFactory == null) throw new ArgumentNullException("dbContextScopeFactory");
            if (TimeEntryRepository == null) throw new ArgumentNullException("TimeEntryRepository");
            _dbContextScopeFactory = dbContextScopeFactory;
            _TimeEntryRepository = TimeEntryRepository;
        }

        public void Add(TimeEntry TimeEntryToCreate)
        {
            if (TimeEntryToCreate == null)
                throw new ArgumentNullException("TimeEntryToCreate");

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                //-- Persist
                _TimeEntryRepository.Add(TimeEntryToCreate);
                dbContextScope.SaveChanges();
            }
        }

        public bool Delete(int TimeEntryToDelete)
        {
            if (TimeEntryToDelete == null)
                throw new ArgumentNullException("TimeEntryToDelete");

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                //-- Persist
                _TimeEntryRepository.Delete(TimeEntryToDelete);
                var result = dbContextScope.SaveChanges();

                return true;
            }
        }

        public TimeEntry GetById(int id)
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var dbContext = dbContextScope.DbContexts.Get<TimeLogContext>();
                var result = _TimeEntryRepository.GetById(id);
                return result;
            }
        }

        public TimeEntry Put(TimeEntry timeEntryToChange)
        {
            if (timeEntryToChange == null)
                throw new ArgumentNullException("TimeEntryToCreate");

            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                //-- Persist
                _TimeEntryRepository.Update(timeEntryToChange);
                dbContextScope.SaveChanges();
            }
            return GetById(timeEntryToChange.Id);
        }
    }
}
