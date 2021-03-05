using Avalonia.Controls;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.DraggableListBox
{
    public class DraggableListBox : ListBox
    {
        protected virtual void OnDragMove(object sender, DragEventArgs e)
        {
            var lst_item = sender as DraggableListBoxItem;
            if(lst_item is null)
            {
                e.DragEffects = DragDropEffects.None;
                return;
            }

            
        }
    }
}
