using Avalonia.Data.Converters;
using System;
using System.Globalization;
using Avalonia.Data;

namespace Aura.UI.Converters
{
    public class WidthInsideCircularCrown : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is double && parameter is double)
            {
                double total = (double)value;
                double stroke = (double)parameter;
                var r = total - (stroke * 2);

                return r;
            }

            return new BindingNotification("Invalid Parameters");
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
