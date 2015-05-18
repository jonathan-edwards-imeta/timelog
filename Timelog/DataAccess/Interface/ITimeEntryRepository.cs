using Timelog.Model;

namespace Timelog.DataAccess.Interface
{
    public interface ITimeEntryRepository
    {        
        TimeEntry GetById(int id);
        void Add(TimeEntry timeEntry);
        TimeEntry Update(TimeEntry timeEntry);
        bool Delete(int id);
    }
}