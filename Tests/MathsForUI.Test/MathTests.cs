using Aura.UI.Helpers;
using Aura.UI.Neumorphism.Controls;
using Avalonia;
using Avalonia.Media;
using Avalonia.Skia;
using System;
using Xunit;
using static Aura.UI.Helpers.Maths;

namespace MathsForUI.Test
{
    public class MathTests
    {

        [Theory]
        [InlineData(0, 100, 180, 50)]
        [InlineData(-100, 100, 180, 0)]
        [InlineData(-200, -100, 180, -150)]
        public void ValueFromMinMaxAngleTest(double minimum, double maximum, double angle, double expectedValue)
        {
            Assert.Equal(expectedValue, ValueFromMinMaxAngle(angle, minimum, maximum));
        }

        [Theory]
        [InlineData(0, 100, 180, 50)]
        [InlineData(-100, 100, 180, 0)]
        [InlineData(-200, -100, 180, -150)]
        public void AngleFromMinMaxValueTest(double minimum, double maximum, double expectedAngle, double value)
        {
            Assert.Equal(expectedAngle, AngleFromMinMaxValue(value, minimum, maximum));
        }

        [Theory]
        [InlineData(7, 19, 16, 167)]
        [InlineData(7, 8, 19, 235)]
        [InlineData(221, 44, 185, 312)]
        public void HueFromColor(double r, double g, double b, double h)
        {
            Assert.Equal(h, GetHue(r, g, b));
        }

        [Theory]
        [InlineData(200, 200, 0, 20)]
        public void ThicknessTests(double width, double height, double p, double strokeWidth)
        {
            var size = new Size(width, height);
            var padding = new Thickness(p);
            var r = size.WithHeight(Maths.TriangleHeightBySide(size.Width)).Inflate(padding + new Thickness(strokeWidth));
        }

        [Theory]
        [InlineData("#ffffff", 0.6, "#ffffff", "#666666")]
        [InlineData("#ffffff", 0.08, "#ffffff", "#ebebeb")]
        [InlineData("#a34d4d", 0.33, "#d96666", "#6d3434")]
        public void ColorLuminanceTests(string baseColor, double intensity, string expectedLightColor, string expectedDarkColor)
        {
            var color = Color.Parse(baseColor).ToSKColor();

            var light = Neumor.ChangeColorLuminosity(color, intensity);
            var dark = Neumor.ChangeColorLuminosity(color, intensity * -1);

            Assert.Equal(light.ToString(), Color.Parse(expectedLightColor).ToSKColor().ToString());
        }
    }
}
