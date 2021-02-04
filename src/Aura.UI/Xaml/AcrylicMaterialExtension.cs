using Avalonia;
using Avalonia.Media;
using System;

namespace Aura.UI.Xaml
{
    public class AcrylicMaterialExtension : AvaloniaObject
    {
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ExperimentalAcrylicMaterial
            {
                TintColor = TintColor,
                FallbackColor = FallBackColor,
                TintOpacity = TintOpacity,
                MaterialOpacity = MaterialOpacity,
                BackgroundSource = this.AcrylicBackgroundSource
            };
        }

        public Color TintColor
        {
            get => GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }

        public readonly static StyledProperty<Color> TintColorProperty =
            AvaloniaProperty.Register<AcrylicMaterialExtension, Color>(nameof(TintColor));

        public Color FallBackColor
        {
            get => GetValue(FallBackColorProperty);
            set => SetValue(FallBackColorProperty, value);
        }

        public readonly static StyledProperty<Color> FallBackColorProperty =
            AvaloniaProperty.Register<AcrylicMaterialExtension, Color>(nameof(FallBackColor));

        public double TintOpacity
        {
            get => GetValue(TintOpacityProperty);
            set => SetValue(TintOpacityProperty, value);
        }

        public readonly static StyledProperty<double> TintOpacityProperty =
            AvaloniaProperty.Register<AcrylicMaterialExtension, double>(nameof(TintOpacity));

        public double MaterialOpacity
        {
            get => GetValue(MaterialOpacityProperty);
            set => SetValue(MaterialOpacityProperty, value);
        }

        public readonly static StyledProperty<double> MaterialOpacityProperty =
            AvaloniaProperty.Register<AcrylicMaterialExtension, double>(nameof(MaterialOpacity));

        public AcrylicBackgroundSource AcrylicBackgroundSource
        {
            get => GetValue(AcrylicBackgroundSourceProperty);
            set => SetValue(AcrylicBackgroundSourceProperty, value);
        }

        public readonly static StyledProperty<AcrylicBackgroundSource> AcrylicBackgroundSourceProperty =
            AvaloniaProperty.Register<AcrylicMaterialExtension, AcrylicBackgroundSource>(nameof(AcrylicBackgroundSource), AcrylicBackgroundSource.Digger);
    }
}