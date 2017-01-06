using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WPFLocalizationExtensionDemoApplication.Converters
{
    /// <summary>
    /// https://social.msdn.microsoft.com/Forums/vstudio/en-US/ea1fd63b-738c-40ca-850e-994eb21dccea/binding-to-image-source-via-valueconverter-and-datacontext-in-usercontrol?forum=wpf
    /// </summary>
    public class StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(System.Windows.Media.ImageSource))
                throw new InvalidOperationException("Target type must be System.Windows.Media.ImageSource.");

            if (value != null)
            {
                try
                {
                    string languageIsoCode = ((CultureInfo)value).TwoLetterISOLanguageName;
                    string filePath = "Images/" + languageIsoCode + ".png";
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri(filePath,  UriKind.Relative);
                    img.EndInit();
                    return img;
                }
                catch (Exception)
                {

                    return DependencyProperty.UnsetValue;
                }
                //string languageIsoCode = ((CultureInfo)value).TwoLetterISOLanguageName;
                //return new Uri("Images/" + languageIsoCode + ".png", UriKind.Relative);
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
