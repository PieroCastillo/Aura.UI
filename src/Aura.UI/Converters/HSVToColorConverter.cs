using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Aura.UI.Converters
{
    public class HSVToColorConverter : IMultiValueConverter
    {
        public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Count != 3)
                throw new ArgumentException("The amount of values must be 3");
            
            if (values[0] == AvaloniaProperty.UnsetValue || values[1] == AvaloniaProperty.UnsetValue || values[2] == AvaloniaProperty.UnsetValue)
                return AvaloniaProperty.UnsetValue;
            
            if (values[0] is not double || values[1] is not double || values[2] is not double)
                throw new ArgumentException("The values must be of type double");
            
            var h = values[0] != AvaloniaProperty.UnsetValue ? (double)values[0]! : 0;
            var s = values[1] != AvaloniaProperty.UnsetValue ? (double)values[1]! : 0;
            var v = values[2] != AvaloniaProperty.UnsetValue ? (double)values[2]! : 0;

            return new HSV(h, s, v).ToColor();
        }
    }
}
