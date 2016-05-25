// -----------------------------------------------------------------------
// <copyright file="BooleanToVisibilityConverter.cs" company="I+3 Televisión">
//     Copyright (c) 2012. I+3 Televisión. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace I3TV.Framework.Windows.UI.Controls.Converters
{
    #region Imports

    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    #endregion

    /// <summary>
    /// Conversor de valores de tipo booleano a estado de presentación de un elemento, y viceversa.
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        #region Fields

        /// <summary>
        /// Referencia a la instancia del conversor.
        /// </summary>
        public static readonly IValueConverter Instance = new BooleanToVisibilityConverter();

        #endregion

        #region Public Methods

        /// <summary>
        /// Convierte un valor.
        /// </summary>
        /// <param name="value">
        /// Valores generados por el enlace de origen.
        /// </param>
        /// <param name="targetType">
        /// Tipo de la propiedad del destino de enlace.
        /// </param>
        /// <param name="parameter">
        /// Parámetro de convertidor que se va a usar.
        /// </param>
        /// <param name="culture">
        /// Referencia cultural que se va a usar en el convertidor.
        /// </param>
        /// <returns>
        /// Valor convertido.
        /// </returns>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:System.Windows.Data.IValueConverter"/>.
        /// </remarks>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && (bool)value)
            {
                return Visibility.Visible;
            }

            return Visibility.Hidden;
        }

        /// <summary>
        /// Convierte un valor.
        /// </summary>
        /// <param name="value">
        /// Valor que genera el destino de enlace.
        /// </param>
        /// <param name="targetType">
        /// Tipo en el que se va a convertir.
        /// </param>
        /// <param name="parameter">
        /// Parámetro de convertidor que se va a usar.
        /// </param>
        /// <param name="culture">
        /// Referencia cultural que se va a usar en el convertidor.
        /// </param>
        /// <returns>
        /// Valor convertido.
        /// </returns>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:System.Windows.Data.IValueConverter"/>.
        /// </remarks>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}