using Timelog.Model;

namespace Timelog.Common.Interface
{
    public interface ITimeEntryRepository : IRepository<TimeEntry>
    {                
        TimeEntry Update(TimeEntry timeEntry);        
    }
}