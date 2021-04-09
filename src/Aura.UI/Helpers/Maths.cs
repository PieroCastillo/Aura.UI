using Avalonia;
using System;

namespace Aura.UI.Helpers
{
    public static class Maths
    {
        public static double ToSexagesimalDegrees(double centesimalDegrees)
            => centesimalDegrees * 180 / 200;

        public static double Calibrate(double value, double min, double max, double old_value)
        {
            double range = max - min;
            //double fromProgress = (old_value - min) / range;//fromProgress;
            //return ((value - min) / range) + ((old_value - min) / range);
            return (value + old_value + (2 * -min)) / range;
            //return value + old_value - (2 * min) / (max - min);
        }

        public static double ValueFromMinMaxAngle(double angle, double min, double max)
        {
            //example: max:100 min:-100 angle:180 expected value:0
            double range = max - min; //max - min = 100 - (-100) = 200
            double angle_percent = PercentageOf(360, angle);//percentage:50%
            double percentage_resolved = ValueByPercentage(range, angle_percent); //percent(200,50) = 100
            double value = min + percentage_resolved;//-100 + 100 = 0! the expected value
            return value;
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

        public static double Pitagoras(double AB, double BC)
            => Math.Sqrt(Math.Pow(AB, 2) + Math.Pow(BC, 2));

        public static double TriangleSideByRadius(double r)
            => Math.Sqrt(4 * (Math.Pow(r, 2) - Math.Pow(r/2, 2)));

        public static double TriangleHeightBySide(double side)
            => Math.Sqrt(3) * side / 2;

        public static double DistanceBetweenTwoPoints(Point p1, Point p2)
        {
            double x1 = p1.X;
            double x2 = p2.X;
            double y1 = p1.Y;
            double y2 = p2.Y;

            return ((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
    }
}