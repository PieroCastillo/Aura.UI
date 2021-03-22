using Aura.UI.Extensions;
using Aura.UI.Rendering;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Aura.UI.Controls
{
    public class BlurryImage : Image
    {
        static BlurryImage()
        {
            AffectsRender<BlurryImage>(BlurLevelProperty, SourceProperty, StretchDirectionProperty, StretchProperty);
            AffectsMeasure<BlurryImage>(BlurLevelProperty, SourceProperty, StretchDirectionProperty, StretchProperty);
        }

        public override void Render(DrawingContext context)
        {
            var stw = Stopwatch.StartNew();
            var source = Source;

            if (source != null && Bounds.Width > 0 && Bounds.Height > 0)
            {
                Rect viewPort = new Rect(Bounds.Size);
                Size sourceSize = source.Size;

                Vector scale = Stretch.CalculateScaling(Bounds.Size, sourceSize, StretchDirection);
                Size scaledSize = sourceSize * scale;
                Rect destRect = viewPort
                    .CenterRect(new Rect(scaledSize))
                    .Intersect(viewPort);
                Rect sourceRect = new Rect(sourceSize)
                    .CenterRect(new Rect(destRect.Size / scale));

                var interpolationMode = RenderOptions.GetBitmapInterpolationMode(this);

                //context.DrawImage(source, sourceRect, destRect, interpolationMode);
                context.Custom(new BlurImageRender(sourceRect, destRect, BlurLevel, BlurLevel, null));
                //Dispatcher.UIThread.InvokeAsync(InvalidateVisual, DispatcherPriority.Background);
            }
            stw.Stop();
            Debug.WriteLine($"Render Time takes {stw.ElapsedMilliseconds} ms too long");
        }

        public float BlurLevel
        {
            get => GetValue(BlurLevelProperty);
            set => SetValue(BlurLevelProperty, value);
        }

        public readonly static StyledProperty<float> BlurLevelProperty =
            AvaloniaProperty.Register<BlurryImage, float>(nameof(BlurLevel), 16);
    }
}
