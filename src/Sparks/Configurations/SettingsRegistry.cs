namespace Sparks.Configurations
{
    using SettingsConfiguration;
    using StructureMap.Configuration.DSL;

    public class SettingsRegistry : Registry
    {
        public SettingsRegistry()
        {
            For<ISettingsProvider>().Singleton().Use<AppSettingsProvider>();
            Scan(s =>
                {
                    s.TheCallingAssembly();
                    s.With(new SettingsRegistration());
                });
        }
    }
}