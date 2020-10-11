using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using ColorPicker.Structures;
using System;
using System.Globalization;

namespace ColorPicker.Converters
{
    public class RGBColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is RGBColor color)
            {
                return new SolidColorBrush(color);
            }
            else
            {
                return AvaloniaProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
                return new RGBColor(brush.Color.R, brush.Color.G, brush.Color.B);
            }
            else
            {
                return AvaloniaProperty.UnsetValue;
            }
        }
    }
}
