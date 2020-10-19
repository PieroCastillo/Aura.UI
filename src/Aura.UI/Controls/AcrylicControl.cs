using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Aura.UI.Controls
{
    public class AcrylicControl : TemplatedControl
    {
        public double NoiseOpacity
        {
            get => GetValue(NoiseOpacityProperty);
            set => SetValue(NoiseOpacityProperty, value);
        }
        public readonly static StyledProperty<double> NoiseOpacityProperty =
            AvaloniaProperty.Register<AcrylicControl, double>(nameof(NoiseOpacity), 0.5);
        public Color TintColor
        {
            get => GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }
        public readonly static StyledProperty<Color> TintColorProperty =
            AvaloniaProperty.Register<AcrylicControl, Color>(nameof(TintColor));

        public double TintOpacity
        {
            get => GetValue(TintOpacityProperty);
            set => SetValue(TintOpacityProperty, value);
        }
        public readonly static StyledProperty<double> TintOpacityProperty =
            AvaloniaProperty.Register<AcrylicControl, double>(nameof(TintColor));
    
    }
}
