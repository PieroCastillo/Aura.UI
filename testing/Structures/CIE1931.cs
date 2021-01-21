using System;

namespace ColorPicker.Structures
{
    public class CIE1931
    {
        /// <summary>
        /// Apply CIE intensity perception to the given lumininace value
        /// </summary>
        /// <param name="L">The luminance, between 0.0 and 1.0</param>
        /// <returns>Percieved intensity, between 0.0 and 1.0</returns>
        public static float LumToBrightness(float L)
        {
            // See: http://www.poynton.com/notes/colour_and_gamma/ColorFAQ.html#RTFToC2
            // (Yn is assumed to be 1.0)
            return (L <= 0.08f) ? (L / 9.033f) : (float)Math.Pow((L + 0.16f) / 1.16f, 3);
        }

        /// <summary>
        /// Apply CIE correction to an RGB colour.
        /// This is useful for driving LEDs, as their output is linear, but our perception to light is not.
        /// </summary>
        /// <param name="input">The color to correct</param>
        /// <returns>CIE corrected color</returns>
        public static RGBColor CorrectRGB(RGBColor input)
        {
            return new RGBColor(
                LumToBrightness(input.r),
                LumToBrightness(input.g),
                LumToBrightness(input.b)
            );
        }

    }
}
