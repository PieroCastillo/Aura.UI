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
        public TriangleWheelRender(Rect bounds, Color hue, double lateralSize, IFormattedTextImpl noSkia) : base(bounds, noSkia)
        {
            Hue = hue;
        }

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
                    //SKColor[] colors = { SKColors.Red, SKColors.Transparent};
                    paint.Color = Hue.ToSKColor();
                    var rect = SKRect.Create(width, height);

                    canvas.DrawPath(path, paint);
                }

                using (SKPaint paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    SKColor[] colors = { SKColors.White, SKColors.Transparent };

                    paint.Shader = SKShader.CreateRadialGradient(new SKPoint(0, height), width, colors, SKShaderTileMode.Clamp);
                    //paint.Color = SKColors.White;

                    var rect = SKRect.Create(width, height);

                    canvas.DrawPath(path, paint);
                }

                using (SKPaint paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    SKColor[] colors = { SKColors.Black, SKColors.Transparent };

                    paint.Shader = SKShader.CreateRadialGradient(new SKPoint(width, height), height, colors, SKShaderTileMode.Clamp);

                    var rect = SKRect.Create(width, height);

                    canvas.DrawPath(path, paint);
                }
            }
        }
    }
}
