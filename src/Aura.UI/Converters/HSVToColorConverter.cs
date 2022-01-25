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
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            var h = values[0] != AvaloniaProperty.UnsetValue ? (double)values[0] : 0;
            var s = values[1] != AvaloniaProperty.UnsetValue ? (double)values[1] : 0;
            var v = values[2] != AvaloniaProperty.UnsetValue ? (double)values[2] : 0;

            return new HSV(h, s, v).ToColor();
        }
    }
}
