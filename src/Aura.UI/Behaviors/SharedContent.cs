using Avalonia.Controls;
using Avalonia.Metadata;

namespace Aura.UI.Behaviors
{
    public class SharedContent : Control
    {
        [Content]
        public object? Content { get; set; }
    }
}