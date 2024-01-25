using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Rendering.SceneGraph;
using Avalonia.Skia;
using SkiaSharp;
using System.Diagnostics;
using System.IO;

namespace Aura.UI.Rendering
{
    public class BlurImageRender : AuraDrawOperationBase
    {
        public BlurImageRender(MemoryStream data, Rect src, Rect dest, float levelX, float levelY) : base(src)
        {
            _data = data;
            _levelx = levelX;
            _levely = levelY;
            _dest = dest;
        }

        private MemoryStream _data;
        private Rect _dest;
        private float _levelx;
        private float _levely;

        public override void Render(ImmediateDrawingContext drwContext)
        {
            var leaseFeature = drwContext.TryGetFeature<ISkiaSharpApiLeaseFeature>();
            if (leaseFeature == null)
                return;

            using var lease = leaseFeature.Lease();
            var canvas = lease.SkCanvas;

            if (_data == null)
                return;

            using (var bitmap = SKBitmap.Decode(_data.ToArray()))
            using (var paint = new SKPaint())
            {
                if (bitmap == null)
                {
                    Debug.WriteLine("bitmap is null");
                    return;
                }
                var img = SKImage.FromBitmap(bitmap);

                paint.ImageFilter = SKImageFilter.CreateBlur(_levelx, _levely);
                canvas.DrawImage(img, _dest.ToSKRect(), Bounds.ToSKRect(), paint);
            }
        }
    }
}