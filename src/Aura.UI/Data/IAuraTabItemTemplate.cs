using Avalonia.Media;

namespace Aura.UI.Data
{
    public interface IAuraTabItemTemplate
    {
        public object Content { get; }
        public object Header { get; }
        public bool IsClosable { get; }
        public IImage Icon { get; }
    }
}