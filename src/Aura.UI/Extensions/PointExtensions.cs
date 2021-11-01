using Aura.UI.Helpers;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Extensions
{
    public static class PointExtensions
    {
        public static double DistanceWith(this Point p1, Point p2) => Maths.DistanceBetweenTwoPoints(p1, p2);
    }
}
