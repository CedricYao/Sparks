using Sparks.Configurations;
using Sparks.Configurations.SettingsConfiguration;
using System;
using NUnit.Framework;
using Should;
using StructureMap;

namespace Sparks.Tests.Configuration.StructureMapContainer
{
    [TestFixture]
    public class FakeSettingsTester
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            ObjectFactory.Initialize(x =>
                                         {
                                             x.AddRegistry(new SettingsRegistry());
                                             x.Scan(s =>
                                                        {
                                                            s.TheCallingAssembly();
                                                            s.With(new SettingsRegistration());
                                                        });
                                         });
        }

        [Test]
        public void default_constructor_should_have_default_string_set()
        {
            var sut = new FakeSettings();

            sut.DefaultString.ShouldEqual("defaultString");
        }

        [Test]
        public void activator_should_have_default_string_set()
        {
            var sut = Activator.CreateInstance<FakeSettings>();

            sut.DefaultString.ShouldEqual("defaultString");
        }

        [Test]
        public void structuremap_should_resolve_settings_in_fakeSettings()
        {
            var result = ObjectFactory.GetInstance<FakeSettings>();
            result.Name.ShouldEqual("Cedric");
            result.Age.ShouldEqual(21);
        }
    }

    public class FakeSettings
    {
        public FakeSettings()
        {
            DefaultString = "defaultString";
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DefaultString { get; set; }
    }
}