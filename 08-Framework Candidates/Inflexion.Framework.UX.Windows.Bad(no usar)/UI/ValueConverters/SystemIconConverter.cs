// -----------------------------------------------------------------------
// <copyright file="SystemIconConverter.cs" company="Inflexion">
//     Copyright (c) 2012. Inflexion. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Inflexion.Framework.UX.Windows.ValueConverters
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Globalization;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Interop;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Convierte una cadena representando un tipo de icono en una imagen
    /// </summary>
    [ValueConversion(typeof(MessageBoxImage), typeof(BitmapSource))]
    public class SystemIconConverter : IValueConverter
    {
        /// <summary>
        /// Convierte el valor especificado.
        /// </summary>
        /// <param name="value">El valor.</param>
        /// <param name="type">El tipo.</param>
        /// <param name="parameter">El parámetro.</param>
        /// <param name="culture">La cultura.</param>
        /// <returns>Devuelve un BitmapSource con la imagen para mostrar.</returns>
        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {
            try
            {
                var v = (MessageBoxImage)value;
                if (v != MessageBoxImage.None)
                {
                    Icon icon = (Icon)typeof(SystemIcons).GetProperty(v.ToString(), BindingFlags.Public | BindingFlags.Static).GetValue(null, null);
                    BitmapSource bs = Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    return bs;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Método no implementado.")] 
        public object ConvertBack(object value, Type type, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
