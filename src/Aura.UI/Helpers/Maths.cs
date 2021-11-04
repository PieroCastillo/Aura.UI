using Avalonia;
using Avalonia.Media;
using System;

namespace Aura.UI.Helpers
{
    public static class Maths
    {
        public static double ToSexagesimalDegrees(this double centesimalDegrees)
            => centesimalDegrees * 180 / 200;

        public static double ToDegrees(this double radians) => 180 * radians / Math.PI;
        public static double ToRadians(this double degrees) => degrees * Math.PI / 180;

        public static byte ToByte(this double d) => (byte)d;

        public static float ToFloat(this double d) => (float)d;

        public static byte FromFloat(float d)
            => (d < 0 || d > 1) ? throw new ArgumentOutOfRangeException($"the numbre {d} is less than 0 or greater than 1") : (byte)(d * 255);

        public static double ValueFromMinMaxAngle(double angle, double min, double max)
        {
            //example: max:100 min:-100 angle:180 expected value:0
            double range = max - min; //max - min = 100 - (-100) = 200
            double angle_percent = PercentageOf(360, angle);//percentage:50%
            double percentage_resolved = ValueByPercentage(range, angle_percent); //percent(200,50) = 100
            double value = min + percentage_resolved;//-100 + 100 = 0! the expected value
            return value;// * 180 / Math.PI;
        }

        public static double AngleFromMinMaxValue(double value, double min, double max)
        {
            var range = max - min;
            var vm = value - min;
            return 360 * vm / range;
        }

        public static bool CircleContainsPoint(Point point, Point circleCenter, double radius)
        {
            double x1, x2, y1, y2;
            x1 = point.X;
            y1 = point.Y;
            x2 = circleCenter.X;
            y2 = circleCenter.Y;

            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) <= radius;
        }
        public static bool CircularCrownContainsPoint(Point point, Point circleCenter, double internalRadius, double externalRadius)
            => CircleContainsPoint(point, circleCenter, externalRadius) &&
                !CircleContainsPoint(point, circleCenter, internalRadius);

        public static bool TriangleContains(Point a, Point b, Point c, Point point)
        {
            var p = point;
            //Sea d el segmento ab.
            var d = b - a;

            //Sea e el segmento ac.
            var e = c - a;

            //Variable de ponderación a~b
            var w1 = (e.X * (a.Y - p.Y) + e.Y * (p.X - a.X)) / (d.X * e.Y - d.Y * e.X);

            //Variable de ponderación a~c
            var w2 = (p.Y - a.Y - w1 * d.Y) / e.Y;

            //El punto p se encuentra dentro del triángulo
            //si se cumplen las 3 condiciones:
            if ((w1 >= 0.0) && (w2 >= 0.0) && ((w1 + w2) <= 1.0))
                return true;
            else
                return false;
        }

        //Source: https://social.msdn.microsoft.com/Forums/en-US/02681c52-a491-4fde-a6e7-3d5e81c3cdad/radial-slider-implementation-in-xaml?forum=wpf
        public static double AngleOf(Point pos, double radius)
        {
            Point center = new Point(radius, radius);
            double xDiff = center.X - pos.X;
            double yDiff = center.Y - pos.Y;
            double r = Math.Sqrt(xDiff * xDiff + yDiff * yDiff);

            //Calculate the angle
            double angle = Math.Acos((center.Y - pos.Y) / r);
            if (pos.X < radius)
                angle = 2 * Math.PI - angle;
            if (double.IsNaN(angle))
                return 0.0;
            else
                return angle;
        }

        public static double PercentageOf(double total, double value) => value * 100 / total;
        public static double ValueByPercentage(double total, double percentage) => total * percentage / 100;

        public static double Pitagoras(double AB, double BC)
            => Math.Sqrt(Math.Pow(AB, 2) + Math.Pow(BC, 2));

        public static double TriangleSideByRadius(double r)
            => Math.Sqrt(4 * (Math.Pow(r, 2) - Math.Pow(r/2, 2)));

        public static double TriangleHeightBySide(double side)
            => Math.Sqrt(3) * side / 2;

        public static Point Rotate(this Point pointToRotate, Point centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point(
                    (cosTheta * (pointToRotate.X - centerPoint.X) -
                    sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                    (sinTheta * (pointToRotate.X - centerPoint.X) +
                    cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y));
        }

        public static double DistanceBetweenTwoPoints(Point p1, Point p2) => DistanceBetweenTwoPoints(p1.X, p2.X, p1.Y, p2.Y);

        public static double DistanceBetweenTwoPoints(double x1, double x2, double y1, double y2)
        {
            return ((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        private static void MinMaxRgb(out double min, out double max, double r, double g, double b)
        {
            if (r > g)
            {
                max = r;
                min = g;
            }
            else
            {
                max = g;
                min = r;
            }
            if (b > max)
            {
                max = b;
            }
            else if (b < min)
            {
                min = b;
            }
        }

        public static double GetHue(double r, double g, double b)
        {

            if (r == g && g == b)
                return 0f;

            MinMaxRgb(out double min, out double max, r, g, b);

            double delta = max - min;
            double hue;

            if (r == max)
                hue = (g - b) / delta;
            else if (g == max)
                hue = (b - r) / delta + 2f;
            else
                hue = (r - g) / delta + 4f;

            hue *= 60f;
            if (hue < 0f)
                hue += 360f;

            return hue;
        }
    }
}