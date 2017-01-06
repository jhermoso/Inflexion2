// -----------------------------------------------------------------------
// <copyright file="TimeSpanMinuteSecondValueConverter.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Convierte un valor de tipo TimeSpan a su representación de cadena de minutos : segundos
    /// </summary>
    [ValueConversion(typeof(TimeSpan), typeof(String))]
    public class TimeSpanMinuteSecondValueConverter : IValueConverter
    {
        /// <summary>
        /// Convierte un valor.
        /// </summary>
        /// <param name="value">Valores generados por el enlace de origen.</param>
        /// <param name="targetType">Tipo de la propiedad del destino de enlace.</param>
        /// <param name="parameter">Parámetro de convertidor que se va a usar.</param>
        /// <param name="culture">Referencia cultural que se va a usar en el convertidor.</param>
        /// <returns>Valor convertido.</returns>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:System.Windows.Data.IValueConverter"/>.
        /// </remarks>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TimeSpan))
            {
                return null;
            }

            //return ((TimeSpan)value).ToString(@"mm\:ss", culture);
            return ((TimeSpan)value).TotalSeconds;
        }

        /// <summary>
        /// Convierte un valor.
        /// </summary>
        /// <param name="value">Valores generados por el enlace de origen.</param>
        /// <param name="targetType">Tipo de la propiedad del destino de enlace.</param>
        /// <param name="parameter">Parámetro de convertidor que se va a usar.</param>
        /// <param name="culture">Referencia cultural que se va a usar en el convertidor.</param>
        /// <returns>Valor convertido.</returns>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:System.Windows.Data.IValueConverter"/>.
        /// </remarks>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            if (!(value is double))
            {
                return null;
            }

            return TimeSpan.FromSeconds((double)value);

            //return TimeSpan.ParseExact((string)value, @"mm\:ss", culture);
        }
    }
}
