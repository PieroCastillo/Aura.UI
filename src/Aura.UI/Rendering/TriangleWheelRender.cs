using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Skia;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Rendering
{
    public class TriangleWheelRender : AuraDrawOperationBase
    {
        public TriangleWheelRender(Rect bounds, Color hue, IFormattedTextImpl noSkia) : base(bounds, noSkia)
        {
            Hue = hue;
        }

        public override bool HitTest(Point p) => Helpers.Maths.TriangleContains(new(0.5f * Bounds.Width, 0), new(0f, Bounds.Height), new(Bounds.Width, Bounds.Height), p);
       

        Color Hue { get; }

        public override void Render(IDrawingContextImpl drw_context)
        {
            base.Render(drw_context);

            if (drw_context is ISkiaDrawingContextImpl context)
            {
                var canvas = context.SkCanvas;

                int width = (int)Bounds.Width;
                int height = (int)Bounds.Height;

                var info = new SKImageInfo(width, height);
                // Create the path
                SKPath path = new SKPath();

                path.MoveTo(0.5f * info.Width, 0);
                path.LineTo(0f, info.Height);
                path.LineTo(info.Width, info.Height);
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
                    paint.Shader = SKShader.CreateRadialGradient(new SKPoint(0, height), width, colors, SKShaderTileMode.Clamp);

                    canvas.DrawPath(path, paint);
                }

                using (SKPaint paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    SKColor[] colors = { SKColors.Black, SKColors.Transparent };
                    paint.Shader = SKShader.CreateRadialGradient(new SKPoint(width, height), height, colors, SKShaderTileMode.Clamp);

                    canvas.DrawPath(path, paint);
                }
            }
        }
    }
}
