using Aura.UI.Helpers;
using Avalonia.Data.Converters;
using System;
using System.Globalization;
using Avalonia.Data;

namespace Aura.UI.Converters
{
    public class SideByWidthConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is double)
                return Maths.TriangleHeightBySide((double)value);
            
            return new BindingNotification("Invalid value type");
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
