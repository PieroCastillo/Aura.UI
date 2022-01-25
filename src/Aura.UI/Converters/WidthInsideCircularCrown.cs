using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace Aura.UI.Converters
{
    public class WidthInsideCircularCrown : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double total = (double)value;
            double stroke = (double)parameter;
            var r = total - (stroke * 2);

            return r;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
