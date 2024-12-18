using Avalonia.Controls;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace Aura.UI.Converters
{
    public class IntToColumnDefinitionWidthConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value == null) throw new ArgumentException("value cannot be null");
                
            var v = double.Parse(value.ToString() ?? string.Empty);
            return new GridLength(v, GridUnitType.Pixel);
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}