using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.LogicalTree;

namespace Aura.UI.Dragging
{
    public static class ItemsControlOperations
    {
        public static void MoveItemOnDrop<TItemsControl, TControlItem>(
            object sender,
            DragEventArgs e,
            Action<TItemsControl,TControlItem ,TControlItem> ToDo)
            where TItemsControl : ItemsControl 
            where TControlItem : Control
        {
                var src = sender as TControlItem; // sets the source
                var target = e.Data.Get(nameof(Control)) as TControlItem;// sets the target to drop

            if (src.Parent != target.Parent)
                return;

            if (!target.Equals(src))//checks it
            {
                var parent = src.GetSelfAndLogicalAncestors().OfType<TItemsControl>().FirstOrDefault<TItemsControl>(); //gets the parent 

                Contract.Requires<NullReferenceException>(parent != null);
                
                int s_i = (parent.Items as IList).IndexOf(src);
                int t_i = (parent.Items as IList).IndexOf(target);

                if (parent is SelectingItemsControl s)
                {
                    s.SelectedItem = null;
                    s.SelectedIndex = -1;
                }
                ItemsControlOperations.OperateItemsIndex(parent.Items as IList<object>, s_i, t_i);
                
                ToDo.Invoke(parent,src,target);
            }
        }

        private static void OperateItemsIndex(IList<object> items, int srcindex, int targetindex) 
        {
            if(items is IAvaloniaList<object>)
            {
                (items as IAvaloniaList<object>).Move(targetindex, srcindex);
            }
            else
            {
                throw new NullReferenceException($"The items collection is not {nameof(IAvaloniaList<object>)}");
            }
        }
    }
}