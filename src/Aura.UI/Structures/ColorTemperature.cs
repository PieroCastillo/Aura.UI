using System;
using System.Collections.Generic;
using System.Text;

namespace ColorPicker.Structures
{
    public struct ColorTemperature
    {
        public float k; // Temperature in kelvins

        #region Constants

        public static ColorTemperature Hot { get { return new ColorTemperature(1000); } }
        public static ColorTemperature Warm { get { return new ColorTemperature(2200); } }
        public static ColorTemperature Neutral { get { return new ColorTemperature(4500); } }
        public static ColorTemperature Cool { get { return new ColorTemperature(9000); } }
        public static ColorTemperature Cold { get { return new ColorTemperature(11000); } }

        #endregion

        public ColorTemperature(float temperature)
        {
            this.k = temperature;
        }

        public RGBColor ToRGB()
        {
            //DEPRECATED: RGB is not device-independant so is not good for specifying color temperature.
            // Use the XYZ color space instead.

            float r, g, b;

            // Red
            if (k < 6600)
            {
                r = 255;
            }
            else
            {
                r = k - 6000.0f;
                r = 329.698727446f * (float)Math.Pow(r / 100.0, -0.1332047592);
            }

            // Green
            if (k < 6600)
            {
                g = k;
                g = 99.4708025861f * (float)Math.Log(g / 100.0) - 161.1195681661f;
            }
            else
            {
                g = k - 6000;
                g = 288.1221695283f * (float)Math.Pow(g / 100.0, -0.0755148492);
            }

            // Blue
            if (k > 6600)
            {
                b = 255;
            }
            else
            {
                //if (K < 1900) 
                b = k - 1000;
                b = 138.5177312231f * (float)Math.Log(b / 100.0) - 305.0447927307f;
            }

            r /= 255.0f;
            g /= 255.0f;
            b /= 255.0f;

            if (r > 1.0f) r = 1.0f;
            if (g > 1.0f) g = 1.0f;
            if (b > 1.0f) b = 1.0f;
            if (r < 0.0f) r = 0.0f;
            if (g < 0.0f) g = 0.0f;
            if (b < 0.0f) b = 0.0f;

            return new RGBColor(r, g, b);
        }


        public CIEXYZColor ToXYZ()
        {
            // See http://en.wikipedia.org/wiki/Planckian_locus#Approximation

            double xc = 0, yc = 0;
            double T = this.k;
            double M = 10e+3 / T;

            if (T < 1667.0 || T > 25000.0)
            {
                // Undefined
                return new CIEXYZColor(double.NaN, double.NaN, double.NaN);
            }

            //TODO: This doesn't work properly, and produces out-of-gamut colors, 
            // even though the blue temperatures should be completely within the gamut.
            // Need to create an xyY plot for checking the values...

            double arg1 = 1e9 / (T * T * T), arg2 = 1e6 / (T * T), arg3 = 1e3 / T;
            if (T >= 1667 && T <= 4000)
            {
                xc = -0.2661239 * arg1 - 0.2343580 * arg2 + 0.8776956 * arg3 + 0.179910;
            }
            else if (T > 4000 && T <= 25000)
            {
                xc = -3.0258469 * arg1 + 2.1070379 * arg2 + 0.2226347 * arg3 + 0.240390;
            }
            double xc3 = xc * xc * xc, xc2 = xc * xc;
            if (T >= 1667 && T <= 2222)
            {
                yc = -1.1063814 * xc3 - 1.34811020 * xc2 + 2.18555832 * xc - 0.20219683;
            }
            else if (T > 2222 && T <= 4000)
            {
                yc = -0.9549476 * xc3 - 1.37418593 * xc2 + 2.09137015 * xc - 0.16748867;
            }
            else if (T > 4000 && T <= 25000)
            {
                yc = +3.0817580 * xc3 - 5.87338670 * xc2 + 3.75112997 * xc - 0.37001483;
            }

            return new CIEXYYColor(xc, yc, 0.2);
        }

        /*public static implicit operator RGBColor(ColorTemperature ct)
        {
            return ct.ToRGB();
        }*/

        public static implicit operator CIEXYZColor(ColorTemperature ct)
        {
            return ct.ToXYZ();
        }
    }
}
