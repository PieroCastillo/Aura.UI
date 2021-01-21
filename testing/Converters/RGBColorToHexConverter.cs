using Avalonia;
using Avalonia.Data.Converters;
using ColorPicker.Structures;
using System;
using System.Globalization;

namespace ColorPicker.Converters
{
    public class RGBColorToHexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is RGBColor color)
            {
                return color.ToHexRGB();
            }
            else
            {
                return AvaloniaProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AvaloniaProperty.UnsetValue;
        }
    }
}
