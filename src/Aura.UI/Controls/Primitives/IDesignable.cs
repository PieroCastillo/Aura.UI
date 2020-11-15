using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.VisualTree;

namespace Aura.UI.Controls.Primitives
{
    public interface IDesignable : IControl, ILayoutable, IVisual
    {
        public bool InDesign { get; set; }
    }
}