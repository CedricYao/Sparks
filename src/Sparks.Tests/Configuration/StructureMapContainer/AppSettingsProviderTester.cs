using Sparks.Configurations.SettingsConfiguration;
using System;
using NUnit.Framework;
using Should;

namespace Sparks.Tests.Configuration.StructureMapContainer
{
    [TestFixture]
    public class AppSettingsProviderTester
    {
        [Test]
        public void should_bind_settings_for_simple_setting()
        {
            var appSettingsProvider = new AppSettingsProvider();
            var fakeSettingResult = appSettingsProvider.SettingsFor<FakeSettings>();

            fakeSettingResult.Name.ShouldEqual("Cedric");
            fakeSettingResult.Age.ShouldEqual(21);
            fakeSettingResult.Active.ShouldBeTrue();
            fakeSettingResult.DateOfBirth.ShouldEqual(new DateTime(1978,2, 10));
            fakeSettingResult.DefaultString.ShouldEqual("defaultString");
        }
    }
}