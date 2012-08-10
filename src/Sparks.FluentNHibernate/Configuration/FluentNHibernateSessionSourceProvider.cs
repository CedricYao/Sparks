using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace Sparks.FluentNHibernate.Configuration
{
    public class FluentNHibernateSessionSourceProvider : ISessionSourceProvider
    {
        private readonly IFluentMapping _mappingConfig;
        private readonly IPersistenceConfigurer _persistenceConfigurer;

        public FluentNHibernateSessionSourceProvider(IPersistenceConfigurer persistenceConfigurer, IFluentMapping mappingConfig)
        {
            _persistenceConfigurer = persistenceConfigurer;
            _mappingConfig = mappingConfig;
        }

        public ISessionSource GetSessionSource()
        {
            return new SessionSource(buildFluentConfiguration());
        }

        private FluentConfiguration buildFluentConfiguration()
        {
            return Fluently.Configure()
                .Database(_persistenceConfigurer)
                .Mappings(_mappingConfig.GetMappings());
        }
    }
}