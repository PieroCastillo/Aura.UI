using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Aura.UI.Dragging.Controls
{
    public class DragDropBorder : Border
    {
        public DragDropBorder()
        {
            DragDrop.SetAllowDrop(this, true);
        }
        static DragDropBorder()
        {
            EnableDragDrop();
        }

        static void EnableDragDrop()
        {
            DragDrop.DragEnterEvent.AddClassHandler<DragDropBorder>((x, e) => x.OnDragStarted(x,e));
            DragDrop.DragOverEvent.AddClassHandler<DragDropBorder>((x, e) => x.OnDragDelta(x, e));
            DragDrop.DragLeaveEvent.AddClassHandler<DragDropBorder>((x, e) => x.OnDragLeave(x, e));
            DragDrop.DropEvent.AddClassHandler<DragDropBorder>((x, e) => x.OnDrop(x, e));
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            ControlObject controlObject = new ControlObject(this.Child as Control);
            DragDrop.DoDragDrop(e, controlObject, DragDropEffects.Move);
            e.Handled = true;
        }

        protected virtual void OnDragStarted(DragDropBorder sender, DragEventArgs e)
        {

        }

        protected virtual void OnDragDelta(DragDropBorder sender, DragEventArgs e)
        {

        }

        protected virtual void OnDragLeave(DragDropBorder sender, RoutedEventArgs e)
        {

        }

        protected virtual void OnDrop(DragDropBorder sender, DragEventArgs e)
        {
            var b_sender = e.Source as DragDropBorder;
            var b_receiver = e.Data.Get(nameof(Control)) as DragDropBorder;

            if (sender is not DragDropBorder || b_receiver is null)
            {
                Debug.WriteLine("Returned");
                return;
            }

            Debug.WriteLine("I was dropped");

            var child1 = b_sender.Child;
            var child2 = b_receiver.Child;

            b_sender.Child = null;
            b_receiver.Child = null;

            b_sender.Child = child2;
            b_receiver.Child = child1;
        }
    }
}
