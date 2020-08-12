using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Interactivity;
using Avalonia.Input;
using Aura.UI.Events;
using Avalonia.VisualTree;
using Avalonia.Controls;
using Avalonia.Layout;

namespace Aura.UI.Controls.Primitives
{
    /// <summary>
    /// The Interface "IDraggable" should implement the next methods: 
    /// void OnDraggingStarted(object DraggedObject, DraggingStartedEventArgs draggingStartedEventArgs);
    /// void OnDraggingEnded(object DraggedObject, DraggingEndedEventArgs draggingEndedEventArgs);
    /// </summary>
    public interface IDraggable : IControl, IVisual, ILayoutable
    {
        // Event Handlers
        public delegate void DraggingStartedHandler(object DraggedObject, DraggingStartedEventArgs draggingStartedEventArgs);
        public delegate void DraggingEndedHandler(object DraggedObject, DraggingEndedEventArgs draggingEndedEventArgs);

        // Events
        public event EventHandler<DraggingStartedEventArgs> DraggingStarted;
        public event EventHandler<DraggingEndedEventArgs> DraggingEnded;

        // Event Methods 
        void DragTo(IDraggableHost Host);
    }
}
