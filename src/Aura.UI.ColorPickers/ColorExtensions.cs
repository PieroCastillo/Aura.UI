using Avalonia.Media;
using System;

namespace Aura.UI.ColorPickers.Extensions
{	public struct RGB
	{
		private byte _r;
		private byte _g;
		private byte _b;

		public RGB(byte r, byte g, byte b)
		{
			this._r = r;
			this._g = g;
			this._b = b;
		}

		public byte R
		{
			get => this._r;
			set { this._r = value; }
		}

		public byte G
		{
			get { return this._g; }
			set { this._g = value; }
		}

		public byte B
		{
			get { return this._b; }
			set { this._b = value; }
		}

		public bool Equals(RGB rgb)
		{
			return (this.R == rgb.R) && (this.G == rgb.G) && (this.B == rgb.B);
		}
	}

	public struct HSV
	{
		private double _h;
		private double _s;
		private double _v;

		public HSV(double h, double s, double v)
		{
			this._h = h;
			this._s = s;
			this._v = v;
		}

		public double H
		{
			get { return this._h; }
			set { this._h = value; }
		}

		public double S
		{
			get { return this._s; }
			set { this._s = value; }
		}

		public double V
		{
			get { return this._v; }
			set { this._v = value; }
		}

		public bool Equals(HSV hsv)
		{
			return (this.H == hsv.H) && (this.S == hsv.S) && (this.V == hsv.V);
		}
	}

	public static class ColorExtensions
    {
        public static HSV RGBToHSV(RGB rgb)
		{
			double delta, min;
			double h = 0, s, v;

			min = Math.Min(Math.Min(rgb.R, rgb.G), rgb.B);
			v = Math.Max(Math.Max(rgb.R, rgb.G), rgb.B);
			delta = v - min;

			if (v == 0.0)
				s = 0;
			else
				s = delta / v;

			if (s == 0)
				h = 0.0;

			else
			{
				if (rgb.R == v)
					h = (rgb.G - rgb.B) / delta;
				else if (rgb.G == v)
					h = 2 + (rgb.B - rgb.R) / delta;
				else if (rgb.B == v)
					h = 4 + (rgb.R - rgb.G) / delta;

				h *= 60;

				if (h < 0.0)
					h = h + 360;
			}

			return new HSV(h, s, (v / 255));
		}
		public static RGB HSVToRGB(HSV hsv)
		{
			double r = 0, g = 0, b = 0;

			if (hsv.S == 0)
			{
				r = hsv.V;
				g = hsv.V;
				b = hsv.V;
			}
			else
			{
				int i;
				double f, p, q, t;

				if (hsv.H == 360)
					hsv.H = 0;
				else
					hsv.H = hsv.H / 60;

				i = (int)Math.Truncate(hsv.H);
				f = hsv.H - i;

				p = hsv.V * (1.0 - hsv.S);
				q = hsv.V * (1.0 - (hsv.S * f));
				t = hsv.V * (1.0 - (hsv.S * (1.0 - f)));

				switch (i)
				{
					case 0:
						r = hsv.V;
						g = t;
						b = p;
						break;

					case 1:
						r = q;
						g = hsv.V;
						b = p;
						break;

					case 2:
						r = p;
						g = hsv.V;
						b = t;
						break;

					case 3:
						r = p;
						g = q;
						b = hsv.V;
						break;

					case 4:
						r = t;
						g = p;
						b = hsv.V;
						break;

					default:
						r = hsv.V;
						g = p;
						b = q;
						break;
				}

			}

			return new RGB((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
		}

		public static void Decompose(this Color color, out byte a, out byte r, out byte g, out byte b)
        {
            a = color.A;
            r = color.R;
            g = color.G;
            b = color.B;
        }

		public static RGB ToRGB(this Color color) 
			=> new RGB(color.R, color.G, color.B);
		public static HSV ToHSV(this Color color)
			=> RGBToHSV(color.ToRGB());
		public static Color ToColor(this RGB rgb) => Color.FromRgb(rgb.R, rgb.G, rgb.B);
		public static Color ToColor(this HSV hsv) => HSVToRGB(hsv).ToColor();
    }
}