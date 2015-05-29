using System.Collections.Generic;

namespace Timelog.Common.Interface
{
    public interface IDataService<T>
    {       
        T GetById(int id);
        void Add(T tag);
        bool Delete(int id);
    }

    public interface IGetAllDataService<T> : IDataService<T>
    {
        IEnumerable<T> GetAll();
    }
}