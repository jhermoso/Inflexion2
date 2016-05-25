using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Inflexion.Framework.UX.Windows.ValueConverters
{
    public class StringStateToPathConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
            var nameImage = value[0] as String;
            var state = value[1] as String;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(String.Format("{0}{1}-{2}.png", "pack://application:,,,/Inflexion.Framework.UX.Windows;component/MVVM/Views/Images/ThreeState/", nameImage, state));
            image.EndInit();
            return image;
            }
            catch
            {
            var nameImage = value[0] as String;
            var state = value[1] as String;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(String.Format("{0}{1}-{2}.png", "pack://application:,,,/Inflexion.Framework.UX.Windows;component/MVVM/Views/Images/ThreeState/", nameImage, "normal"));
            image.EndInit();
            return image;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
