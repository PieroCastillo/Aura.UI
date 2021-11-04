using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Painting
{
    public class AuraColorPicker : TemplatedControl
    {
        private Color _SelectedColor;
        public Color SelectedColor
        {
            get => _SelectedColor;
            set => SetAndRaise(SelectedColorProperty, ref _SelectedColor, value);
        }

        public static readonly DirectProperty<AuraColorPicker, Color> SelectedColorProperty =
            AvaloniaProperty.RegisterDirect<AuraColorPicker, Color>(nameof(SelectedColor), o => o.SelectedColor, (o, v) => o.SelectedColor = v);



        public double StrokeWidth
        {
            get => GetValue(StrokeWidthProperty);
            set => SetValue(StrokeWidthProperty, value);
        }

        public static readonly StyledProperty<double> StrokeWidthProperty =
            AvaloniaProperty.Register<AuraColorPicker, double>(nameof(StrokeWidth), 10);


    }
}
