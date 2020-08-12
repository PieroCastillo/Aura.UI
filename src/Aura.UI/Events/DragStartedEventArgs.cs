using Aura.UI.Controls;
using Avalonia;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Events
{
    //In Developing
    public delegate void DraggingStartedEventHandler(object sender, DraggingStartedEventArgs e);
    public class DraggingStartedEventArgs : RoutedEventArgs
    {
        public DraggingStartedEventArgs(IVisual IVisualObject)
        {
            if (VisualObject == null) { throw new ArgumentNullException("VisualObject is null"); }

            VisualObject = IVisualObject;
            this.StartUbication = IVisualObject.PointToScreen(new Point(0d, 0d));
        }

        public DraggingStartedEventArgs(RoutedEvent routedEvent, IVisual IVisualObject) : base(routedEvent)
        {
            VisualObject = IVisualObject;
        }

        public DraggingStartedEventArgs(RoutedEvent routedEvent, object source, IVisual IVisualObject) : base(routedEvent, (IInteractive)source)
        {
            VisualObject = IVisualObject;
        }

        public IVisual VisualObject { get; }
        public bool IsToOut { get; protected set; }

        public DraggingStartedEventArgs DragStartedEventArgs { get { return this; } }
        public PixelPoint StartUbication { get; protected set; }
    }
}
