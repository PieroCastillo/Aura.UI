using Avalonia;
using System;

namespace Aura.UI.Helpers
{
    public static class Maths
    {
        public static double ToSexagesimalDegrees(double centesimalDegrees)
            => centesimalDegrees * 180 / 200;

        public static double Calibrate(double value, double min, double max, double old_value)
        /*=> Math.Abs(value * 100 /
            -Math.Abs(max + min));*/
        {
            double range = max - min;
            //double fromProgress = (old_value - min) / range;//fromProgress;
            //return ((value - min) / range) + ((old_value - min) / range);
            return (value + old_value + (2 * -min)) / range;
            //return value + old_value - (2 * min) / (max - min);
        }

        public static double ValueFromMinMaxAngle(double angle, double min, double max, double old_value)
        {
            double range = max - min;
            double proportion = angle / range;
            double value = proportion - old_value + 180 - 180*(2 * -min);

            return value / 180;
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

        public static double DegreesBetweenPointAndCenter(Point p, Point center)
        {
            var radian = Math.Atan2(p.Y - center.Y, p.X - center.X);
            var angle = radian * (180 / Math.PI);
            angle += 90;
            if (angle < 0.0)
                angle += 360.0;
            else if (angle > 360)
                angle -= 360;

            //var module = (center.Y - p.Y) / (center.X - p.X);
            //var angle = Math.Atan(module) * 180 / Math.PI;

            return angle;
        }

        public static double PercentageOf(double total, double value) => value * 100 / total;
        public static double ValueByPercentage(double total, double percentage) => total * percentage / 100;
    }
}