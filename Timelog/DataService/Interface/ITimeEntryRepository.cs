using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.DataService.Interface
{
    public interface ITimeEntryRepository
    {
        IEnumerable<TimeEntry> GetAll();
        TimeEntry GetById(int id);
        void Add(TimeEntry timeEntry);
    }
}