using ColorPicker.Structures;
using System;
using System.Windows;
using Point = Avalonia.Point;

namespace ColorPicker.Wheels
{
    public class HSVWheel : ColorWheelBase
    {
        private const double whiteFactor = 2.2; // Provide more accuracy around the white-point

        public override RGBColor ColorMapping(double radius, double theta, double value)
        {
            HSVColor hsv = new HSVColor((float)theta, (float)Math.Pow(radius, whiteFactor), (float)value);
            RGBColor rgb = hsv.ToRGB();
            return rgb;
        }

        public override Point InverseColorMapping(RGBColor rgb)
        {
            double theta, rad;
            HSVColor hsv = (HSVColor)rgb;
            theta = hsv.hue;
            rad = Math.Pow(hsv.sat, 1.0 / whiteFactor);

            return new Point(theta, rad);
        }
    }
}
