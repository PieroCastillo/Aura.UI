using Aura.UI.Helpers;
using Avalonia.Media;
using System;

namespace Aura.UI.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Convert a <see cref="HSLStruct"/> to <see cref="Helpers.RGBStruct"/>
        /// </summary>
        /// <param name="HSL">the <see cref="HSLStruct"/> to convert</param>
        /// <returns>a <see cref="Helpers.RGBStruct"/> converted</returns>
        public static Helpers.RGBStruct ToRGB(this HSLStruct HSL)
        {
            double h = HSL.hue;
            double sl = HSL.saturation;
            double l = HSL.lightness;
            double v;
            double r, g, b;

            r = l;   // default to gray

            g = l;

            b = l;

            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);

            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;

                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;

                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;

                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;

                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;

                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;

                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            byte rr = Convert.ToByte(r * 255.0f);
            byte gg = Convert.ToByte(g * 255.0f);
            byte bb = Convert.ToByte(b * 255.0f);

            return new Helpers.RGBStruct(new Color(255, rr, gg, bb));
        }

        // Given a Color (RGB Struct) in range of 0-255

        // Return H,S,L in range of 0-1
        /// <summary>
        /// Convert a <see cref="Helpers.RGBStruct"/> to Hsl in a tuple
        /// </summary>
        /// <param name="rgb">the <see cref="Helpers.RGBStruct"/> to convert</param>
        /// <returns>tuple with h,s,l to build a <see cref="HSLStruct"/></returns>
        public static (double hh, double ss, double ll) ToHSL(this Helpers.RGBStruct rgb)
        {
            double h, s, l;
            double r = rgb.r / 255.0;
            double g = rgb.g / 255.0;
            double b = rgb.b / 255.0;
            double v;
            double m;
            double vm;
            double r2, g2, b2;

            h = 0; // default to black
            s = 0;
            l = 0;

            v = Math.Max(r, g);
            v = Math.Max(v, b);
            m = Math.Min(r, g);
            m = Math.Min(m, b);
            l = (m + v) / 2.0;

            if (l <= 0.0)
            {
            }

            vm = v - m;

            s = vm;

            if (s > 0.0)

            {
                s /= (l <= 0.5) ? (v + m) : (2.0 - v - m);
            }
            else
            {
            }

            r2 = (v - r) / vm;

            g2 = (v - g) / vm;

            b2 = (v - b) / vm;

            if (r == v)

            {
                h = (g == m ? 5.0 + b2 : 1.0 - g2);
            }
            else if (g == v)

            {
                h = (b == m ? 1.0 + r2 : 3.0 - b2);
            }
            else

            {
                h = (r == m ? 3.0 + g2 : 5.0 - r2);
            }

            h /= 6.0;
            if (h == double.NaN)
            {
                h = 0;
            }
            return (h, s, l);
        }

        public static (double hh, double ss, double ll) ToHSL(this Color color) => new Helpers.RGBStruct(color).ToHSL();

        /// <summary>
        /// Decomposes a <see cref="Color"/> to HSV format
        /// </summary>
        /// <param name="color">Color to Decompose</param>
        /// <param name="hue">0 to 360</param>
        /// <param name="saturation">0 up to 100</param>
        /// <param name="brightness">0 up to 100</param>
        public static void ToHSV(this Color color, out float hue, out byte saturation, out byte brightness)
        {
            color.Decompose(out _, out byte r, out byte g, out byte b);

            r /= 255;
            g /= 255;
            b /= 255;

            byte mx = Math.Max(r, Math.Max(g, b));
            byte mn = Math.Min(r, Math.Min(g, b));

            hue = color.GetHue();

            saturation = (byte)((mx == 0) ? 0 : (1 - (1 * mn / mx)) * 100);

            brightness = (byte)(mx * 100);
        }

        internal static float GetHue(this Color color)
        {
            color.Decompose(out _, out byte r, out byte g, out byte b);
            if (r == g && g == b)
                return 0f;

            int min = Math.Min(Math.Min(r, g), b);
            int max = Math.Max(Math.Max(r, g), b);

            float delta = max - min;
            float hue;

            if (r == max)
                hue = (g - b) / delta;
            else if (g == max)
                hue = (b - r) / delta + 2f;
            else
                hue = (r - g) / delta + 4f;

            hue *= 60f;
            if (hue < 0f)
                hue += 360f;

            return hue;
        }

        public static Color FromHSV(this Color color, float hue, byte saturation, byte value)
        {
            saturation /= 100;
            value /= 100;

            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60f);

            value *= 255;
            byte v = value;
            byte p = (byte)(value * (1 - saturation));
            byte q = (byte)(value * (1 - f * saturation));
            byte t = (byte)(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromRgb(v, t, p);
            else if (hi == 1)
                return Color.FromRgb(q, v, p);
            else if (hi == 2)
                return Color.FromRgb(p, v, t);
            else if (hi == 3)
                return Color.FromRgb(p, q, v);
            else if (hi == 4)
                return Color.FromRgb(t, p, v);
            else
                return Color.FromRgb(v, p, q);
        }

        public static void Decompose(this Color color, out byte a, out byte r, out byte g, out byte b)
        {
            a = color.A;
            r = color.R;
            g = color.G;
            b = color.B;
        }
    }
}