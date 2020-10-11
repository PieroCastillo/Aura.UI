using Avalonia;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace ColorPicker.Converters
{
    public class BooleanToNumericConverter : IValueConverter
    {
        public double TrueValue { get; set; }
        public double FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool cond = (bool)value;
            return cond ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO - Probably not a good idea to compare doubles
            double val = (double)value;

            if (val == TrueValue)
                return true;
            if (val == FalseValue)
                return false;

            return AvaloniaProperty.UnsetValue;

        }
    }
}
