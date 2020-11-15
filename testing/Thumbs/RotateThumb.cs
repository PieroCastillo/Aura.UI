using System;
using System.Diagnostics;
using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using MouseDevice = Windows.Devices.Input.MouseDevice;

namespace Aura.UI.Controls.Thumbs
{
    public class RotateThumb : Thumb
    {
        private Vector vect_s;
        private double last_a;
        private Point mouse_rel;
        private Rect center = Rect.Empty;
        
        protected override void OnDragStarted(VectorEventArgs e)
        {
            base.OnDragStarted(e);

            last_a = AngleValue;
            vect_s = e.Vector;
        }

        // protected override void OnDragDelta(VectorEventArgs e)
        // {
        //     base.OnDragDelta(e);
        //
        //     double aValueBase = last_a + (e.Vector.AngleBetweenExt(vect_s) % 360);
        //     if (aValueBase < 0)
        //         AngleValue = aValueBase + 360;
        //     else
        //         AngleValue = aValueBase;
        //     
        //     #if DEBUG
        //     Debug.WriteLine($"the angle is {AngleValue} degrees");
        //     #endif 
        // }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            base.OnPointerMoved(e);

            mouse_rel = e.GetPosition(this);
        }

        protected override void OnDragDelta(VectorEventArgs e)
        {
            base.OnDragDelta(e);
            
            // Find the angle of which to rotate the shape.  Use the right
            // triangle that uses the center and the mouse's position
            // as vertices for the hypotenuse.

            var pos = mouse_rel;

            double deltaX = e.Vector.X - center.X;
            double deltaY = e.Vector.Y - center.Y;

            if (deltaY.Equals(0))
            {

                return;
            }

            double tan = deltaX / deltaY;
            double angle = Math.Atan(tan);

            // Convert to degrees.
            angle = angle * 180 / Math.PI;

            // If the mouse crosses the vertical center,
            // find the complementary angle.
            if (deltaY > 0)
            {
                angle = 180 - Math.Abs(angle);
            }

            // Rotate left if the mouse moves left and right
            // if the mouse moves right.
            if (deltaX < 0)
            {
                angle = -Math.Abs(angle);
                AngleValue = angle;
            }
            else
            {
                angle = Math.Abs(angle);
                AngleValue = angle;
            }

            if (Double.IsNaN(angle))
            {
                return;
            }
            
            
        }

        private double _anglevalue = 0;
        /// <summary>
        /// Gets or Sets the angle value
        /// </summary>
        public double AngleValue
        {
            get => _anglevalue;
            set => SetAndRaise(AngleValueProperty, ref _anglevalue, value);
        }

        public readonly static DirectProperty<RotateThumb, double> AngleValueProperty =
            AvaloniaProperty.RegisterDirect<RotateThumb, double>(
                nameof(AngleValue),
                o => o.AngleValue,
                (o, v) => o.AngleValue = v);
    }
}