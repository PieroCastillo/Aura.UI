using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Xaml
{
    public class BoxShadowExtension : AvaloniaObject
    {
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var bx = new BoxShadow()
            {
                IsInset = IsInset,
                Blur = BlurRadius,
                Spread = SpreadRadius,
                Color = ShadowColor,
                OffsetX = HorizontalLength,
                OffsetY = VerticalLength
            };
            return new BoxShadows(bx);
        }

        public double HorizontalLength
        {
            get => GetValue(HorizontalLengthProperty);
            set => SetValue(HorizontalLengthProperty, value);
        }
        public readonly static StyledProperty<double> HorizontalLengthProperty = 
            AvaloniaProperty.Register<BoxShadowExtension, double>(nameof(HorizontalLength),0);

        public double VerticalLength
        {
            get => GetValue(VerticalLengthProperty);
            set => SetValue(VerticalLengthProperty, value);
        }
        public readonly static StyledProperty<double> VerticalLengthProperty =
            AvaloniaProperty.Register<BoxShadowExtension, double>(nameof(VerticalLength),0);
        public double BlurRadius
        {
            get => GetValue(BlurRadiusProperty);
            set => SetValue(BlurRadiusProperty, value);
        }
        public readonly static StyledProperty<double> BlurRadiusProperty =
            AvaloniaProperty.Register<BoxShadowExtension, double>(nameof(BlurRadius),5);
        public double SpreadRadius
        {
            get => GetValue(SpreadRadiusProperty);
            set => SetValue(SpreadRadiusProperty, value);
        }
        public readonly static StyledProperty<double> SpreadRadiusProperty =
            AvaloniaProperty.Register<BoxShadowExtension, double>(nameof(SpreadRadius),0);

        public Color ShadowColor
        {
            get => GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }
        public readonly static StyledProperty<Color> ShadowColorProperty =
            AvaloniaProperty.Register<BoxShadowExtension, Color>(nameof(ShadowColor));

        public bool IsInset
        {
            get => GetValue(IsInsetProperty);
            set => SetValue(IsInsetProperty, value);
        }
        public readonly static StyledProperty<bool> IsInsetProperty =
            AvaloniaProperty.Register<BoxShadowExtension, bool>(nameof(IsInset), false);
    }
}
