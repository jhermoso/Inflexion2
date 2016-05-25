namespace Inflexion.Framework.UX.Windows.ValueConverters
{

    using System;
    using System.Globalization;
    using System.Windows.Data;


    public class OffOnConverter : IValueConverter
    {

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public OffOnConverter()
        {
            this.ValueTrue = "On";
            this.ValueFalse = "Off";
        } // OffOnConverter Constructor

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="valueTrue">Valor mostrado cuando vale <c>true</c>.</param>
        /// <param name="valueFalse">Valor mostrado cuando vale <c>false</c>.</param>
        public OffOnConverter(
                              string valueTrue,
                              string valueFalse)
        {
            this.ValueTrue = valueTrue;
            this.ValueFalse = valueFalse;
        } // OffOnConverter Constructor

        private string ValueTrue { get; set; }
        private string ValueFalse { get; set; }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(
                              object value, 
                              Type targetType, 
                              object parameter, 
                              CultureInfo culture)
        {
            if (value is bool? || 
                value == null)
            {
                return (bool?)value == true ? this.ValueTrue : this.ValueFalse;
            }
            return this.ValueFalse;
        } // Convert

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <param name="valueTrue">Valor mostrado cuando vale <c>true</c>.</param>
        /// <param name="valueFalse">Valor mostrado cuando vale <c>false</c>.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(
                              object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture,
                              string valueTrue,
                              string valueFalse)
        {
            if (value is bool? ||
                value == null)
            {
                return (bool?)value == true ? valueTrue : valueFalse;
            }
            return valueFalse;
        } // Convert

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object ConvertBack(
                                  object value, 
                                  Type targetType, 
                                  object parameter, 
                                  CultureInfo culture)
        {
            throw new NotImplementedException();
        } // ConvertBack

    } // OffOnConverter

} // Inflexion.Framework.UX.Windows.ValueConverters