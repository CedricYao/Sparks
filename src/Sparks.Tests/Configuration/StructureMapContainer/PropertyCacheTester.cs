using Sparks.Configurations.SettingsConfiguration;
using NUnit.Framework;
using Should;

namespace Sparks.Tests.Configuration.StructureMapContainer
{
    [TestFixture]
    public class PropertyCacheTester
    {
        [Test]
        public void should_get_all_properties_in_fake_settings()
        {
            var results = PubliclyWritablePropertiesParser.GetPropertiesFor(typeof (FakeSettings));
            results.Count.ShouldEqual(5);

            Assert.That(results.ContainsKey("Name"), Is.True);
            Assert.That(results.ContainsKey("Age"), Is.True);
            Assert.That(results.ContainsKey("Active"), Is.True);
            Assert.That(results.ContainsKey("DateOfBirth"), Is.True);
            Assert.That(results.ContainsKey("DefaultString"), Is.True);
        }
    }
}