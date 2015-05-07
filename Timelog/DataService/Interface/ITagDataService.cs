using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.DataService.Interface
{
    public interface ITagDataService
    {
        IEnumerable<Tag> GetAll();
        Tag GetById(int id);
        void Add(Tag tag);
        bool Delete(int id);
    }
}