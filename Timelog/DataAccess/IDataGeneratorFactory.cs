using Timelog.Common;

namespace Timelog.DataAccess
{
    public interface IDataGeneratorFactory
    {
        IDataGenerator Build(TimeLogContext context);
    }
}