using Microsoft.Practices.Unity;
using System.Web.Http;
using Timelog.Common;
using Timelog.Common.Repositories;
using Timelog.Common.Interface;
using Unity.WebApi;
using TimeLog.EntityFramework.Interfaces;
using TimeLog.EntityFramework.Implementation;

namespace Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IDataGeneratorFactory, TestDataGeneratorFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<ITimeLogContextInitializer, TimeLogContextCreateDatabaseIfNotExistsInitializer>();
            //container.RegisterType<ITimeLogContextInitializer, TimeLogContextDropCreateDatabaseAlwaysInitializer>();

            //TODO fix this
            container.RegisterType <IDbContextFactory, TimeLogDbContextFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IDbContextScopeFactory, DbContextScopeFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IAmbientDbContextLocator, AmbientDbContextLocator>(new HierarchicalLifetimeManager());

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<ITagRepository, TagRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITagTreeRepository, TagTreeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBookingCodeRepository, BookingCodeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITimeEntryRepository, TimeEntryRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<ITagDataService, TagDataService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITagTreeDataService, TagTreeDataService>(new HierarchicalLifetimeManager());
            container.RegisterType<IBookingCodeDataService, BookingCodeDataService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITimeEntryDataService, TimeEntryDataService>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}