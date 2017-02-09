﻿namespace Inflexion2.UX.WPF.ValueConverters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// use an image to show an item with 3 status
    /// </summary>
    public class StringStateToPathConverter : IMultiValueConverter
    {
        /// <summary>
        /// IMultiValueConverter implementation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var nameImage = value[0] as String;
                var state = value[1] as String;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(String.Format("{0}{1}-{2}.png", "pack://application:,,,/Inflexion2.UX.WPF;component/MVVM/Views/Images/ThreeState/", nameImage, state));
                image.EndInit();
                return image;
            }
            catch
            {
                var nameImage = value[0] as String;
                var state = value[1] as String;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(String.Format("{0}{1}-{2}.png", "pack://application:,,,/Inflexion2.UX.WPF;component/MVVM/Views/Images/ThreeState/", nameImage, "normal"));
                image.EndInit();
                return image;
            }
        }

        /// <summary>
        /// IMultiValueConverter implementation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
