using System;
using FluentNHibernate.Cfg;
using Sparks.FluentNHibernate.Configuration;
using WebSample.Core.Model.Mappings;

namespace WebSample.Core.Configs
{
    public class CoreFluentNhibernateMappings : IFluentMapping
    {
        public Action<MappingConfiguration> GetMappings()
        {
            return config => config.FluentMappings.AddFromAssemblyOf<PersonMap>();
        }
    }
}