using Microsoft.Practices.Unity;
using System.Web.Http;
using Timelog.Common;
using Timelog.DataAccess;
using Timelog.DataAccess.Repositories;
using Timelog.DataService.Interface;
using Timelog.TestData;
using Unity.WebApi;

namespace Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<TimeLogContext, TimeLogContext>();
            container.RegisterType<ITimeLogContextInitializer, TimeLogContextCreateDatabaseIfNotExistsInitializer>();
            //container.RegisterType<ITimeLogContextInitializer, TimeLogContextDropCreateDatabaseAlwaysInitializer>();

            container.RegisterType<IDataSeeder, DataSeeder>();
            container.RegisterType<IDataGenerator, DataGenerator>();           

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<ITagRepository, TagRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITagTreeRepository, TagTreeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBookingCodeRepository, BookingCodeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITimeEntryRepository, TimeEntryRepository>(new HierarchicalLifetimeManager());
                       
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}