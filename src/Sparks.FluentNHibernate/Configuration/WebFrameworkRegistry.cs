using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
using Sparks.Configurations.SettingsConfiguration;
using Sparks.FluentNHibernate.Persistence;
using Sparks.Persistence;
using StructureMap.Configuration.DSL;

namespace Sparks.FluentNHibernate.Configuration
{
    public class WebFrameworkRegistry : Registry
    {
        public WebFrameworkRegistry()
        {
            For<ISessionSourceProvider>().Use<FluentNHibernateSessionSourceProvider>();
            For<ISettingsProvider>().Singleton().Use<AppSettingsProvider>();
            For<ISessionSource>().Singleton().Use(x => x.GetInstance<ISessionSourceProvider>().GetSessionSource());
            For<IUnitOfWork>().HttpContextScoped().Use(x => x.GetInstance<INHibernateUnitOfWork>());
            For<INHibernateUnitOfWork>().HttpContextScoped().Use<NHibernateUnitOfWork>();
            For<IPersistenceConfigurer>().Use<FluentNHibernatePersistenceConfigurer>();
            For<IRepository>().Use<GenericNHibernateRepository>();
            Scan(s =>
                {
                    s.TheCallingAssembly();
                    s.With(new SettingsRegistration());
                });
        }
    }
}