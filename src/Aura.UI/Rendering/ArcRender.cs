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
            int stroke_w, float angle1,
            float angle2,
            Color strokeColor) : base(bounds)
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

        public override void Render(ImmediateDrawingContext drwContext)
        {
            var leaseFeature = drwContext.TryGetFeature<ISkiaSharpApiLeaseFeature>();
            if (leaseFeature == null)
                return;

            using var lease = leaseFeature.Lease();
            var canvas = lease.SkCanvas;

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
}