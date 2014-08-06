
// -----------------------------------------------------------------------
// <copyright file="BooleanActivoValueConverter.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Inflexion2.UX.WPF.ValueConverters
{

    using System;
    using System.Globalization;
    using System.Windows.Data;


    /// <summary>
    /// Clase pública encargada de convertir valores de tipo Date.
    /// </summary>
    /// <remarks>
    /// Sin comentarios adicionales.
    /// </remarks>
    public class BooleanActivoValueConverter : IValueConverter
    {

        #region CONSTRUCTORS

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        public BooleanActivoValueConverter()
        {
        } // BooleanValueConverter Constructor

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Función pública encargada de la conversión de un valor booleano 
        /// a un valor considerado adecuado para la interfaz de usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="value">
        /// Valor a convertir.
        /// </param>
        /// <param name="targetType">
        /// Tipo de valor a convertir.
        /// </param>
        /// <param name="parameter">
        /// Parámetro del valor.
        /// </param>
        /// <param name="culture">
        /// Cultura o idioma de conversión.
        /// </param>
        /// <returns>
        /// Objeto convertido.
        /// </returns>
        public object Convert(
                              object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            if ((bool)value)
            {
                return "ACTIVO";
            }
            return "DESACTIVADO";
        } // Convert

        /// <summary>
        /// Función pública encargada de la conversión de un valor booleano 
        /// a un valor considerado adecuado para la interfaz de usuario.
        /// </summary>
        /// <remarks>
        /// Sin comentarios adicionales.
        /// </remarks>
        /// <param name="value">
        /// Valor a convertir.
        /// </param>
        /// <param name="targetType">
        /// Tipo de valor a convertir.
        /// </param>
        /// <param name="parameter">
        /// Parámetro del valor.
        /// </param>
        /// <param name="culture">
        /// Cultura o idioma de conversión.
        /// </param>
        /// <returns>
        /// Objeto convertido.
        /// </returns>
        public object ConvertBack(
                                  object value,
                                  Type targetType,
                                  object parameter,
                                  CultureInfo culture)
        {
            string s = value as string;
            if (s == "ACTIVO")
            {
                return true;
            }
            return false;
        } // ConvertBack

        #endregion

    } // BooleanValueConverter

} // Company.Product.Shared.SharedCore.UI.MVVM.ValueConverters