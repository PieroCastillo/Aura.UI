using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Skia;
using SkiaSharp;
using System;

namespace Aura.UI.Rendering
{
    public class ColorWheelRender : AuraDrawOperationBase
    {
        public ColorWheelRender(Rect bounds, float strokeWidth = 20) : base(bounds)
        {
            StrokeWidth = strokeWidth;
        }

        public float StrokeWidth { get; }

        public override void Render(ImmediateDrawingContext drwContext)
        {
            var leaseFeature = drwContext.TryGetFeature<ISkiaSharpApiLeaseFeature>();
            if (leaseFeature == null)
                return;

            using var lease = leaseFeature.Lease();
            var canvas = lease.SkCanvas;

            var info = new SKImageInfo((int)Bounds.Width, (int)Bounds.Height); // creates the image info
            canvas.RotateDegrees(-90, (float)Bounds.Center.X, (float)Bounds.Center.Y);

            using (SKPaint paint = new SKPaint()) // creates the paint
            {
                // Define an array of rainbow colors
                SKColor[] colors = new SKColor[8];

                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i] = SKColor.FromHsl(i * 360f / 7, 100, 50); //sets the colors
                }

                SKPoint center = new SKPoint(info.Rect.MidX, info.Rect.MidY); // creates the center

                paint.IsAntialias = true;

                // Create sweep gradient based on center of canvas
                paint.Shader = SKShader.CreateSweepGradient(center, colors, null);

                // Draw a circle with a wide line
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = StrokeWidth;

                float radius = (Math.Min(info.Width, info.Height) - StrokeWidth) / 2; //computes the radius
                canvas.DrawCircle(center, radius, paint); // draw a circle with its respects parameters
            }
        }
    }
}