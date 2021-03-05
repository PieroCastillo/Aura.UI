using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Dragging.Controls
{
    public class DropperBorder : Border, IDropArea
    {
        public void AddDraggable(IDraggable draggable)
        {
            Child = draggable;
        }

        public void AddPreview(IControl preview)
        {
            Child = preview;
        }

        public bool CanAddDraggable(IDraggable draggable) => true;

        public bool RemoveDraggable(IDraggable draggable) => true;

        public bool RemovePreview(IControl preview) => true;
    }
}
