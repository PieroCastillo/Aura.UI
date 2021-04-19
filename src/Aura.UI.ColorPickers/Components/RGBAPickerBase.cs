using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.ColorPickers.Components
{
    public class RGBAPickerBase : TemplatedControl
    {
        public virtual void SetColor(Color color) { }
        public virtual Color GetColor() => Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue);

        private double _Red;
        public double Red
        {
            get => _Red;
            set => SetAndRaise(RedProperty, ref _Red, value);
        }

        public static readonly DirectProperty<RGBAPickerBase, double> RedProperty =
            AvaloniaProperty.RegisterDirect<RGBAPickerBase, double>(nameof(Red), o => o.Red, (o, v) => o.Red = v);


        private double _Green;
        public double Green
        {
            get => _Green;
            set => SetAndRaise(GreenProperty, ref _Green, value);
        }

        public static readonly DirectProperty<RGBAPickerBase, double> GreenProperty =
            AvaloniaProperty.RegisterDirect<RGBAPickerBase, double>(nameof(Green), o => o.Green, (o, v) => o.Green = v);


        private double _Blue;
        public double Blue
        {
            get => _Blue;
            set => SetAndRaise(BlueProperty, ref _Blue, value);
        }

        public static readonly DirectProperty<RGBAPickerBase, double> BlueProperty =
            AvaloniaProperty.RegisterDirect<RGBAPickerBase, double>(nameof(Blue), o => o.Blue, (o, v) => o.Blue = v);


        private double _Alpha;
        public double Alpha
        {
            get => _Alpha;
            set => SetAndRaise(AlphaProperty, ref _Alpha, value);
        }

        public static readonly DirectProperty<RGBAPickerBase, double> AlphaProperty =
            AvaloniaProperty.RegisterDirect<RGBAPickerBase, double>(nameof(Alpha), o => o.Alpha, (o, v) => o.Alpha = v);


    }
}
