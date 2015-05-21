using Timelog.Common;
using Timelog.TestData;

namespace Timelog.Common
{
    public class TestDataGeneratorFactory : IDataGeneratorFactory
    {
        public IDataGenerator Build(TimeLogContext context)
        {
            return new TestDataGenerator(new DataSeeder(context));
        }
    }
}