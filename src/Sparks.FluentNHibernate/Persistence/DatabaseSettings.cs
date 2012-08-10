using System.Collections.Generic;

namespace Sparks.FluentNHibernate.Persistence
{
    public class DatabaseSettings
    {
        public DatabaseSettings()
        {
            Provider = "NHibernate.Connection.DriverConnectionProvider";
            Driver = "NHibernate.Driver.SqlClientDriver";
            Dialect = "NHibernate.Dialect.MsSql2008Dialect";
            UseOuterJoin = true;
            ShowSql = false;
        }

        public string Provider { get; set; }
        public string Driver { get; set; }
        public string Dialect { get; set; }
        public bool UseOuterJoin { get; set; }
        public string ConnectionString { get; set; }
        public bool ShowSql { get; set; }

        public IDictionary<string, string> GetProperties()
        {
            var properties = new Dictionary<string, string>
                {
                    {"connection.provider", Provider},
                    {"connection.driver_class", Driver},
                    {"dialect", Dialect},
                    {"use_outer_join", UseOuterJoin.ToString()},
                    {"connection.connection_string", ConnectionString},
                    {"show_sql", ShowSql.ToString()},
                };
            return properties;
        }
    }
}