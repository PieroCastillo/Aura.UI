using Aura.UI.UIExtensions;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Collections;
using System.Diagnostics;
using Aura.UI.Dragging;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Primitives.PopupPositioning;
using Avalonia.LogicalTree;

namespace Aura.UI.Controls
{
    public partial class AuraTabItem
    {
        internal void EnableDragDrop()
        {
            DragDrop.SetAllowDrop(this, true);
            AddHandler(DragDrop.DragEnterEvent, OnDragStarted);
            AddHandler(DragDrop.DragLeaveEvent, OnDragLeave);
            AddHandler(DragDrop.DragOverEvent, OnDragOver);
            AddHandler(DragDrop.DropEvent, OnDrop);
        }

        static AuraTabItem()
        {
            RenderTransformProperty.OverrideDefaultValue<AuraTabItem>(new TranslateTransform(0,0));
        }
        
        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            this.IsSelected = true;
            var tabitem = (e.Source as ILogical).GetParentTOfLogical<AuraTabItem>(); // sets the source
            if (this.GetParentTOfLogical<AuraTabView>() != null & tabitem != null & CanBeDragged)
            {
                var n = new ControlObject(tabitem);
                DragDrop.DoDragDrop(e, n, DragDropEffects.Move);


                Debug.WriteLine("Drag started");
                //PseudoClasses.Add(":dragging");
            }
            e.Handled = true;
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);

            PseudoClasses.Remove(":dragging");
        }

        protected override void OnPointerCaptureLost(PointerCaptureLostEventArgs e)
        {
            base.OnPointerCaptureLost(e);

            PseudoClasses.Remove(":dragging");
        }

        protected override void OnPointerLeave(PointerEventArgs e)
        {
            base.OnPointerLeave(e);

            PseudoClasses.Remove(":dragging");            
        }

        protected virtual void OnDragStarted(object sender, DragEventArgs e)
        {
            PseudoClasses.Add(":dragging");
        }
        
        protected virtual void OnDragOver(object sender, DragEventArgs e)
        {
            
        }

        protected virtual void OnDragLeave(object sender, RoutedEventArgs e)
        {
            PseudoClasses.Remove(":dragging");
        }
        
        protected virtual void OnDrop(object sender, DragEventArgs e)
        {
            ItemsControlOperations.MoveItemOnDrop<AuraTabView, AuraTabItem>(
                sender, 
                e,
                (view,src,item) =>
                {
                    int h = (view.Items as IList).IndexOf(item);

                    
                    item.PseudoClasses.Remove(":dragging");
                    view.lastselectindex = view.SelectedIndex;
                    view.SelectedIndex = h;
                    view.SelectedItem = (view.Items as IList)[view.SelectedIndex];
                } );
            Debug.WriteLine("Drag completed");
            Debug.WriteLine($"Selected Index: {this.GetParentTOfLogical<AuraTabView>().SelectedIndex}");
            Debug.WriteLine($"Tab Index: {(this.GetParentTOfLogical<AuraTabView>().Items as IList).IndexOf(this)}");
        }


    }
}
