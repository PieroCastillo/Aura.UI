using Avalonia;
using System;

namespace ColorPicker.Utilities
{
    /// <summary>
    /// Circular math utility functions.
    /// Inputs represent angles around a circle, such that:
    ///     450 == 90 == -270 mod 360
    /// All angles are assumed to be degrees (not radians)
    /// </summary>
    internal static class CircularMath
    {
        public const double N = 360.0;

        /// <summary>
        /// Calculates the angle in degrees of the line between pt and the origin,
        /// with respect to the vertical axis. (0 degrees = up)
        /// </summary>
        public static double AngleFromPoint(Point pt, Point origin)
        {
            double dx = pt.X - origin.X;
            double dy = pt.Y - origin.Y;

            return Mod(180.0 - (Math.Atan2(dx, dy) / Math.PI * 180.0));
        }

        /// <summary>
        /// Calculates the point given by the specified radius and angle from the origin.
        /// </summary>
        public static Point PointFromAngle(double angle, double radius, Point origin)
        {
            angle = 180.0 - angle;

            double x = radius * Math.Sin(angle * Math.PI / 180.0);
            double y = radius * Math.Cos(angle * Math.PI / 180.0);

            return new Point(origin.X + x, origin.Y + y);
        }

        /// <summary>
        /// Mathematical modulus
        ///     a mod n (n defaults to 360.0)
        /// </summary>
        public static double Mod(double a, double n = N)
        {
            return ((a % n) + n) % n;
        }

        /// <summary>
        /// Returns true if a >= x >= b, mod 360.
        /// </summary>
        public static bool Between(double a, double b, double x)
        {
            a = Mod(a);
            b = Mod(b);
            x = Mod(x);

            if (a > b)  // a >= 0.0 >= b, mod 360
                return ((x >= a && x < N) || (x >= 0.0 && x <= b));
            else
                return (x >= a && x <= b);
        }

        /// <summary>
        /// Map the angle x from start and stop to 0.0 and 1.0.
        /// Values outside start and stop are defined as NaN, since the
        /// number space is circular.
        /// </summary>
        public static double NormMap(double start, double stop, double x, bool clockwise = true)
        {
            start = Mod(start);
            stop = Mod(stop);
            x = Mod(x);

            double value = Mod(x - start) / Mod(stop - start);

            if ((x != start) && (x != stop) && Between(stop, start, x))
                value = double.NaN;
            return value;
        }
    }
}
