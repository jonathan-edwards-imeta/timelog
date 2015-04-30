using System.Data.Entity;

namespace Timelog.DataAccess
{
    public interface ITimeLogContextInitializer : IDatabaseInitializer<TimeLogContext>
    {
    }
}
