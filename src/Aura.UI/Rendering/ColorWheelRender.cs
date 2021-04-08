﻿using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Skia;
using SkiaSharp;
using System;

namespace Aura.UI.Rendering
{
    public class ColorWheelRender : AuraDrawOperationBase
    {
        public ColorWheelRender(Rect bounds, IFormattedTextImpl noSkia, float strokeWidth = 20) : base(bounds, noSkia)
        {
            StrokeWidth = strokeWidth;
        }

        public float StrokeWidth { get; }

        //public override bool HitTest(Point p)
        //{
        //    return Helpers.Maths.CircularCrownContainsPoint(p, Bounds.Center, (Bounds.Width / 2 - StrokeWidth), Bounds.Width / 2);
        //}

    public override void Render(IDrawingContextImpl context)
        {
            // converts the impl to SKCanvas
            var canvas = (context as ISkiaDrawingContextImpl)?.SkCanvas;
            //Checks if that is valid
            if (canvas == null)
            {
                context.Clear(Colors.White);
                context.DrawText(new SolidColorBrush(Colors.Black), new Point(), NoSkia);
            }
            else // when it's valid to this
            {
                var info = new SKImageInfo((int)Bounds.Width, (int)Bounds.Height); // creates the image info

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
}