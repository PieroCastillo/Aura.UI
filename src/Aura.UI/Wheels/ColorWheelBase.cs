using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

using ColorPicker.Structures;

using System;
using System.Diagnostics;
using Point = Avalonia.Point;
using HA = Avalonia.Layout.HorizontalAlignment;
using VA = Avalonia.Layout.VerticalAlignment;


namespace ColorPicker.Wheels
{
    public abstract class ColorWheelBase : Panel
    {
        public static StyledProperty<double> InnerRadiusProperty = AvaloniaProperty.Register<HSVWheel, double>(nameof(InnerRadius));

        public static void OnPropertyChanged(AvaloniaObject obj, AvaloniaPropertyChangedEventArgs args)
        {
            HSVWheel ctl = (obj as HSVWheel);
            ctl.InvalidateVisual();
        }


        public double InnerRadius
        {
            get { return (double)base.GetValue(InnerRadiusProperty); }
            set { base.SetValue(InnerRadiusProperty, value); }
        }


        public double ActualOuterRadius { get; private set; }
        public double ActualInnerRadius { get { return ActualOuterRadius * InnerRadius; } }


        public override void Render(DrawingContext dc)
        {
            base.Render(dc);
            DrawHsvDial(dc);
        }

        /// <summary>
        /// The function used to draw the pixels in the color wheel.
        /// </summary>
        protected RGBStruct ColorFunction(double r, double theta)
        {
            RGBColor rgb = ColorMapping(r, theta, 1.0);
            return new RGBStruct(rgb.Rb, rgb.Gb, rgb.Bb, 255);
        }

        /// <summary>
        /// The color mapping between Rad/Theta and RGB
        /// </summary>
        /// <param name="r">Radius/Saturation, between 0 and 1</param>
        /// <param name="theta">Angle/Hue, between 0 and 360</param>
        /// <returns>The RGB colour</returns>
        public virtual RGBColor ColorMapping(double radius, double theta, double value)
        {
            return new RGBColor(1.0f, 1.0f, 1.0f);
        }

        public virtual Point InverseColorMapping(RGBColor rgb)
        {
            return new Point(0, 0);
        }

        Ellipse border;

        protected void DrawHsvDial(DrawingContext drawingContext)
        {
            float cx = (float)(Bounds.Width) / 2.0f;
            float cy = (float)(Bounds.Height) / 2.0f;

            float outer_radius = (float)Math.Min(cx, cy);
            ActualOuterRadius = outer_radius;

            int bmp_width = (int)Bounds.Width;
            int bmp_height = (int)Bounds.Height;

            if (bmp_width <= 0 || bmp_height <= 0)
                return;


            var stopwatch = new Stopwatch();
            stopwatch.Start();

            //This probably wants to move somewhere else....
            if (border == null)
            {
                border = new Ellipse();
                border.Fill = new SolidColorBrush(Colors.Transparent);
                border.Stroke = new SolidColorBrush(Colors.Gray);
                border.StrokeThickness = 3;
                border.IsHitTestVisible = false;
                border.Opacity = 50;
                this.Children.Add(border);
                border.HorizontalAlignment = HA.Center;
                border.VerticalAlignment = VA.Center;
            }

            border.Width = Math.Min(bmp_width, bmp_height) + (border.StrokeThickness /2);
            border.Height = Math.Min(bmp_width, bmp_height) + (border.StrokeThickness /2);

            var writeableBitmap = new WriteableBitmap(new PixelSize(bmp_width, bmp_height), new Vector(96, 96), PixelFormat.Bgra8888);

            using (var lockedFrameBuffer = writeableBitmap.Lock())
            {
                unsafe
                {
                    IntPtr bufferPtr = new IntPtr(lockedFrameBuffer.Address.ToInt64());

                    for (int y = 0; y < bmp_height; y++)
                    {
                        for (int x = 0; x < bmp_width; x++)
                        {
                            int color_data = 0;

                            // Convert xy to normalized polar co-ordinates
                            double dx = x - cx;
                            double dy = y - cy;
                            double pr = Math.Sqrt(dx * dx + dy * dy);

                            // Only draw stuff within the circle
                            if (pr <= outer_radius)
                            {
                                // Compute the color for the given pixel using polar co-ordinates
                                double pa = Math.Atan2(dx, dy);
                                RGBStruct c = ColorFunction(pr / outer_radius, ((pa + Math.PI) * 180.0 / Math.PI));

                                // Anti-aliasing
                                // This works by adjusting the alpha to the alias error between the outer radius (which is integer) 
                                // and the computed radius, pr (which is float).
                                double aadelta = pr - (outer_radius - 1.0);
                                if (aadelta >= 0.0)
                                    c.a = (byte)(255 - aadelta * 255);

                                color_data = c.ToARGB32();
                            }

                            *((int*)bufferPtr) = color_data;
                            bufferPtr += 4;
                        }
                    }
                }
            }

            drawingContext.DrawImage(writeableBitmap, Bounds);

            stopwatch.Stop();
            Debug.WriteLine($"YO! This puppy took {stopwatch.ElapsedMilliseconds} MS to complete");
        }

    }
}

