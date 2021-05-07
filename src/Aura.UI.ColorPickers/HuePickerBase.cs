using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Primitives
{
    public class HuePickerBase : TemplatedControl, IHuePicker
    {
        public Color Hue
        {
            get => GetValue(HueProperty);
            set => SetValue(HueProperty, value);
        }
        public static readonly StyledProperty<Color> HueProperty = 
            AvaloniaProperty.Register<HuePickerBase, Color>(nameof(Hue), Colors.Red);

        public double Saturation
        {
            get => GetValue(SaturationProperty);
            set => SetValue(SaturationProperty, value);
        }

        public static readonly StyledProperty<double> SaturationProperty =
            AvaloniaProperty.Register<HuePickerBase, double>(nameof(Saturation));

        public double ValueColor
        {
            get => GetValue(ValueColorProperty);
            set => SetValue(ValueColorProperty, value);
        }

        public static readonly StyledProperty<double> ValueColorProperty =
            AvaloniaProperty.Register<HuePickerBase, double>(nameof(ValueColor));
    }
}
