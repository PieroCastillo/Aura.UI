using Avalonia;
using Avalonia.Platform;
using Avalonia.Rendering;
using Avalonia.Skia;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Aura.UI.Rendering
{
    public class BlurImageRender : AuraDrawOperationBase
    {
        public BlurImageRender(Rect src,Rect dest,float levelX, float levelY, IFormattedTextImpl noSkia) : base(src, noSkia)
        {
            _levelx = levelX;
            _levely = levelY;
            _dest = dest;
        }

        Rect _dest;
        float _levelx;
        float _levely;

        public override void Render(IDrawingContextImpl drw_context)
        {
            base.Render(drw_context);

            if(drw_context is ISkiaDrawingContextImpl context)
            {
                var canvas = context.SkCanvas;
                //image.Dispose();

                using (var paint = new SKPaint())
                {
                    //Debug.WriteLine((image == null).ToString());
                    //paint.IsAntialias = true;
                    //paint.Shader = SKShader.CreateImage(image);
                    paint.ImageFilter = SKImageFilter.CreateBlur(_levelx, _levely);
                    //paint.FilterQuality = SKFilterQuality.High;
                    paint.MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Solid, _levelx);
                    //canvas.DrawImage(image, new SKRect(), _dest.ToSKRect(), paint);
                    //var skr = Bounds.ToSKRect();
                    //var bmp = SKBitmap.FromImage(context.SkSurface.Snapshot());
                    //canvas.DrawPaint(paint);
                    //SKRect bmpRect = skr; //new(0, skr.Top, skr.Left, skr.Top);
                    //bmpRect.Inflate(-50, -50);
                    //canvas.DrawBitmap(bmp, bmpRect, paint);
                    canvas.DrawPaint(paint);
                }
            }
        }
    }
}
