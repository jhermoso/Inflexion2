// -----------------------------------------------------------------------
// <copyright file="TextToColorConverter.cs"  company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Inflexion2.UX.WPF.ValueConverters
{
    #region Imports

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Windows.Data;

    #endregion

    /// <summary>
    /// Devuelve un color ARGB en hexadecimal dependiendo de los valores recibidos.
    /// </summary>
    public class TextToColorConverter : IValueConverter
    {
        /// <summary>
        /// Devuelve el color "#FFF9B778" si el valor recibido es null, vacío o es igual al parámetro recibido. 
        /// </summary>
        /// <param name="value">
        /// Objeto a comprobar
        /// </param>
        /// <param name="targetType"></param>
        /// <param name="parameter">
        /// Valor con el que se compara el objeto a comprobar.
        /// </param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String colorOk = "Black";
            String colorMandatory = "#FFF9B778";

            if (value == null)
            {
                return colorMandatory;
            }
            else
            {
                if (parameter != null)
                {
                    if (value.Equals(parameter)) { return colorMandatory; }
                }

                if (value is String)
                {
                    if (string.IsNullOrEmpty(((String)value).Trim()))
                    {
                        return colorMandatory;
                    }
                }

                return colorOk;
            }
        }

        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Método no implementado.")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "CS1591:Missing XML comment for publicly visible type or member", Justification = "Método no implementado.")]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("ConvertBack not implemented");
        }

    }
}
