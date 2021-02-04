using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aura.UI.Helpers
{
    public class GradientCalculator
    {
        /// <summary>
        /// Return a GradientStops with Dynamic Offsets
        /// </summary>
        /// <param name="stops">These are the GradientStops to Configure</param>
        /// <param name="offsetmodifier">This parameter modifiers the GradientStops offset</param>
        /// <returns></returns>
        public static IList<GradientStop> ConfigureStopsWithDynamicOffsets(IList<GradientStop> stops, double offsetmodifier = 0.5)
        {
            var counter = stops.Count();
            try
            {
                foreach (GradientStop stop in stops)
                {
                    //if(Gradients.Count() > 0)
                    //{
                    // for (int i = 0; i == Gradients.Count(); i++)
                    // {
                    // Gradients[Gradients.Get].Offset = (1 / (Gradients.Count() - 1 )) * i;
                    // }
                    //}
                    stop.Offset = (1 / (counter - 1)) * stops.IndexOf(stop);
                }
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(" \"stops\" parameter is null or it does not have GradientStops", e);
            }
            return null;
        }
    }
}