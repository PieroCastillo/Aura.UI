using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Skia;
using SkiaSharp;

namespace Aura.UI.Rendering
{
    public class TriangleWheelRender : AuraDrawOperationBase
    {
        public TriangleWheelRender(Rect bounds, Color hue, float strokeWidth) : base(bounds)
        {
            Hue = hue;
            StrokeWidth = strokeWidth;
            info = new SKImageInfo((int)bounds.Width, (int)bounds.Height);
            // Create the path
            var center = new SKPoint(info.Width / 2, info.Height / 2);
            a = new(info.Width / 2, StrokeWidth);
            b = a.Rotate(center, 120);
            c = b.Rotate(center, 120);
            r = SKMaths.DistanceBetweenTwoPoints(a, b) / 100;
        }

        public override bool HitTest(Point p) => SKMaths.TriangleContains(a, b, c, p.ToSKPoint());

        Color Hue { get; }
        float StrokeWidth { get; }
        SKPoint a, b, c;
        SKImageInfo info;
        float r;

        public override void Render(ImmediateDrawingContext drwContext)
        {
            var leaseFeature = drwContext.TryGetFeature<ISkiaSharpApiLeaseFeature>();
            if (leaseFeature == null)
                return;

            using var lease = leaseFeature.Lease();
            var canvas = lease.SkCanvas;

            int width = (int)Bounds.Width;
            int height = (int)Bounds.Height;

            SKPath path = new SKPath();
            path.MoveTo(a);
            path.LineTo(b);
            path.LineTo(c);
            path.Close();

            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;
                SKColor[] colors = { SKColors.White, SKColors.Transparent };
                paint.Shader = SKShader.CreateRadialGradient(b, r, colors, SKShaderTileMode.Clamp);

                canvas.DrawPath(path, paint);
            }

            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;
                SKColor[] colors = { Hue.ToSKColor(), SKColors.Transparent };
                paint.Shader = SKShader.CreateRadialGradient(a, r, colors, SKShaderTileMode.Clamp);

                canvas.DrawPath(path, paint);
            }

            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;
                SKColor[] colors = { SKColors.Black, SKColors.Transparent };
                paint.Shader = SKShader.CreateRadialGradient(c, r, colors, SKShaderTileMode.Clamp);

                canvas.DrawPath(path, paint);
            }

        }
    }
}
