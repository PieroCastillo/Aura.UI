using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;
using Avalonia.Controls.Primitives;

namespace Aura.UI.Controls
{
    public class AuraTrack : HeaderedSelectingItemsControl, ISelectable
    {
        static AuraTrack()
        {
            SelectableMixin.Attach<AuraTrack>(IsSelectedProperty);
        }
        public bool IsSelected
        {
            get => GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public static readonly StyledProperty<bool> IsSelectedProperty =
                AvaloniaProperty.Register<AuraTrack, bool>(nameof(IsSelected), false);
    }
}