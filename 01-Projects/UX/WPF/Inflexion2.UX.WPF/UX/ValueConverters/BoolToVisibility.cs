// --------------------------------------------------------------------------
// <copyright file="BoolToVisibility.cs" company = Company">
//     Copyright (c) 2014. Company All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------

namespace Inflexion2.UX.WPF.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// wpf Boolean converter To Visibility property
    /// </summary>
    public class BoolToVisibility : IValueConverter
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
            bool? valor = value as bool?;

            if (valor == true)
            {
                return "Visible";
            }
            else
            {
                return "Hidden";
            }

        }

        /// <summary>
        /// ConvertBack implementation
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
