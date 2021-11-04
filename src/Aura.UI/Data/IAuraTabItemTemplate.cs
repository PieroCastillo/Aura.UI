using Avalonia.Media;

namespace Aura.UI.Data
{
    public interface IAuraTabItemTemplate
    {
        public bool IsClosable { get; }
        public IImage Icon { get; }
    }
}