using Avalonia;
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace ColorPicker.Converters
{
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format((string)parameter, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do nothing
            return AvaloniaProperty.UnsetValue;
        }
    }
}
