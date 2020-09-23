using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Events
{
    [Obsolete]
    public class SliderClickedEventArgs : EventArgs
    {
        public SliderClickedEventArgs(double position)
        {
            Position = position;
        }

        public double Position { get; set; }
    }
}
