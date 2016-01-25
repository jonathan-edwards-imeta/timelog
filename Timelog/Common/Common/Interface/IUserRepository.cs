using Timelog.Model;

namespace Timelog.Common.Interface
{
    public interface IUserRepository : IGetAllRepository<User>
    {
        User Update(User timeEntry);
    }
}
