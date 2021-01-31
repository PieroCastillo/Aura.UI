using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class ProgressRing
    {
        /// <summary>
        /// Gets or sets if the ProgressRing is Indeterminate
        /// </summary>
        public bool IsIndeterminate
        {
            get => GetValue(IsIndeterminateProperty);
            set => SetValue(IsIndeterminateProperty, value);
        }
        public static readonly StyledProperty<bool> IsIndeterminateProperty =
            AvaloniaProperty.Register<ProgressRing, bool>(nameof(IsIndeterminate), false);

        /// <summary>
        /// The Stroke of the ProgressRing
        /// </summary>
        public int StrokeWidth
        {
            get => GetValue(StrokeWidthProperty);
            set => SetValue(StrokeWidthProperty, value);
        }
        public static readonly StyledProperty<int> StrokeWidthProperty =
            AvaloniaProperty.Register<ProgressRing, int>(nameof(StrokeWidth), 20);

        public Color ForegroundColor
        {
            get => GetValue(ForegroundColorProperty);
            set => SetValue(ForegroundColorProperty, value);
        }
        public readonly static StyledProperty<Color> ForegroundColorProperty =
            AvaloniaProperty.Register<ProgressRing, Color>(nameof(ForegroundColor));

        public Color BackgroundColor
        {
            get => GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }
        public readonly static StyledProperty<Color> BackgroundColorProperty =
            AvaloniaProperty.Register<ProgressRing, Color>(nameof(BackgroundColor));

        private double x_angle;
        public double XAngle
        {
            get => x_angle;
            private set => SetAndRaise(XAngleProperty, ref x_angle, value);
        }
        private readonly static DirectProperty<ProgressRing, double> XAngleProperty =
            AvaloniaProperty.RegisterDirect<ProgressRing, double>(nameof(XAngle), o => o.XAngle);

        private double y_angle;
        public double YAngle
        {
            get => y_angle;
            private set => SetAndRaise(YAngleProperty, ref y_angle, value);
        }
        private readonly static DirectProperty<ProgressRing, double> YAngleProperty =
            AvaloniaProperty.RegisterDirect<ProgressRing, double>(nameof(YAngle), o => o.YAngle);

    }
}
