using Timelog.Common;

namespace Timelog.Common
{
    public interface IDataGeneratorFactory
    {
        IDataGenerator Build(TimeLogContext context);
    }
}