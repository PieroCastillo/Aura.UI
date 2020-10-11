using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace ColorPicker.Converters
{
    /// <summary>
    /// Turns a linear-scaled slider (0.0 to 1.0) into a logarithmic value,
    /// defined by Minimum and Maximum.
    /// The logarithm is in base 10, so for best results Minimum & Maximum should be a power of 10.
    /// </summary>
    public class LogarithmicConverter : IValueConverter
    {
        public double Maximum
        {
            get { return linMax; }
            set { linMax = value; logMax = Math.Log10(value); }
        }
        public double Minimum
        {
            get { return linMin; }
            set { linMin = value; logMin = Math.Log10(value); }
        }

        // Cached values
        private double linMin;
        private double linMax;
        private double logMin;
        private double logMax;

        public object Convert(object _value, Type targetType, object parameter, CultureInfo culture)
        {
            double scale = (logMax - logMin);
            double value = (double)_value;

            return (Math.Log10(value) - logMin) / scale;
        }

        public object ConvertBack(object _value, Type targetType, object parameter, CultureInfo culture)
        {
            double scale = (logMax - logMin);
            double value = (double)_value;

            return Math.Pow(10.0, logMin + scale * value);
        }
    }
}
