
namespace Inflexion2.UX.WPF.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// wpf Selected Color Converter
    /// </summary>
    public class SelectedToColorConverter: IValueConverter
    {
        /// <summary>
        /// IValueConverter implementation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

           if (value == null)
           {
               return "#FFF9B778";
           }
           else
           {
               return "Black";
           }

        }

        /// <summary>
        /// IValueConverter implementation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("ConvertBack not implemented");
        }

    }
}
