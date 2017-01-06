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

    public class BoolToVisibility : IValueConverter
    {

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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("ConvertBack not implemented");
        }

    }
}
