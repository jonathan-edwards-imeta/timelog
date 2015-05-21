using Timelog.Model;

namespace Timelog.Common.Interface
{
    public interface ITimeEntryDataService : IDataService<TimeEntry>
    {
        TimeEntry Put(TimeEntry timeEntry); 
    }
}