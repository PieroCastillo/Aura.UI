using Aura.UI.Exceptions;
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
            double r = color.R / 255;
            double g = color.G / 255;
            double b = color.B / 255;

            var max = Math.Max(Math.Max(r, g), b);
            var min = Math.Min(Math.Min(r, g), b);
            var c = max - min;
            var c_p = max + min;
            double thue = 0;
            // Calculates the hue
            if(c == 0)
            {
                thue = 0;
            }
            else if(max == r)
            {
                var segment = (g - b) / c;
                var shift = 0 / 60;       // R° / (360° / hex sides)
                if (segment < 0)
                {          // hue > 180, full rotation
                    shift = 360 / 60;         // R° / (360° / hex sides)
                }
                thue = segment + shift;
            }
            else if (max == g)
            {
                var segment = (b - r) / c;
                var shift = 120 / 60;     // G° / (360° / hex sides)
                thue = segment + shift;
            }
            else if(max == b)
            {
                var segment = (r - g) / c;
                var shift = 240 / 60;     // B° / (360° / hex sides)
                thue = segment + shift;
            }
            this.hue = thue * 60;

            // Calculates the lightness
            this.lightness = (max + min) / 2;

            // Calculates the saturation
            double sat = 1.0;
            if(c == 0)
            {
                sat = 0;
            }
            else
            {
                if (this.lightness > 0.5)
                {
                    sat = c / c_p;
                }
                else if (this.lightness < 0.5)
                {
                    sat = c / (2 - c);
                }
            }
            this.saturation = sat;
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
    }
}
