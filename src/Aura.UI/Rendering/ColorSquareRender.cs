using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Rendering.SceneGraph;
using Avalonia.Skia;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Rendering
{
    public class ColorSquareRender : AuraDrawOperationBase
    {
        public ColorSquareRender(Rect bounds, IFormattedTextImpl noSkia, Color hueColor, Color strokeColor, int strokeWidth = 10) : base(bounds, noSkia)
        {
            HueColor = hueColor;
            StrokeColor = strokeColor;
            StrokeWidth = strokeWidth;
        }
        public Color HueColor { get; }
        public Color StrokeColor { get; }
        public int StrokeWidth { get; }
        public override void Render(IDrawingContextImpl context)
        {
            var canvas = (context as ISkiaDrawingContextImpl)?.SkCanvas;
            if(canvas == null)
            {
                context.Clear(Colors.White);
                context.DrawText(new SolidColorBrush(Colors.Black), new Point(), NoSkia);
            }
            else 
            {
                var width = (int)Bounds.Width;
                var height = (int)Bounds.Height;

                var info = new SKImageInfo(width,height);
                canvas.Clear();

                using (SKPaint paint = new SKPaint())
                {

                    SKColor[] colors = { SKColors.White, HueColor.ToSKColor() };

                    SKPoint center = new SKPoint(info.Rect.MidX, info.Rect.MidY);

                    paint.Shader = SKShader.CreateLinearGradient(new SKPoint(0, 0), new SKPoint(width, 0), colors, SKShaderTileMode.Repeat);

                    var rect = SKRect.Create(width, height);
                    canvas.DrawRect(rect, paint);
                }

                // Creates the black gradient effect (transparent to black)
                using (SKPaint paint = new SKPaint())
                {
                    SKColor[] colors = { SKColors.Transparent, SKColors.Black };

                    paint.Shader = SKShader.CreateLinearGradient(new SKPoint(0, 0), new SKPoint(0, height), colors, SKShaderTileMode.Repeat);

                    var rect = SKRect.Create(width, height);

                    canvas.DrawRect(rect, paint);
                }

                using (SKPaint paint = new SKPaint())
                {
                    paint.Shader = SKShader.CreateColor(StrokeColor.ToSKColor());
                    var rect = SKRect.Create(width, height);
                    paint.Style = SKPaintStyle.Stroke;
                    paint.StrokeWidth = StrokeWidth;
                    canvas.DrawRect(rect, paint);
                }
            }
        }
    }
}
