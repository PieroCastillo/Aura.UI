using System;
using System.Runtime.InteropServices;
using Avalonia;
using  Avalonia.Utilities;

namespace Aura.UI.Lighting
{
    public struct LightPoint
    {
        double? _x;
        double? _y;
        LightDefaultPositions? _p;
        public LightPoint(double x, double y)
        {
            _x = x;
            _y = y;
            _p = null;
        }

        public LightPoint(LightDefaultPositions lightDefaultPositions)
        {
            _p = lightDefaultPositions;
            _x = null;
            _y = null;
        }

        /// <summary>
        /// Gets the value of struct
        /// </summary>
        /// <returns>Returns a point when the value is custom or returns a <see cref="LightDefaultPositions"/> when the value is predefined</returns>
        public object GetValue()
        {
            if (_x.HasValue & _y.HasValue)
            {
                return new Point(_x.Value, _y.Value);
            }
            if (_p.HasValue)
            {
                return _p.Value;
            }
            else
            {
                throw new NotImplementedException("");
            }
        }

        public static LightPoint Parse(string s)
        {
            s = s.ToUpperInvariant();

            if (s == "CENTER")
            {
                return new LightPoint(LightDefaultPositions.Center);
            }
            else if(s == "TOPLEFT")
            {
                return new LightPoint(LightDefaultPositions.TopLeft);
            }
            else if(s == "TOPRIGHT")
            {
                return new LightPoint(LightDefaultPositions.TopRight);
            }
            else if(s == "BOTTOMLEFT")
            {
                return new LightPoint(LightDefaultPositions.BottomLeft);
            }
            else if(s == "BOTTOMRIGHT")
            {
                return new LightPoint(LightDefaultPositions.BottomRight);
            }
        }
    }

    public enum LightDefaultPositions
    {
        Center,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}