#define SEED_DATABASE
#define SEED_TIME_LOG_ENTRIES

using EfEnumToLookup.LookupGenerator;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using Timelog.Common;

namespace Timelog.DataAccess
{
    public class TimeLogContextInitializer : CreateDatabaseIfNotExists<TimeLogContext>
                                            //DropCreateDatabaseAlways<TimeLogContext>
    {

        private IUnityContainer _unityContainer;
        public TimeLogContextInitializer(IUnityContainer unityContainer) : base()
        {
            _unityContainer = unityContainer;
        }

        protected override void Seed(TimeLogContext context)
        {           
            base.Seed(context);

            //Build enumeration tables.
            var enumToLookup = new EnumToLookup();
            enumToLookup.Apply(context);

        #if SEED_DATABASE
            var generator = _unityContainer.Resolve<IDataGenerator>();
            generator.GenerateUsers();
            generator.GenerateTags();
            generator.GenerateTagTrees();
            generator.GenerateBookingCodes();

            #if SEED_TIME_LOG_ENTRIES
                generator.GenerateTimeEntries(500);
            #endif
        #endif
        }

    }
}
