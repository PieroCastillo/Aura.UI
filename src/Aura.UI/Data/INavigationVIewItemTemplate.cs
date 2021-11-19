using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Data
{
    public interface INavigationViewItemTemplate
    {
        public IImage Icon { get; }
        public object Content { get; }
        public object Header { get; }
        public object Title { get; }

        public IEnumerable<INavigationViewItemTemplate> Items { get; }
    }
}
