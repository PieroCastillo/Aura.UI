using System;

namespace ColorPicker.Structures
{
    public struct RGBStruct
    {
        public byte r, g, b, a;

        public RGBStruct(byte r, byte g, byte b, byte a = 255)
        {
            this.r = r; this.g = g; this.b = b; this.a = a;
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

    public struct RGBColor
    {
        public float r, g, b;

        public byte Rb { get { return FloatToByte(r); } set { r = ByteToFloat(value); } }
        public byte Gb { get { return FloatToByte(g); } set { g = ByteToFloat(value); } }
        public byte Bb { get { return FloatToByte(b); } set { b = ByteToFloat(value); } }
        //public float R { get { return r; } set { r = value; } }

        public RGBColor(float red, float green, float blue)
        {
            r = red;
            g = green;
            b = blue;
        }

        #region Private Utilities
        private byte FloatToByte(double value)
        {
            if (value < 0.0) return 0;
            if (value > 1.0) return 255;
            return (byte)(value * 255.0);
        }

        private float ByteToFloat(byte value)
        {
            return (float)value / 255.0f;
        }

        #endregion

        #region Operations

        /// <summary>
        /// Clamps the RGB values between 0.0 and 1.0
        /// </summary>
        public void Clamp()
        {
            if (r > 1.0f) r = 1.0f;
            if (g > 1.0f) g = 1.0f;
            if (b > 1.0f) b = 1.0f;
            if (r < 0.0f) r = 0.0f;
            if (g < 0.0f) g = 0.0f;
            if (b < 0.0f) b = 0.0f;
        }

        public bool OutOfGamut
        {
            get
            {
                return (r < 0.0f || g < 0.0f || b < 0.0f || r > 1.0f || g > 1.0f || b > 1.0f);
            }
        }

        #endregion

        #region Implicit Conversion

        public float GetSaturation()
        {
            float max = (float)Math.Max(r, Math.Max(g, b));
            float min = (float)Math.Min(r, Math.Min(g, b));
            return (max == 0.0f) ? 0.0f : 1.0f - (1.0f * min / max);
        }

        public float GetValue()
        {
            return Math.Max(r, Math.Max(g, b));
        }

        /// <summary>
        /// Returns the grayscale intensity of the RGB colour
        /// (Colours with the same saturation appear as different intensities)
        /// </summary>
        public float GetIntensity()
        {
            return 0.2126f * r + 0.7152f * g + 0.0722f * b;
        }

        public static implicit operator RGBColor(Avalonia.Media.Color c)
        {
            return new RGBColor(c.R / 255.0f, c.G / 255.0f, c.B / 255.0f);
        }

        public static implicit operator RGBColor(System.Drawing.Color c)
        {
            return new RGBColor(c.R / 255.0f, c.G / 255.0f, c.B / 255.0f);
        }

        public static implicit operator Avalonia.Media.Color(RGBColor c)
        {
            return new Avalonia.Media.Color(255, (byte)(c.r * 255), (byte)(c.g * 255), (byte)(c.b * 255));
        }

        public static implicit operator System.Drawing.Color(RGBColor c)
        {
            return System.Drawing.Color.FromArgb(255, (byte)(c.r * 255), (byte)(c.g * 255), (byte)(c.b * 255));
        }

        #endregion

        #region operators

        // Colour1 + Colour2
        public static RGBColor operator +(RGBColor c1, RGBColor c2)
        {
            return new RGBColor(
                c1.r + c2.r,
                c1.g + c2.g,
                c1.b + c2.b
            );
        }

        // Colour1 * Color 2
        public static RGBColor operator *(RGBColor c1, RGBColor c2)
        {
            return new RGBColor(
                c1.r * c2.r,
                c1.g * c2.g,
                c1.b * c2.b
            );
        }

        // Colour1 + float
        public static RGBColor operator +(RGBColor c, float f)
        {
            return new RGBColor(
                c.r + f,
                c.g + f,
                c.b + f
            );
        }

        // Colour1 * float
        public static RGBColor operator *(RGBColor c, float f)
        {
            return new RGBColor(
                c.r * f,
                c.g * f,
                c.b * f
            );
        }

        public static RGBColor Interpolate(RGBColor c1, RGBColor c2, float value)
        {
            return (c1 * (1.0f - value)) + (c2 * value);
        }

        #endregion

        #region ToString Methods

        public string ToHexRGB()
        {
            return String.Format("#{0:x2}{1:x2}{2:x2}", Rb, Gb, Bb);
        }

        public override string ToString()
        {
            return String.Format("rgb({0:0.00},{1:0.00},{2:0.00})", r, g, b);
        }

        #endregion
    }
}
