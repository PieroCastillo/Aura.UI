using Aura.UI.Controls.Colouring;
using Aura.UI.Extensions;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Media;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;
using System.Diagnostics;
using Aura.UI.Controls.Thumbs;

namespace Aura.UI.Controls
{
    public class ColorSquarePicker : TemplatedControl
    {
        protected ColorSquare colorsquare;
        protected Thumb thumb;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            colorsquare = this.GetControl<ColorSquare>(e, "PART_Square");
            thumb = this.GetControl<MoveThumb>(e, "PART_Thumb");
            thumb.PointerPressed += Thumb_PointerPressed;

        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            e.GetCurrentPoint(this).Position.Deconstruct(out double x, out double y);
            Debug.WriteLine("Deconstructed on pressed");
            Canvas.SetTop(thumb, y);
            Canvas.SetLeft(thumb, x);
            UpdateColor(e);
        }

        private void Thumb_PointerPressed(object sender, PointerPressedEventArgs e)
        {
            UpdateColor(e);
            e.Handled = false;
        }

        void UpdateColor(PointerEventArgs e)
        {
            Color.Decompose(out _, out byte r, out byte g, out byte b);

            e.GetCurrentPoint(this).Position.Deconstruct(out double x, out double y);

            var h = Color.GetHue();
            var s = (byte)(100 * x / Bounds.Width);
            var v = (byte)(100 * y / Bounds.Height);

            Debug.WriteLine($"r: {r}, g: {g}, b: {b}");
            Debug.WriteLine($"h: {h}, s: {s}, v: {v}");
            Debug.WriteLine("");

            ModifiedColor = Color.FromHSV(h, s, v);
            thumb.Background = new SolidColorBrush(ModifiedColor);
            Debug.WriteLine($"{ModifiedColor.ToString()}");
        }

        private Color _color = Colors.Red;
        public Color Color
        {
            get => _color;
            set => SetAndRaise(ColorProperty, ref _color, value);
        }
        public readonly static DirectProperty<ColorSquarePicker, Color> ColorProperty =
            AvaloniaProperty.RegisterDirect<ColorSquarePicker, Color>(
                nameof(Color),
                o => o.Color,
                (o,v) => o.Color = v);

        private Color _modifiedcolor = Colors.White;
        public Color ModifiedColor
        {
            get => _modifiedcolor;
            private set => SetAndRaise(ModifiedColorProperty, ref _modifiedcolor, value);
        }
        public readonly static DirectProperty<ColorSquarePicker, Color> ModifiedColorProperty =
            AvaloniaProperty.RegisterDirect<ColorSquarePicker, Color>(nameof(ModifiedColor), o => o.ModifiedColor);
    }
}
