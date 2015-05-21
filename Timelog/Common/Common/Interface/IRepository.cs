using System.Collections.Generic;

namespace Timelog.Common.Interface
{
    public interface IRepository<T>
    {        
        T GetById(int id);
        void Add(T tag);
        bool Delete(int tagToDelete);
    }

    public interface IGetAllRepository<T> : IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}