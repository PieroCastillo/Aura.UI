using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.VisualTree;

namespace Aura.UI.Controls.Primitives
{
    public interface IHuePicker: ITemplatedControl, IControl, ILogical, IVisual, ILayoutable
    {
        public Color Hue { get; set; }
        public double Saturation { get; set; }
        public double ValueColor { get; set; }
    }
}
