using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Skia;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Aura.UI.Rendering
{
    public class TriangleWheelRender : AuraDrawOperationBase
    {
        public TriangleWheelRender(Rect bounds, Color hue, IFormattedTextImpl noSkia, float strokeWidth) : base(bounds, noSkia)
        {
            Hue = hue;
            StrokeWidth = strokeWidth;
            info = new SKImageInfo((int)bounds.Width, (int)bounds.Height);
                // Create the path
            var center = new SKPoint(info.Width / 2, info.Height / 2);
            a = new(info.Width / 2, StrokeWidth);
            b = a.Rotate(center, 120);
            c = b.Rotate(center, 120);
        }

        public override bool HitTest(Point p) => SKMaths.TriangleContains(a, b, c, p.ToSKPoint());

        Color Hue { get; }
        float StrokeWidth { get; }
        SKPoint a, b, c;
        SKImageInfo info;

        public override void Render(IDrawingContextImpl drw_context)
        {
            base.Render(drw_context);

            if (drw_context is ISkiaDrawingContextImpl context)
            {
                var canvas = context.SkCanvas;

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
                    paint.Color = Hue.ToSKColor();

                    canvas.DrawPath(path, paint);
                }

                using (SKPaint paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    SKColor[] colors = { SKColors.White, SKColors.Transparent };
                    paint.Shader = SKShader.CreateRadialGradient(b, width, colors, SKShaderTileMode.Clamp);

                    canvas.DrawPath(path, paint);
                }

                using (SKPaint paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    SKColor[] colors = { SKColors.Black, SKColors.Transparent };
                    paint.Shader = SKShader.CreateRadialGradient(c, height, colors, SKShaderTileMode.Clamp);

                    canvas.DrawPath(path, paint);
                }
            }
        }
    }
}
