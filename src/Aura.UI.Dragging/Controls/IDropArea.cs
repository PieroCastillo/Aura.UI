using Avalonia.Controls;
using Avalonia.LogicalTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Dragging.Controls
{
   public interface IDropArea : IControl, ILogical
    {
        public void AddPreview(IControl preview);
        public bool RemovePreview(IControl preview);
        public bool CanAddDraggable(IDraggable draggable);
        public void AddDraggable(IDraggable draggable);
        public bool RemoveDraggable(IDraggable draggable);
    }
}
