using Avalonia;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace Aura.UI.Converters
{
    /// <summary>
    /// Converts the bounds of any <see cref="Rect"/> into a <see cref="CornerRadius"/> in order to get a circular control. 
    /// If the width and height differ the smaller value will be used to calculate the <see cref="CornerRadius"/>
    /// </summary>
    public class BoundsToCornerRadiusConverter : IValueConverter
    {
        // a static Instance makes it possible to use this converter without the need of defining a StaticResource
        private static BoundsToCornerRadiusConverter _Instance;

        /// <summary>
        /// A static instance of the <see cref="BoundsToCornerRadiusConverter"/>
        /// </summary>
        public static BoundsToCornerRadiusConverter Instance => _Instance ??= new BoundsToCornerRadiusConverter();


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Rect bounds)
            {
                double minBoundSize = Math.Min(bounds.Width, bounds.Height);
                return new CornerRadius(minBoundSize / 2);
            }
            return new CornerRadius(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
