using Avalonia.Media;
using System.Collections.Generic;

namespace Aura.UI.Data
{
    public interface INavigationViewItemTemplate
    {
        public IImage Icon { get; }
        public object Content { get; }
        public object Header { get; }
        public object Title { get; }

        public IList<INavigationViewItemTemplate> Items { get; }
    }
}
