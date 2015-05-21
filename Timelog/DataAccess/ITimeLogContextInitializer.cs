using System.Data.Entity;

namespace Timelog.Common
{
    public interface ITimeLogContextInitializer : IDatabaseInitializer<TimeLogContext>
    {
    }
}
