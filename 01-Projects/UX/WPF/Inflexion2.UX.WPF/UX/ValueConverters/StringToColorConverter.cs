// -----------------------------------------------------------------------
// <copyright file="ColorToSolidColorBrushConverter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.ValueConverters
{
    using System;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class StringToColorConverter : IValueConverter
    {
        /// <summary>
        /// color converter
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null == value)
            {
                return null;
            }

            if (value is string)
            {
                if (string.IsNullOrEmpty(value as string))
                {
                    return null;
                }

                return (Color)ColorConverter.ConvertFromString(value as string);
            }
            
            // You can support here more source types if you wish
            // For the example I throw an exception
            Type type = value.GetType();
            throw new InvalidOperationException("Unsupported type [" + type.Name + "]");
        }

        /// <summary>
        /// inverted conversion
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (null == value)
            {
                return null;
            }

            if (value is Color)
            {
                return ((Color)value).ToString();
            }

            // You can support here more source types if you wish
            // For the example I throw an exception
            Type type = value.GetType();
            throw new InvalidOperationException("Unsupported type [" + type.Name + "]");
        }
    }
}
