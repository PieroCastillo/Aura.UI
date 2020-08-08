using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Events
{
    //In Developing
    public class DragStartedEventArgs : EventArgs
    {
        public bool IsCompleted { get; set; }
        public bool IsToOut { get; set; }
    }
}
