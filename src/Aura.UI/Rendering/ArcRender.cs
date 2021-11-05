using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Skia;
using SkiaSharp;
using System.Diagnostics;

namespace Aura.UI.Rendering
{
    public class ArcRender : AuraDrawOperationBase
    {
        public ArcRender(Rect bounds,
            IFormattedTextImpl textImpl,
            int stroke_w, float angle1,
            float angle2,
            Color strokeColor) : base(bounds, textImpl)
        {
            stroke = stroke_w;
            StrokeColor = strokeColor;
            _angle1 = angle1;
            _angle2 = angle2;
        }

        private int stroke;
        private Color StrokeColor;
        private float _angle1;
        private float _angle2;

        public override void Render(IDrawingContextImpl drw_context)
        {
            if (drw_context is ISkiaDrawingContextImpl context)
            {
                var canvas = context.SkCanvas;

                canvas.Save();

                var info = new SKImageInfo((int)Bounds.Width, (int)Bounds.Height);
                var s_r = stroke / 2;
                SKRect rect = new SKRect(s_r, s_r, info.Height - s_r, info.Width - s_r);

                using (var paint = new SKPaint())
                {
                    paint.Shader = SKShader.CreateColor(StrokeColor.ToSKColor());
                    paint.Style = SKPaintStyle.Stroke;
                    paint.StrokeWidth = stroke;
                    paint.IsAntialias = true;
                    paint.Color = StrokeColor.ToSKColor();
                    paint.StrokeCap = SKStrokeCap.Round;
                    canvas.DrawArc(rect, _angle1, _angle2, false, paint);
                }

                canvas.Restore();

                Debug.WriteLine(StrokeColor.ToString());
                Debug.WriteLine("Arc rendered");
            }
        }

        public override bool HitTest(Point p) => true;
    }
}