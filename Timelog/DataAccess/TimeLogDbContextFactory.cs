using System.Data.Entity;
using TimeLog.EntityFramework.Interfaces;

namespace Timelog.DataAccess
{
    public class TimeLogDbContextFactory : IDbContextFactory
    {
        private ITimeLogContextInitializer _contextInitializer;
       public TimeLogDbContextFactory(ITimeLogContextInitializer contextInitializer)
        {
            _contextInitializer = contextInitializer;
        }

        public TDbContext CreateDbContext<TDbContext>() where TDbContext : DbContext
        {
            var result = new TimeLogContext(_contextInitializer) as TDbContext;
            return result;
        }
    }
}
