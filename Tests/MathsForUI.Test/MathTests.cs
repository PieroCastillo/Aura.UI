using Avalonia;
using System;
using Xunit;
using static Aura.UI.Helpers.Maths;

namespace MathsForUI.Test
{
    public class MathTests
    {
        [Theory]
        [InlineData(0,     100, 180,   50)]
        [InlineData(-100,  100, 180,    0)]
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
    }
}
