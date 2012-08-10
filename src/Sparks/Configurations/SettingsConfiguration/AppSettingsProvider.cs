namespace Sparks.Configurations.SettingsConfiguration
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class AppSettingsProvider : ISettingsProvider
    {
        #region ISettingsProvider Members

        public T SettingsFor<T>() where T : class, new()
        {
            Type settingsType = typeof (T);
            object value = SettingsFor(settingsType);

            return (T) value;
        }

        public object SettingsFor(Type settingsType)
        {
            IDictionary<string, PropertyInfo> properties =
                PubliclyWritablePropertiesParser.GetPropertiesFor(settingsType);
            object objToReturn = Activator.CreateInstance(settingsType);

            foreach (var propertyInfo in properties)
            {
                Type outputType = propertyInfo.Value.PropertyType;

                object value = AppSettingsData.GetValue(settingsType.Name + "." + propertyInfo.Key);
                if (value == null) continue;

                propertyInfo.Value.SetValue(objToReturn, value.Convert(outputType), null);
            }

            return objToReturn;
        }

        #endregion
    }

    public interface ISettingsProvider
    {
        T SettingsFor<T>() where T : class, new();
        object SettingsFor(Type settingsType);
    }
}