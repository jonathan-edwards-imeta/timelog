using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.DataService.Interface
{
    public interface ITagTreeRepository
    {
        IEnumerable<TagTree> GetAll();
        TagTree GetById(int id);
        void Add(TagTree tagTree);
    }
}