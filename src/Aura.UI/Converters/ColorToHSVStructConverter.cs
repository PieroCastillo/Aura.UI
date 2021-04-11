using Aura.UI.Helpers;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Aura.UI.Converters
{
    public class ColorToHSVStructConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            =>  new HSVStruct((Color)value);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => Extensions.ColorExtensions.FromHSV((HSVStruct)value);
    }

    public class HSVToColorMultiConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var h = float.Parse((string)values[0]);
                var s = byte.Parse((string)values[1]);
                var v = byte.Parse((string)values[2]);

                return Extensions.ColorExtensions.FromHSV((float)h, (byte)s, v);
            }
            catch
            {
                return new HSVStruct(Colors.Yellow);
            }
        }
    }
}
