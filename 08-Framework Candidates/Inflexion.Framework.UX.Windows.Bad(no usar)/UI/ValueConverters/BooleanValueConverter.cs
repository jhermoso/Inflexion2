// -----------------------------------------------------------------------
// <copyright file="BooleanValueConverter.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.ValueConverters
{
    #region Imports

    using System;
    using System.Globalization;
    using System.Windows.Data;

    #endregion

    /// <summary>
    /// Conversor de valores de tipo booleano.
    /// </summary>
    public class BooleanValueConverter : IValueConverter
    {
        #region Fields

        /// <summary>
        /// Referencia a la instancia del conversor.
        /// </summary>
        public static readonly IValueConverter Instance = new BooleanValueConverter();

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
                return "Sí";
            }

            return "No";
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
            return (value is string) &&
                string.Equals(value as string, "Sí", StringComparison.CurrentCultureIgnoreCase);
        }

        #endregion
    }
}