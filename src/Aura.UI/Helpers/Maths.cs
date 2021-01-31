using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Helpers
{
    public static class Maths
    {
        public static double ToSexagesimalDegrees(double centesimalDegrees) 
            => centesimalDegrees * 180 / 200;

        public static double Calibrate(double value, double min, double max) 
            => value * 100 / (max - min);
        
    }
}
