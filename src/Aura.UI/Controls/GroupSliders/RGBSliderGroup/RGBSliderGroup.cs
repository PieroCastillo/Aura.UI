using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.GroupSliders
{
    public class RGBSliderGroup : TemplatedControl
    {
        static RGBSliderGroup()
        {
            RProperty.Changed.AddClassHandler<RGBSliderGroup>((s, e) => { s.Update(); });
            GProperty.Changed.AddClassHandler<RGBSliderGroup>((s, e) => { s.Update(); });
            BProperty.Changed.AddClassHandler<RGBSliderGroup>((s, e) => { s.Update(); });
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            UpdateFrom(PreviewColor);
        }

        public void UpdateFrom(Color color)
        {
            color.Decompose(out _, out byte r, out byte g, out byte b);
            SelectedColor = new Color(255,r, g, b);
        }

        public void Update()
        {
            SelectedColor = new Color(255,R.ToByte(), G.ToByte(), B.ToByte());        
        }


        private double _r;
        public double R
        {
            get => _r;
            set => SetAndRaise(RProperty, ref _r, value);
        }
        public readonly static DirectProperty<RGBSliderGroup, double> RProperty =
            AvaloniaProperty.RegisterDirect<RGBSliderGroup, double>(
                nameof(R),
                o => o.R,
                (o, v) => o.R = v);


        private double _g;
        public double G
        {
            get => _g;
            set => SetAndRaise(GProperty, ref _g, value);
        }
        public readonly static DirectProperty<RGBSliderGroup, double> GProperty =
            AvaloniaProperty.RegisterDirect<RGBSliderGroup, double>(
                nameof(G),
                o => o.G,
                (o, v) => o.G = v);


        private double _b;
        public double B
        {
            get => _b;
            set => SetAndRaise(BProperty, ref _b, value);
        }
        public readonly static DirectProperty<RGBSliderGroup, double> BProperty =
            AvaloniaProperty.RegisterDirect<RGBSliderGroup, double>(
                nameof(B),
                o => o.B,
                (o, v) => o.B = v);

        private Color _selectedColor;
        public Color SelectedColor
        {
            get => _selectedColor;
            private set => SetAndRaise(SelectedColorProperty, ref _selectedColor, value);
        }
        public readonly static DirectProperty<RGBSliderGroup, Color> SelectedColorProperty =
            AvaloniaProperty.RegisterDirect<RGBSliderGroup, Color>(
                nameof(SelectedColor),
                o => o.SelectedColor);

        private Color _previewColor;
        public Color PreviewColor
        {
            get => _previewColor;
            set => SetAndRaise(PreviewColorProperty, ref _previewColor, value);
        }
        public static readonly DirectProperty<RGBSliderGroup, Color> PreviewColorProperty =
            AvaloniaProperty.RegisterDirect<RGBSliderGroup, Color>(
                nameof(PreviewColorProperty),
                o => o.PreviewColor,
                (o, v) => o.PreviewColor = v,
                unsetValue: Colors.White, 
                defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);
    }
}
