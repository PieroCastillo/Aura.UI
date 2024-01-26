using Avalonia;
using Avalonia.Media;

namespace Aura.UI.Controls.Primitives
{
    public interface IMaterial
    {
        public ExperimentalAcrylicMaterial Material { get; set; }
        public bool MaterialIsVisible { get; set; }
    }
}