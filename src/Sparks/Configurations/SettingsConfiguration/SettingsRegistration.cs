namespace Sparks.Configurations.SettingsConfiguration
{
    using System;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    public class SettingsRegistration : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (!type.Name.EndsWith("Settings")) return;
            registry.Configure(x => x.Configure(r => r.For(type).EnrichWith((session, original) => new AppSettingsProvider().SettingsFor(original.GetType())).Use(type)));
        }
    }
}