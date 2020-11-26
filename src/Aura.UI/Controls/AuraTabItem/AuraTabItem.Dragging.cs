using Aura.UI.Helpers;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Native;
using Avalonia.Skia;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Aura.UI.Dragging;
using Avalonia.Collections;
using Avalonia.LogicalTree;
using SkiaSharp;

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

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            this.IsSelected = true;
            var tabitem = (e.Source as ILogical).GetParentTOfLogical<AuraTabItem>(); // sets the source
            if (this.GetParentTOfLogical<AuraTabView>() != null)
            {
                if (tabitem != null)
                {
                    var n = new ControlObject(tabitem);
                    DragDrop.DoDragDrop(e, n, DragDropEffects.Move);
                    Debug.WriteLine("Drag started");
                }
            }

            e.Handled = true;
        }

        protected virtual void OnDragStarted(object sender, DragEventArgs e)
        {

        }
        
        protected virtual void OnDragOver(object sender, DragEventArgs e)
        {
            
        }

        protected virtual void OnDragLeave(object sender, RoutedEventArgs e)
        {
            
        }

        protected virtual void OnDrop(object sender, DragEventArgs e)
        {
            if (CanBeDragged)
            {
                ItemsControlOperations.MoveItemOnDrop<AuraTabView, AuraTabItem>(
                    sender, 
                    e,
                    (view,src,item) =>
                    {
                        int h = (view.Items as IList).IndexOf(item);

                        item.RenderTransform = null;
                        
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
}
