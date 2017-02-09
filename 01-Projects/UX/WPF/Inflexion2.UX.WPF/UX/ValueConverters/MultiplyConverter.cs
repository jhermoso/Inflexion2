// -----------------------------------------------------------------------
// <copyright file="MultiplyConverter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// https://github.com/JohanLarsson/So.Wpf/blob/master/So.Wpf/Converters/MultiplyConverter.cs
    /// </summary>
    public class MultiplyConverter : IMultiValueConverter
    {
        /// <summary>
        /// IValueConverter implementation
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double result = 1.0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] is double)
                {
                    result *= (double)values[i];
                }
            }

            return result;
        }

        /// <summary>
        /// IValueConverter implementation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new Exception("Not implemented");
        }
    } 
}
