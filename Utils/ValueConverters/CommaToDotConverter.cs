using System.Globalization;
using System.Windows.Data;

namespace MihaganControls.Utils.ValueConverters
{
    public class CommaToDotConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
            {
                string converted = "";

                converted += System.Convert.ToString(d, culture);

                return converted;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s)
            {
                s = s.Replace(',','.');
                

 
                return s;
            }

            return value;
        }
    }
}
