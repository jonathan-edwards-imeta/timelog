using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.DataService.Interface
{
    //CR-SKG: We should move this into the common assembly, this will save referencing this assembly if anyone needs
    //to use these interfaces. Also considering converting to IDataService<T> - See TagTreeDataService.cs
    public interface ITagDataService
    {
        IEnumerable<Tag> GetAll();
        Tag GetById(int id);
        void Add(Tag tag);
        bool Delete(int id);
    }
}