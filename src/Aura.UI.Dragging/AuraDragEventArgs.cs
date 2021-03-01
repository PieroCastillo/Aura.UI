using Avalonia;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Dragging
{
    public class AuraDragEventArgs : RoutedEventArgs
    {
        public Vector DragDistance
        {
            get;
            private set;
        } 
    }
}
