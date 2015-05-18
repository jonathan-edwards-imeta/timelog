using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.DataService.Interface
{
    //CR-SKG: We should move this into the common assembly, this will save referencing this assembly if anyone needs
    //to use these interfaces.
    public interface ITimeEntryDataService
    {
        TimeEntry GetById(int id);
        void Add(TimeEntry timeEntry);
        TimeEntry Put(TimeEntry timeEntry);
        bool Delete(int id);
    }
}