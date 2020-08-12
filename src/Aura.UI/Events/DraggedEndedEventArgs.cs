using Avalonia;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Events
{
    //In Developing
    public delegate void DraggingEndedEventHandler(object sender, DraggingEndedEventArgs e); 
    public class DraggingEndedEventArgs : RoutedEventArgs
    {
        public DraggingEndedEventArgs(IVisual IVisualObject, PixelPoint EndUbication)
        {
            if (VisualObject == null) { throw new ArgumentNullException("VisualObject is null"); }
            
            VisualObject = IVisualObject;
        }

        public DraggingEndedEventArgs(RoutedEvent routedEvent, IVisual IVisualObject) : base(routedEvent)
        {
            VisualObject = IVisualObject;
        }

        public DraggingEndedEventArgs(RoutedEvent routedEvent, object source, IVisual IVisualObject) : base(routedEvent, (IInteractive)source)
        {
            VisualObject = IVisualObject;
        }

        public IVisual VisualObject { get; }
        public bool IsEnded { get; protected set; }

        public RelativePoint EndUbication { get; protected set; }
    }
}
