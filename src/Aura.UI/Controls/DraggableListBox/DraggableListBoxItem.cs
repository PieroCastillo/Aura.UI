using Aura.UI.Dragging;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Aura.UI.Controls
{
    public partial class DraggableListBoxItem : ListBoxItem
    {
        public DraggableListBoxItem()
        {
            DragDrop.SetAllowDrop(this, true);
            AddHandler(DragDrop.DragEnterEvent, OnDragEnter);
            AddHandler(DragDrop.DragOverEvent, OnDragMove);
            AddHandler(DragDrop.DragLeaveEvent, OnDragLeave);
            AddHandler(DragDrop.DropEvent, OnDrop);
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            DragDrop.DoDragDrop(e, new ControlObject(this), DragDropEffects.Move);
        }

        protected virtual void OnDragEnter(object sender, DragEventArgs e)
        {
            var lst_item = sender as DraggableListBoxItem;

            if (lst_item == null)
            {
                e.DragEffects = DragDropEffects.None;
                return;
            }

            Opacity = Opacity * 0.5;
        }

        protected virtual void OnDragMove(object sender, DragEventArgs e)
        {
            var lst_item = sender as DraggableListBoxItem;

            if (lst_item == null)
            {
                e.DragEffects = DragDropEffects.None;
                return;
            }
        }

        protected virtual void OnDragLeave(object sender, RoutedEventArgs e)
        {
            Opacity = Opacity / 0.5;
        }

        protected virtual void OnDrop(object sender, DragEventArgs e)
        {
        }
    }
}