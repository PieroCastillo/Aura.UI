using System;

namespace ColorPicker.Structures
{
    public struct HSVColor
    {
        /// <summary>
        /// Hue (0.0 to 360.0)
        /// </summary>
        public float hue;

        /// <summary>
        /// Saturation (0.0 to 1.0)
        /// </summary>
        public float sat;

        /// <summary>
        /// Value (0.0 to 1.0)
        /// </summary>
        public float value;

        public HSVColor(float hue, float saturation, float value)
        {
            this.hue = hue;
            this.sat = saturation;
            this.value = value;
        }

        public void Clamp()
        {
            if (hue > 360.0f) hue = 360.0f;
            if (sat > 1.0f) sat = 1.0f;
            if (value > 1.0f) value = 1.0f;
            if (hue < 0.0f) hue = 0.0f;
            if (sat < 0.0f) sat = 0.0f;
            if (value < 0.0f) value = 0.0f;
        }

        /// <summary>
        /// Convert this HSV color to RGB colorspace
        /// </summary>
        public RGBColor ToRGB()
        {
            float hue = this.hue;
            float sat = this.sat;
            float value = this.value;
            float r = 0;
            float g = 0;
            float b = 0;

            int hi = (int)Math.Floor(hue / 60) % 6;
            float f = hue / 60 - (float)Math.Floor(hue / 60);

            value = value * 255;
            int v = (int)value;
            int p = (int)(value * (1.0 - sat));
            int q = (int)(value * (1.0 - f * sat));
            int t = (int)(value * (1.0 - (1.0 - f) * sat));

            switch (hi)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                case 5: r = v; g = p; b = q; break;
            }
            r /= 255.0f;
            g /= 255.0f;
            b /= 255.0f;

            return new RGBColor(r, g, b);
        }

        public static HSVColor FromRGB(RGBColor rgb)
        {
            HSVColor hsv = new HSVColor();

            float max = (float)Math.Max(rgb.r, Math.Max(rgb.g, rgb.b));
            float min = (float)Math.Min(rgb.r, Math.Min(rgb.g, rgb.b));

            hsv.value = max;

            float delta = max - min;

            if (max > float.Epsilon)
            {
                hsv.sat = delta / max;
            }
            else
            {
                // r = g = b = 0
                hsv.sat = 0;
                hsv.hue = float.NaN; // Undefined
                return hsv;
            }

            if (rgb.r == max)
                hsv.hue = (rgb.g - rgb.b) / delta;    // Between yellow and magenta
            else if (rgb.g == max)
                hsv.hue = 2 + (rgb.b - rgb.r) / delta; // Between cyan and yellow
            else
                hsv.hue = 4 + (rgb.r - rgb.g) / delta; // Between magenta and cyan

            hsv.hue *= 60.0f; // degrees
            if (hsv.hue < 0)
                hsv.hue += 360;

            return hsv;
        }

        public static implicit operator RGBColor(HSVColor hsv)
        {
            return hsv.ToRGB();
        }

        public static implicit operator HSVColor(RGBColor rgb)
        {
            return HSVColor.FromRGB(rgb);
        }
    }
}
