using Sparks.Configurations.SettingsConfiguration;
using NUnit.Framework;
using Should;

namespace Sparks.Tests.Configuration.StructureMapContainer
{
    [TestFixture]
    public class AppSettingsDataTester
    {
        [Test]
        public void simply_pull_data()
        {
            AppSettingsData.GetValue("FakeSettings.Name").ShouldEqual("Cedric");
        }
    }
}