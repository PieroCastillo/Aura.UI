using Aura.UI.Dragging.Maths;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Dragging.Controls
{
    public class Draggable : ContentControl, IDraggable
    {
        private Point? StartPoint;
        private bool started = false;

        public Draggable()
        {
            PointerLeave += delegate
            {
                LeaveDragging();
            };
            PointerCaptureLost += delegate
            {
                LeaveDragging();
            };
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            started = true;
            if(StartPoint == null)
            {
                StartPoint = e.GetPosition(this);
                RaiseEvent(AuraDragEventArgs.Create(DragStartedEvent, StartPoint.Value, StartPoint.Value));
                return;
            }
            RaiseEvent(AuraDragEventArgs.Create(DragDeltaEvent, StartPoint.Value, e.GetPosition(this)));
        }

        private void LeaveDragging()
        {
            started = false;
            StartPoint = null;
            var e_ = new AuraDragEventArgs(DragLeaveEvent);
            RaiseEvent(e_);
        }



        public event EventHandler<AuraDragEventArgs> DragStarted
        {
            add => AddHandler(DragStartedEvent, value);
            remove => RemoveHandler(DragStartedEvent, value);
        }

        public static readonly RoutedEvent<AuraDragEventArgs> DragStartedEvent =
            RoutedEvent.Register<Draggable, AuraDragEventArgs>(nameof(DragStarted), RoutingStrategies.Bubble);

        public event EventHandler<AuraDragEventArgs> DragDelta
        {
            add => AddHandler(DragDeltaEvent, value);
            remove => RemoveHandler(DragDeltaEvent, value);
        }

        public static readonly RoutedEvent<AuraDragEventArgs> DragDeltaEvent =
            RoutedEvent.Register<Draggable, AuraDragEventArgs>(nameof(DragDelta), RoutingStrategies.Bubble); 
        
        public event EventHandler<AuraDragEventArgs> DragLeave
        {
            add => AddHandler(DragLeaveEvent, value);
            remove => RemoveHandler(DragLeaveEvent, value);
        }

        public static readonly RoutedEvent<AuraDragEventArgs> DragLeaveEvent =
            RoutedEvent.Register<Draggable, AuraDragEventArgs>(nameof(DragLeave), RoutingStrategies.Bubble); 
        
        public event EventHandler<AuraDragEventArgs> Drop
        {
            add => AddHandler(DropEvent, value);
            remove => RemoveHandler(DropEvent, value);
        }

        public static readonly RoutedEvent<AuraDragEventArgs> DropEvent =
            RoutedEvent.Register<Draggable, AuraDragEventArgs>(nameof(Drop), RoutingStrategies.Bubble);
    }
}
