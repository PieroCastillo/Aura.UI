using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Extensions
{
    public static class NumberExtensions
    {
        public static byte ToByte(this double d) => (byte)d;
        public static float ToFloat(this double d) => (float)d;
    }
}
