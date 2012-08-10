namespace Sparks.Configurations.SettingsConfiguration
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class PubliclyWritablePropertiesParser
    {
        public static IDictionary<string, PropertyInfo> GetPropertiesFor<T>()
        {
            return GetPropertiesFor(typeof (T));
        }

        public static IDictionary<string, PropertyInfo> GetPropertiesFor(Type objectType)
        {
            IDictionary<string, PropertyInfo> dictionary = new Dictionary<string, PropertyInfo>();


            foreach (PropertyInfo propertyInfo in objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!propertyInfo.CanWrite) continue;
                dictionary.Add(propertyInfo.Name, propertyInfo);
            }

            return dictionary;
        }
    }
}