using Aura.UI.Rendering;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using System.Diagnostics;

namespace Aura.UI.Controls.Colouring
{
    public partial class ColorSquare : Control
    {
        public override void Render(DrawingContext context)
        {
            var render = new ColorSquareRender(Bounds, ColorToRender, StrokeColor, StrokeWidth);
            SquareRender = render;
            context.Custom(render);
        }

        public ColorSquareRender? SquareRender { get; private set; } 

        private Color _lastcolor = Colors.White;

        public Color GetLastColor() => _lastcolor;

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            e.GetCurrentPoint(this).Position.Deconstruct(out double x, out double y);
            
            if(SquareRender is null) return;
            
            Color c = SquareRender.HitOn(new Avalonia.PixelPoint((int)x, (int)y));
            Debug.WriteLine($"The hit color is: \"{c}\" ");
        }
    }
}