using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using WebSample.Core.Configs;

namespace WebSample.Tests
{
    [TestFixture]
    public class SchemaGenerator
    {
        [Test, Explicit]
        public void GenerateSchema()
        {
            Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString("Database=SparksSample;Server=.\\sqlexpress;Integrated Security=SSPI;"))
                .Mappings(new CoreFluentNhibernateMappings().GetMappings())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true))
                .BuildSessionFactory();
        }
    }
}
