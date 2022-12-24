using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfHW1.Converters
{
    public class QuantityConverter : IValueConverter
    {
        // из источника на форму
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
        // из формы в источник
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value.ToString() == "" || int.TryParse(value.ToString(), out int v))
            {
                return value;
            }
            else
            {
                return 1;
            }
        }
    }
}
