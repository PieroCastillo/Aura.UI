using System;

namespace Aura.UI.Extensions
{
    public static class NumberExtensions
    {
        public static byte ToByte(this double d) => (byte)d;

        public static float ToFloat(this double d) => (float)d;

        public static byte FromFloat(float d)
            => (d < 0 || d > 1) ? throw new ArgumentOutOfRangeException($"the numbre {d} is less than 0 or greater than 1") : (byte)(d * 255);
    }
}