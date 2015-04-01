using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.DataService.Interface
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAll();
        Tag GetById(int id);
        void Add(Tag tag);
    }
}