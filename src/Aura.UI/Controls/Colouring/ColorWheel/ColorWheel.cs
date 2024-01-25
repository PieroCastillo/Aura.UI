using Aura.UI.Rendering;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Aura.UI.Controls.Colouring
{
    public partial class ColorWheel : Control
    {
        public override void Render(DrawingContext context)
        {
            base.Render(context);

            context.Custom(new ColorWheelRender(new Rect(Bounds.Size), StrokeWidth));
        }

        private float _strokewidth = 20;

        public float StrokeWidth
        {
            get => _strokewidth;
            set => SetAndRaise(StrokeWidthProperty, ref _strokewidth, value);
        }

        public readonly static DirectProperty<ColorWheel, float> StrokeWidthProperty =
            AvaloniaProperty.RegisterDirect<ColorWheel, float>(
                nameof(StrokeWidth),
                o => o.StrokeWidth,
                (o, v) => o.StrokeWidth = v);
    }
}