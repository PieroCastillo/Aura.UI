using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Rendering
{
    public static class SKMaths
    {
        public static SKPoint Rotate(this SKPoint pointToRotate, SKPoint centerPoint, float angleInDegrees)
        {
            float angleInRadians = angleInDegrees * (MathF.PI / 180);
            float cosTheta = MathF.Cos(angleInRadians);
            float sinTheta = MathF.Sin(angleInRadians);
            return new SKPoint(
                    (cosTheta * (pointToRotate.X - centerPoint.X) -
                    sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                    (sinTheta * (pointToRotate.X - centerPoint.X) +
                    cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y));
        }


        public static bool TriangleContains(SKPoint a, SKPoint b, SKPoint c, SKPoint point)
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
    }
}
