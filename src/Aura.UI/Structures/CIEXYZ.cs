using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;


/* Provides a way to specify device-independant colors, in a linear colorspace.
 * 
 * The default conversion from XYZ to RGB uses the primary colors as specified in the BT.709/sRGB standard:
 * http://www.itu.int/dms_pubrec/itu-r/rec/bt/R-REC-BT.709-5-200204-I!!PDF-E.pdf
 * Note that the RGB returned is NOT sRGB. It is linear!
 * 
 * Useful calculator here:
 * http://www.brucelindbloom.com/index.html?ColorCalcHelp.html
 */

namespace ColorPicker.Structures
{
    /// <summary>
    /// Defines the RGB primaries to use when converting XYZ to RGB colorspace.
    /// This is because XYZ is device-independant.
    /// </summary>
    public class CIERGBDefinition
    {
        // Primaries as defined in BT709 standard:
        public static readonly CIERGBDefinition sRGB = new CIERGBDefinition(
            new CIEXYYColor(0.64, 0.33),  // red
            new CIEXYYColor(0.30, 0.60),  // green
            new CIEXYYColor(0.15, 0.06),  // blue
            new CIEXYYColor(0.3127, 0.3290) // reference white (D65)
        );

        // Primaries as defined by the CIE1931 standard:
        public static readonly CIERGBDefinition CIERGB = new CIERGBDefinition(
            new CIEXYYColor(0.735, 0.265),
            new CIEXYYColor(0.274, 0.717),
            new CIEXYYColor(0.167, 0.009),
            new CIEXYYColor(1 / 3.0, 1 / 3.0)
        );

        public CIEXYZColor Red { get; private set; }
        public CIEXYZColor Green { get; private set; }
        public CIEXYZColor Blue { get; private set; }
        public CIEXYZColor White { get; private set; }

        public Matrix<double> rgb2xyz { get; private set; }
        public Matrix<double> xyz2rgb { get; private set; }


        public CIERGBDefinition(CIEXYZColor red, CIEXYZColor green, CIEXYZColor blue, CIEXYZColor white)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.White = white;

            // Calculate the RGB transform model
            var m = DenseMatrix.OfArray(new double[,] {
                {Red.X, Green.X, Blue.X},
                {Red.Y, Green.Y, Blue.Y}, //NB: Y should be 1.0
                {Red.Z, Green.Z, Blue.Z}
            });
            var mi = m.Inverse();

            var refwhite = (Vector<double>)White;
            var srgb = mi * refwhite;

            this.rgb2xyz = DenseMatrix.OfArray(new double[,] {
                {srgb[0]*m[0,0], srgb[1]*m[0,1], srgb[2]*m[0,2]},
                {srgb[0]*m[1,0], srgb[1]*m[1,1], srgb[2]*m[1,2]},
                {srgb[0]*m[2,0], srgb[1]*m[2,1], srgb[2]*m[2,2]},
            }).Transpose();
            this.xyz2rgb = rgb2xyz.Inverse();
        }
    }

    /// <summary>
    /// Defines a color using XYZ tristimulus colorspace. Y is equivalent to luminance, all values must be positive.
    /// All values are linear, but do not represent perceptual linearity.
    /// XYZ and xyY can be implicitly converted between each other.
    /// </summary>
    public struct CIEXYZColor
    {
        public double X, Y, Z;

        public CIEXYZColor(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public RGBColor ToRGB(CIERGBDefinition primaries, bool limitGamut = true)
        {
            // NOTE: Assumes linear RGB, not sRGB.
            var mat = primaries.xyz2rgb;
            var rgb = mat * this;

            if (limitGamut && (rgb.Maximum() > 1.0 || rgb.Minimum() < 0.0))
            {
                // Outside the gamut
                return new RGBColor(float.NaN, float.NaN, float.NaN);
            }
            else
            {
                return new RGBColor((float)rgb[0], (float)rgb[1], (float)rgb[2]);
            }
        }

        public static CIEXYZColor FromRGB(RGBColor rgb, CIERGBDefinition primaries)
        {
            var mat = primaries.rgb2xyz;
            var rgbvec = DenseVector.OfArray(new double[] { rgb.r, rgb.g, rgb.b });
            var xyz = mat * rgbvec;
            return new CIEXYZColor(xyz[0], xyz[1], xyz[2]);
        }

        public static implicit operator RGBColor(CIEXYZColor xyz)
        {
            return xyz.ToRGB(CIERGBDefinition.sRGB);
        }

        public static implicit operator CIEXYZColor(RGBColor rgb)
        {
            return CIEXYZColor.FromRGB(rgb, CIERGBDefinition.sRGB);
        }

        public static implicit operator Vector<double>(CIEXYZColor xyz)
        {
            return DenseVector.OfArray(new double[] { xyz.X, xyz.Y, xyz.Z });
        }

 
        public override string ToString()
        {
            return String.Format("xyz({0:0.00},{1:0.00},{2:0.00})", X, Y, Z);
        }
    }

    /// <summary>
    /// Defines a color using xyY colorspace. Y is luminance, xy is chrominance.
    /// All values are linear, but do not represent perceptual linearity.
    /// XYZ and xyY can be implicitly converted between each other.
    /// </summary>
    public struct CIEXYYColor
    {
        public double x, y, Y;

        public CIEXYYColor(double x, double y, double Y = 1.0)
        {
            this.x = x;
            this.y = y;
            this.Y = Y;
        }

        public static implicit operator CIEXYZColor(CIEXYYColor xyy)
        {
            if (xyy.y == 0.0f)
            {
                return new CIEXYZColor(0, 0, 0);
            }
            else
            {
                double X, Z;
                X = (xyy.Y / xyy.y) * xyy.x;
                Z = (xyy.Y / xyy.y) * (1 - xyy.x - xyy.y);
                return new CIEXYZColor(X, xyy.Y, Z);
            }
        }

        public static implicit operator CIEXYYColor(CIEXYZColor xyz)
        {
            double x, y, s;
            s = (xyz.X + xyz.Y + xyz.Z);
            x = xyz.X / s;
            y = xyz.Y / s;
            return new CIEXYYColor(x, y, xyz.Y);
        }

        public static implicit operator RGBColor(CIEXYYColor xyy)
        {
            return (RGBColor)(CIEXYZColor)xyy;
        }


        public override string ToString()
        {
            return String.Format("xyz({0:0.00},{1:0.00},{2:0.00})", x, y, Y);
        }

    }
}
