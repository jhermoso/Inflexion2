// -----------------------------------------------------------------------
// <copyright file="InvertedBooleanToVisibilityCollapsedConverter.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion2.UX.WPF.ValueConverters
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
    public class InvertedBooleanToVisibilityCollapsedConverter : IValueConverter
    {
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
        /// collapsed if value is true or not boolean, visible if value is false.
        /// </returns>
        /// <remarks>
        /// Miembro de la interfaz <see cref="T:System.Windows.Data.IValueConverter"/>.
        /// </remarks>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return (bool)value ?   Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Visible;
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