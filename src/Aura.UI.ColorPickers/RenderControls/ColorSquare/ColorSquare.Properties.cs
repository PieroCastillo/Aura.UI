using Avalonia;
using Avalonia.Media;

namespace Aura.UI.ColorPickers.RenderControls
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
                (o, v) => o.ColorToRender = v);

        private Color _strokecolor = Colors.Gray;

        public Color StrokeColor
        {
            get => _strokecolor;
            set => SetAndRaise(StrokeColorProperty, ref _strokecolor, value);
        }

        public readonly static DirectProperty<ColorSquare, Color> StrokeColorProperty =
            AvaloniaProperty.RegisterDirect<ColorSquare, Color>(
                nameof(StrokeColor),
                o => o.StrokeColor,
                (o, v) => o.StrokeColor = v);

        private int _strokewidth = 5;

        public int StrokeWidth
        {
            get => _strokewidth;
            set => SetAndRaise(StrokeWidthProperty, ref _strokewidth, value);
        }

        public readonly static DirectProperty<ColorSquare, int> StrokeWidthProperty =
            AvaloniaProperty.RegisterDirect<ColorSquare, int>(
                nameof(StrokeWidth),
                o => o.StrokeWidth,
                (o, v) => o.StrokeWidth = v);
    }
}