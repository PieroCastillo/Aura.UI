using Avalonia.Controls;
using Avalonia.Styling;

namespace Aura.UI.Controls.Primitives
{
    public interface IFootered : IControl
    {
        public object Footer { get; set; }
        public ITemplate FooterTemplate { get; set; }
    }
}