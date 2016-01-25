using Timelog.Model;

namespace Timelog.Common.Interface
{
    public interface IUserDataService : IGetAllDataService<User>
    {
        User Put(User timeEntry);
    }
}
