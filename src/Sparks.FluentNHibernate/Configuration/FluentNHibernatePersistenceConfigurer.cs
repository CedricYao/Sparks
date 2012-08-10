using FluentNHibernate.Cfg.Db;
using Sparks.FluentNHibernate.Persistence;

namespace Sparks.FluentNHibernate.Configuration
{
    public class FluentNHibernatePersistenceConfigurer : IPersistenceConfigurer
    {
        private readonly DatabaseSettings _databaseSettings;

        public FluentNHibernatePersistenceConfigurer(DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        #region IPersistenceConfigurer Members

        public NHibernate.Cfg.Configuration ConfigureProperties(NHibernate.Cfg.Configuration nhibernateConfig)
        {
            nhibernateConfig.AddProperties(_databaseSettings.GetProperties());
            return nhibernateConfig;
        }

        #endregion
    }
}