using EfEnumToLookup.LookupGenerator;
using System.Data.Entity;

namespace Timelog.Common
{
    public class TimeLogContextDropCreateDatabaseAlwaysInitializer : DropCreateDatabaseAlways<TimeLogContext>, ITimeLogContextInitializer
    {
        private readonly IDataGeneratorFactory _dataGeneratorFactory;

        public TimeLogContextDropCreateDatabaseAlwaysInitializer(IDataGeneratorFactory dataGeneratorFactory) : base()
        {
            _dataGeneratorFactory = dataGeneratorFactory;
        }

        protected override void Seed(TimeLogContext context)
        {           
            base.Seed(context);

            //Build enumeration tables.
            var enumToLookup = new EnumToLookup();
            enumToLookup.Apply(context);

            var dataGenerator = _dataGeneratorFactory.Build(context);
       
            dataGenerator.GenerateUsers();
            dataGenerator.GenerateTags();
            dataGenerator.GenerateTagTrees();
            dataGenerator.GenerateBookingCodes();
            dataGenerator.GenerateTimeEntries();            
        }
    }
}
