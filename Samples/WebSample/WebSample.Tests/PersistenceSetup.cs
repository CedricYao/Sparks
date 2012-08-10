using NUnit.Framework;
using Sparks.FluentNHibernate.Configuration;
using Sparks.FluentNHibernate.Persistence;
using WebSample.Core.Configs;

namespace WebSample.Tests
{
    public class PersistenceSetup
    {
        [SetUpFixture]
        public class PersistenceFixtureSetup
        {
            [SetUp]
            public void Setup()
            {
                var persistenceConfigurer = new FluentNHibernatePersistenceConfigurer(new DatabaseSettings() { ShowSql = true, ConnectionString = @"Server=.\sqlexpress;Database=SparksSample;Trusted_Connection=True;"});
                var sessionSourceProvider = new FluentNHibernateSessionSourceProvider(persistenceConfigurer, new CoreFluentNhibernateMappings());

                PersistenceFixtureBase.SessionSource = sessionSourceProvider.GetSessionSource();
            }
        }
    }
}