using System.Data.Entity;
using Timelog.Common;

namespace Timelog.DataAccess
{
    public interface ITimeLogContextInitializer : IDatabaseInitializer<TimeLogContext>
    {
    }
}
