using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using ColorPicker.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.GroupSliders
{
    public class HSVSliderGroup : TemplatedControl
    {
        static HSVSliderGroup()
        {
            HProperty.Changed.AddClassHandler<HSVSliderGroup>((s,e) => { s.Update(); });
            SProperty.Changed.AddClassHandler<HSVSliderGroup>((s, e) => { s.Update(); });
            VProperty.Changed.AddClassHandler<HSVSliderGroup>((s, e) => { s.Update(); });
        }


        public void UpdateFrom(Color color)
        {
            color.ToHSV(out float hue, out byte sat, out byte bht);
            H = hue;
            S = sat;
            V = bht;
            SelectedColor = new Color(color.A, color.R, color.G, color.B);
        }

        public void Update()
        {
            var color = new HSVColor(H.ToFloat(),S.ToFloat(),V.ToFloat());
            SelectedColor = color.ToRGB();
        }

        private double _h;
        public double H
        {
            get => _h;
            set => SetAndRaise(HProperty, ref _h, value);
        }
        public readonly static DirectProperty<HSVSliderGroup, double> HProperty =
            AvaloniaProperty.RegisterDirect<HSVSliderGroup, double>(
                nameof(H),
                o => o.H,
                (o,v) => o.H = v);
        private double _s;
        public double S
        {
            get => _s;
            set => SetAndRaise(SProperty, ref _s, value);
        }
        public readonly static DirectProperty<HSVSliderGroup, double> SProperty =
            AvaloniaProperty.RegisterDirect<HSVSliderGroup, double>(
                nameof(S),
                o => o.S,
                (o, v) => o.S = v);
        private double _v;
        public double V
        {
            get => _v;
            set => SetAndRaise(VProperty, ref _v, value);
        }
        public readonly static DirectProperty<HSVSliderGroup, double> VProperty =
            AvaloniaProperty.RegisterDirect<HSVSliderGroup, double>(
                nameof(V),
                o => o.V,
                (o, v) => o.V = v);

        private Color _selectedColor;
        public Color SelectedColor
        {
            get => _selectedColor;
            private set => SetAndRaise(SelectedColorProperty, ref _selectedColor, value);
        }
        public readonly static DirectProperty<HSVSliderGroup, Color> SelectedColorProperty =
            AvaloniaProperty.RegisterDirect<HSVSliderGroup, Color>(
                nameof(SelectedColor),
                o => o.SelectedColor);
    }
}
