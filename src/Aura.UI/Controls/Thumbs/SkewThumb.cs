using System;
using System.Diagnostics;
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
            last_x = SkewX + 0;
            last_y = SkewY + 0;
            
            var n_x = last_x + (e.Vector.X / 180 * Math.PI);
            var n_y = last_y + (e.Vector.Y / 180 * Math.PI);

            if (!double.IsNaN(n_x))
            {
                SkewX = Math.Truncate(n_x);
            }

            if (!double.IsNaN(n_y))
            {
                SkewY = Math.Truncate(n_y);
            }
            
            #if DEBUG
            Debug.WriteLine($"Angle X:{SkewX} Angle Y:{SkewY}");
            #endif
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
                (o, v) => o.SkewX = v,
                0);
        
        private double _skewy = 0;
        /// <summary>
        /// Gets or Sets the Skew Y angle
        /// </summary>
        public double SkewY
        {
            get => _skewy;
            set => SetAndRaise(SkewYProperty, ref _skewy, value);
        }

        public readonly static DirectProperty<SkewThumb, double> SkewYProperty =
            AvaloniaProperty.RegisterDirect<SkewThumb, double>(
                nameof(SkewY),
                o => o.SkewY,
                (o, v) => o.SkewY = v,
                0);
    }
}