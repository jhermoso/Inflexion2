
namespace Inflexion.Framework.UX.Windows.ValueConverters
{

    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    public class SelectedToColorConverter: IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

           if (value == null)
           {
               return "#FFF9B778";
           }
           else
           {
               return "Black";
           }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("ConvertBack not implemented");
        }

    }
}
