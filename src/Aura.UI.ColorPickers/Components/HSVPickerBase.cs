using Aura.UI.ColorPickers.Extensions;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.ColorPickers.Components
{
    public class HSVPickerBase : TemplatedControl
    {
        public virtual void SetColor(Color color)
        {

        }

        public virtual Color GetColor() => new HSV(Hue, Saturation, Value).ToColor();


        private double _Hue;
        public double Hue
        {
            get => _Hue;
            set => SetAndRaise(HueProperty, ref _Hue, value);
        }

        public static readonly DirectProperty<HSVPickerBase, double> HueProperty =
            AvaloniaProperty.RegisterDirect<HSVPickerBase, double>(nameof(Hue), o => o.Hue, (o, v) => o.Hue = v);


        private double _Saturation;
        public double Saturation
        {
            get => _Saturation;
            set => SetAndRaise(SaturationProperty, ref _Saturation, value);
        }

        public static readonly DirectProperty<HSVPickerBase, double> SaturationProperty =
            AvaloniaProperty.RegisterDirect<HSVPickerBase, double>(nameof(Saturation), o => o.Saturation, (o, v) => o.Saturation = v);


        private double _Value;
        public double Value
        {
            get => _Value;
            set => SetAndRaise(ValueProperty, ref _Value, value);
        }

        public static readonly DirectProperty<HSVPickerBase, double> ValueProperty =
            AvaloniaProperty.RegisterDirect<HSVPickerBase, double>(nameof(Value), o => o.Value, (o, v) => o.Value = v);
    }
}
