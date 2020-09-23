using Aura.UI.Exceptions;
using Aura.UI.Extensions;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Helpers
{
    public struct HSLStruct
    {
        public HSLStruct(Color color) 
        {
            var rgb = new RGBStruct(color);
            var hsl = rgb.ToHSL();
            this.hue = hsl.hh;
            this.saturation = hsl.ss;
            this.lightness = hsl.ll;
        }
        public double hue { get; private set; }
        public double saturation { get; private set; }
        public double lightness { get; private set; }
    }

    public struct RGBStruct
    {
        public RGBStruct(Color color)
        {
            this.r = color.R;
            this.g = color.G;
            this.b = color.B;
            this.a = color.A;
        }
        public byte r { get; private set; }
        public byte g { get; private set; }
        public byte b { get; private set; }
        public byte a { get; private set; }
        /// <summary>
        /// Apply lightness to an <see cref="RGBStruct"/>
        /// </summary>
        /// <param name="rgb">The <see cref="RGBStruct"/> to edit </param>
        /// <param name="lightness">this param should be between 0.0 and 1.0</param>
        /// <returns></returns>
        public static RGBStruct ApplyLightnessToRGB(RGBStruct @rgb, double lightness)
        {  
            try
            {
                var r = rgb.r;
                var g = rgb.g;
                var b = rgb.b;

                var Lpercent = (byte)(lightness * 100);

                var new_r = (byte)((r * Lpercent) / 100);
                var new_g = (byte)((g * Lpercent) / 100);
                var new_b = (byte)((b * Lpercent) / 100);

                return new RGBStruct(new Color(rgb.a, new_r, new_g, new_b));
            }
            catch(Exception e)
            {
                throw new Exception("The lightness is greater than 1 or less than 0", e);
            }
        }

        public int ToARGB32()
        {
            return (a << 24) | (r << 16) | (g << 8) | (b << 0);
        }

        public int ToRGB32()
        {
            return (r << 16) | (g << 8) | (b << 0);
        }
    }
}
