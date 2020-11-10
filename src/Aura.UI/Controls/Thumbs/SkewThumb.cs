using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;

namespace Aura.UI.Controls.Thumbs
{
    public class SkewThumb : Thumb
    {
        protected override void OnDragDelta(VectorEventArgs e)
        {
            base.OnDragDelta(e);

            double last_x, last_y;
            last_x = SkewX;
            last_y = SkewY;
            SkewX = last_x + e.Vector.X;
            SkewY = last_y + e.Vector.Y;

            var i_ = new ItemsControl();
            i_
        }
        
        private double _skewx = 0;
        /// <summary>
        /// Gets or Sets the Skew X angle
        /// </summary>
        public double SkewX
        {
            get => _skewx;
            set => SetAndRaise(SkewXProperty, ref _skewx, value);
        }

        public readonly static DirectProperty<SkewThumb, double> SkewXProperty =
            AvaloniaProperty.RegisterDirect<SkewThumb, double>(
                nameof(SkewX),
                o => o.SkewX,
                (o, v) => o.SkewX = v);
        
        private double _skewy = 0;
        /// <summary>
        /// Gets or Sets the Skew X angle
        /// </summary>
        public double SkewY
        {
            get => _skewy;
            set => SetAndRaise(SkewYProperty, ref _skewy, value);
        }

        public readonly static DirectProperty<SkewThumb, double> SkewYProperty =
            AvaloniaProperty.RegisterDirect<SkewThumb, double>(
                nameof(SkewX),
                o => o.SkewY,
                (o, v) => o.SkewY = v);
    }
}