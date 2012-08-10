using System;
using FluentNHibernate.Cfg;

namespace Sparks.FluentNHibernate.Configuration
{
    public interface IFluentMapping
    {
        Action<MappingConfiguration> GetMappings();
    }
}