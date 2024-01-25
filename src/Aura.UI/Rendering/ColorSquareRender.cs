using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Skia;
using SkiaSharp;

namespace Aura.UI.Rendering
{
    public class ColorSquareRender : AuraDrawOperationBase
    {
        public ColorSquareRender(Rect bounds, Color hueColor, Color strokeColor, int strokeWidth = 10) : base(bounds)
        {
            HueColor = hueColor;
            StrokeColor = strokeColor;
            StrokeWidth = strokeWidth;
        }

        /// <summary>
        /// Returns a color on point
        /// </summary>
        /// <param name="point">the point</param>
        /// <returns>a color</returns>
        public Color HitOn(PixelPoint point)
        {
            if (Surface != null)
            {
                var color_src = Surface.PeekPixels().GetPixelColor(point.X, point.Y);

                return new Color(255, color_src.Red, color_src.Green, color_src.Blue);
            }
            return Colors.White;
        }

        public Color HueColor { get; }
        public Color StrokeColor { get; }
        public int StrokeWidth { get; }

        protected SKSurface Surface { get; set; }

        public override void Render(ImmediateDrawingContext drwContext)
        {
            var leaseFeature = drwContext.TryGetFeature<ISkiaSharpApiLeaseFeature>();
            if (leaseFeature == null)
                return;

            using var lease = leaseFeature.Lease();
            var canvas = lease.SkCanvas;
            var surface = lease.SkSurface;

            Surface = surface;
            var width = (int)Bounds.Width;
            var height = (int)Bounds.Height;

            var info = new SKImageInfo(width, height);

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