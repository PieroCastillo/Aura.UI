using Avalonia;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace ColorPicker.Converters
{
    /// <summary>
    /// See http://stackoverflow.com/questions/397556/how-to-bind-radiobuttons-to-an-enum
    /// </summary>
    public class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Equals(true) ? parameter : AvaloniaProperty.UnsetValue;
            ;
        }
    }

}
