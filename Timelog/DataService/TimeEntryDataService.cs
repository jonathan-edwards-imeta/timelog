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
    //CR-SKG: Same problems as TagDataService
    //This uses a slightly different pattern to the others. Maybe IDataService should just have GetById, Add, Delete??
    //and then have subclasses of that...
    public class TimeEntryDataService : ITimeEntryDataService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        ITimeEntryRepository _TimeEntryRepository;

        //CR-SKG: Incorrect variable naming, should be timeEntryRepository
        public TimeEntryDataService(IDbContextScopeFactory dbContextScopeFactory, ITimeEntryRepository TimeEntryRepository)
        {
            if (dbContextScopeFactory == null) throw new ArgumentNullException("dbContextScopeFactory");
            if (TimeEntryRepository == null) throw new ArgumentNullException("TimeEntryRepository");
            _dbContextScopeFactory = dbContextScopeFactory;
            _TimeEntryRepository = TimeEntryRepository;
        }

        //CR-SKG: Incorrect variable naming, should be timeEntryToCreate, no we really need the action on the 
        //end of the Variable of name? Is it not obvious from the method name?
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

        //CR-SKG: Incorrect variable naming, should be timeEntryToDelete
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
