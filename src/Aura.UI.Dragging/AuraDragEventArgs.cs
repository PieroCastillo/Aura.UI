using Aura.UI.Dragging.Maths;
using Avalonia;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Dragging
{
    public class AuraDragEventArgs : RoutedEventArgs
    {
        public AuraDragEventArgs(RoutedEvent e) : base(e)
        {

        }

        public Point DragStartPoint
        {
            get;
            private set;
        }

        public Vector DragDistance
        {
            get;
            private set;
        } 

        public double DragDistanceModule
        {
            get;
            private set;
        }

        public static AuraDragEventArgs Create(RoutedEvent e, Point startPoint, Point finalPoint)
            => new(e) { DragStartPoint = startPoint, DragDistance = finalPoint, DragDistanceModule = startPoint.Module(finalPoint) };
    }
}
