using StructureMap.Configuration.DSL;

namespace WebSample.Core.Configs
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.RegisterConcreteTypesAgainstTheFirstInterface();
                });
        }
    }
}