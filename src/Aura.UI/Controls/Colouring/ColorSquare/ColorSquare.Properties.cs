using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Colouring
{
    public partial class ColorSquare
    {
        private Color _colortorender = Colors.Red;
        public Color ColorToRender
        {
            get => _colortorender;
            set => SetAndRaise(ColorToRenderProperty, ref _colortorender, value);
        }
        public readonly static DirectProperty<ColorSquare, Color> ColorToRenderProperty =
            AvaloniaProperty.RegisterDirect<ColorSquare, Color>(
                nameof(ColorToRender),
                o => o.ColorToRender,
                (o,v) => o.ColorToRender = v);
    }
}
