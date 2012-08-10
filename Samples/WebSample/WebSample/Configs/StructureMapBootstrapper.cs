using System.Web.Mvc;
using Sparks.FluentNHibernate.Configuration;
using StructureMap;
using WebSample.Core.Configs;

namespace WebSample.UI.Configs
{
    public static class StructureMapBootstrapper
    {
        public static void Execute()
        {
            ObjectFactory.Initialize(x =>
                {
                    x.AddRegistry<FrameworkRegistry>();
                    x.AddRegistry<CoreRegistry>();
                });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
        }
    }
}