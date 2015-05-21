using System.Collections.Generic;
using Timelog.Model;

namespace Timelog.DataAccess.Interface
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAll();
        Tag GetById(int id);
        void Add(Tag tag);
        bool Delete(int tagToDelete);
    }
}