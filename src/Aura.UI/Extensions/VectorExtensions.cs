using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Avalonia;

namespace Aura.UI.Extensions
{
    public static class VectorExtensions
    {
        public static VectorDirection GetVectorDirection(this Vector vector)
        {
            var x_ = vector.X;
            var y_ = vector.Y;
            VectorDirection V_ = 0;
            
            #if DEBUG
            Stopwatch st = new Stopwatch();
            st.Start();
            #endif
            
            if (double.IsNegative(x_) && double.IsNegative(y_))
            {
                V_ = VectorDirection.AllNegative;
            }
            else if (double.IsNegative(x_) && double.IsNormal(y_))
            {
                V_ = VectorDirection.NegativeX;
            }
            else if (double.IsNormal(x_) && double.IsNegative(y_))
            {
                V_ = VectorDirection.NegativeY;
            }
            else if (!double.IsNegative(x_) && !double.IsNegative(y_))
            {
                V_ = VectorDirection.AllPositive;
            }
            
            #if DEBUG
            st.Stop();
            Debug.WriteLine($"measure direction takes {st.ElapsedMilliseconds} ms too long");
            #endif
            
            return V_;
        }

        public static double GetVectorModuleAffectedByDirection(this Vector vector)
        {
            switch (vector.GetVectorDirection())
            {
                case VectorDirection.AllPositive:
                    return vector.SquaredLength;
                case VectorDirection.NegativeX:
                    
                    return 0;
                case VectorDirection.NegativeY:
                    
                    return 0;
                case VectorDirection.AllNegative:
                    return vector.SquaredLength * -1;
                default: return 0;
            }
        }
        /// <summary>
        /// Measure the distance between vector1 and vector2
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static double AngleBetween(Vector vector1, Vector vector2)
        {
            double sin = vector1.X * vector2.Y - vector2.X * vector1.Y;  
            double cos = vector1.X * vector2.X + vector1.Y * vector2.Y;
 
            return Math.Atan2(sin, cos) * (180 / Math.PI);
        }
/// <summary>
/// The same to <see cref="VectorExtensions.AngleBetween"/> but like extension
/// </summary>
/// <param name="vector1"></param>
/// <param name="vector2"></param>
/// <returns></returns>
        public static double AngleBetweenExt(this Vector vector1, Vector vector2)
        {
            return VectorExtensions.AngleBetween(vector1, vector2);
        }
    }

    public enum VectorDirection
    {
        AllPositive,
        NegativeX,
        NegativeY,
        AllNegative
    }
}