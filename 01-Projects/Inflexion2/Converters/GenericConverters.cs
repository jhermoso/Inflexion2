

namespace Inflexion2.Converters
{
    using System;
    using System.Globalization;

    /// <summary>
    /// public static service class to hols generic converting methods.
    /// </summary>
    public static class GenericConverters
    {
        /// <summary>
        /// http://www.siepman.nl/blog/post/2012/03/06/Convert-to-unknown-generic-type-ChangeType-T.aspx
        /// this method convert from one value to unknown type indicating the culture.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static T ChangeType<T>(this object value, CultureInfo cultureInfo)
        {
            var toType = typeof(T);

            if (value == null) return default(T);

            if (value is string)
            {
                if (toType == typeof(Guid))
                {
                    return ChangeType<T>(new Guid(Convert.ToString(value, cultureInfo)), cultureInfo);
                }
                if ((string)value == string.Empty && toType != typeof(string))
                {
                    return ChangeType<T>(null, cultureInfo);
                }
            }
            else
            {
                if (typeof(T) == typeof(string))
                {
                    return ChangeType<T>(Convert.ToString(value, cultureInfo), cultureInfo);
                }
            }

            if (toType.IsGenericType &&
                toType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                toType = Nullable.GetUnderlyingType(toType); ;
            }

            bool canConvert = toType is IConvertible || (toType.IsValueType && !toType.IsEnum);
            if (canConvert)
            {
                return (T)Convert.ChangeType(value, toType, cultureInfo);
            }
            return (T)value;
        }

        /// <summary>
        /// this method convert from one value to unknown type using the current culture.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ChangeType<T>(this object value)
        {
            return ChangeType<T>(value, CultureInfo.CurrentCulture);
        }
    }
}
