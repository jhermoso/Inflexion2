namespace Inflexion2.UX.WPF.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Thickness To Double Converter
    /// </summary>
    public class ThicknessToDoubleConverter : IValueConverter
    {
        /// <summary>
        /// IValueConverter implementation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(
                              object value, 
                              Type targetType, 
                              object parameter, 
                              CultureInfo culture)
        {
            var thickness = (Thickness) value;
            return thickness.Left;
        }

        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Método no implementado.")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "CS1591:Missing XML comment for publicly visible type or member", Justification = "Método no implementado.")]

        public object ConvertBack(
                                  object value, 
                                  Type targetType, 
                                  object parameter, 
                                  CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

}