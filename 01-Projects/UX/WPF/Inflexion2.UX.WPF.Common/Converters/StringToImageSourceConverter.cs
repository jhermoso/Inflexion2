

namespace Inflexion2.UX.WPF.ValueConverters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;
    using WPFLocalizeExtension.Engine;

    /// <summary>
    /// https://social.msdn.microsoft.com/Forums/vstudio/en-US/ea1fd63b-738c-40ca-850e-994eb21dccea/binding-to-image-source-via-valueconverter-and-datacontext-in-usercontrol?forum=wpf
    /// </summary>
    public class StringToImageSourceConverter : IValueConverter
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
            if (targetType != typeof(System.Windows.Media.ImageSource))
                throw new InvalidOperationException("Target type must be System.Windows.Media.ImageSource.");

            if (value != null)
            {
                try
                {
                    Type t = value.GetType();
                    var cultureInfo = value as CultureInfo;

                    string region2ISOcode = cultureInfo.TwoLetterISOLanguageName;
                    
                    
                    //string filePath = "Images/" + region2ISOcode + ".png";
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    //img.UriSource = new Uri(filePath,  UriKind.Relative);
                    img.UriSource = new Uri(String.Format("{0}{1}.png", "pack://application:,,,/Inflexion2.UX.WPF;component/MVVM/Views/Images/LanguageFlags/", region2ISOcode/*, state*/));

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

        /// <summary>
        /// IValueConverter implementation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
