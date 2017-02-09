namespace Inflexion2.UX.WPF.ValueConverters
{

    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// to lower
    /// </summary>
    public class ToLowerConverter : MarkupConverter
    {
        /// <summary>
        /// IValueConverter implementation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as string;
            return val != null ? val.ToLower() : value;
        }

        /// <summary>
        /// IValueConverter implementation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

    }

}