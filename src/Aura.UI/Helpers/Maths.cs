namespace Aura.UI.Helpers
{
    public static class Maths
    {
        public static double ToSexagesimalDegrees(double centesimalDegrees)
            => centesimalDegrees * 180 / 200;

        public static double Calibrate(double value, double min, double max, double old_value)
        /*=> Math.Abs(value * 100 /
            -Math.Abs(max + min));*/
        {
            //var min_n = double.IsNegative(min);
            //var max_n = double.IsNegative(max);

            //if (max_n & min_n)
            //{
            //    return value * 100 / (max - min);
            //}
            //else if (!max_n & min_n)
            //{
            //    return Math.Abs(value * 100 /max - min) / 2;
            //}
            //else if(max_n & !min_n)
            //{
            //    throw new NotImplementedException("WTF");
            //}
            //else if(!max_n & !min_n)
            //{
            //    return Math.Abs(value * 100 / (max - min)) / 2;
            //}

            //return 0;

            double range = max - min;
            double fromProgress = (old_value - min) / range;
            return ((value - min) / range) + fromProgress;
        }
    }
}