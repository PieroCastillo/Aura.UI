using Avalonia.Controls;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Dragging.Controls.Iteming
{
    public class ItemsDraggingImplement
    {
        public static void Implement<T>(Control control, DragDropEffects effect = DragDropEffects.None, double opacityPreview = 0.5, bool selectItem = true) where T : Control
        {
            DragDrop.SetAllowDrop(control, true);
            DragDrop.DropEvent.AddClassHandler<T>((x,e) => { OnDrop(control, e) });


            control.PointerPressed += (s, e) =>
            {
                DragDrop.DoDragDrop(e, new ControlObject(control), effect);
            };
        }

        protected static void OnDrop(object sender, DragEventArgs e)
        {
            var control = sender as Control;
            var receiver = e.Source as Control;

        }
    }
}
