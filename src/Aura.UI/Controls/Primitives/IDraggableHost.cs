using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.VisualTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Primitives
{
    public interface IDraggableHost : IControl, IVisual, ILayoutable
    {
        void Receive(ref IDraggable DraggableObject);
        Point GetElementPosition();
    }
}
