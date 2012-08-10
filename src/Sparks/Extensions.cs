namespace Sparks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    public static class Extensions
    {
        public static bool IsEmpty(this string stringValue)
        {
            return string.IsNullOrEmpty(stringValue);
        }

        public static bool IsNotEmpty(this string stringValue)
        {
            return !string.IsNullOrEmpty(stringValue);
        }

        public static bool ToBool(this string stringValue)
        {
            return !string.IsNullOrEmpty(stringValue) && bool.Parse(stringValue);
        }

        public static int ToInt(this string stringValue, int defaultValue)
        {
            int retValue = defaultValue;
            int.TryParse(stringValue, out retValue);
            return retValue;
        }

        public static int ToInt32(this string stringValue)
        {
            return stringValue.ToInt(0);
        }

        public static decimal ToDecimal(this string stringValue, decimal defaultValue)
        {
            decimal retValue = defaultValue;
            decimal.TryParse(stringValue, out retValue);
            return retValue;
        }

        public static decimal ToDecimal(this string stringValue)
        {
            return stringValue.ToDecimal(0);
        }

        public static double ToDouble(this string stringValue, double defaultValue)
        {
            double retValue = defaultValue;
            double.TryParse(stringValue, out retValue);
            return retValue;
        }

        public static double ToDouble(this string stringValue)
        {
            return stringValue.ToDouble(0);
        }

        public static DateTime ToDateTime(this string stringValue, DateTime defaultValue)
        {
            DateTime retValue = defaultValue;
            DateTime.TryParse(stringValue, out retValue);
            return retValue;
        }

        public static DateTime ToDateTime(this string stringValue)
        {
            return stringValue.ToDateTime(DateTime.MinValue);
        }

        public static byte[] ToByteArray(this Stream input)
        {
            var buffer = new byte[input.Length];
            input.Position = 0;
            input.Read(buffer, 0, buffer.Length);

            return buffer;
        }

        public static object Convert(this object objToConvert, Type outputType)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(outputType);
            return converter.ConvertFrom(objToConvert);
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}