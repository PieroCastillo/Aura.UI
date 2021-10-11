using Aura.UI.Controls.Legacy;
using Avalonia;
using Avalonia.Media;

namespace Aura.UI.Controls.Navigation
{
    public partial class NavigationViewLinker
    {
        public IImage Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public readonly static StyledProperty<IImage> IconProperty =
            SuperListBoxItem.IconProperty.AddOwner<NavigationViewLinker>();

        public string Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly StyledProperty<string> TitleProperty =
            AvaloniaProperty.Register<NavigationViewLinker, string>(nameof(Title), "NavigationView Linker");

        public object? TopContent
        {
            get => GetValue(TopContentProperty);
            set => SetValue(TopContentProperty, value);
        }

        public readonly static StyledProperty<object?> TopContentProperty =
            AvaloniaProperty.Register<NavigationViewLinker, object?>(nameof(TopContent), null);

        private NavigationViewItemBase _linkto;

        public NavigationViewItemBase LinkTo
        {
            get => _linkto;
            set => SetAndRaise(LinkToProperty, ref _linkto, value);
        }

        public readonly static DirectProperty<NavigationViewLinker, NavigationViewItemBase> LinkToProperty =
            AvaloniaProperty.RegisterDirect<NavigationViewLinker, NavigationViewItemBase>(nameof(LinkTo),
                                                                                          o => o.LinkTo,
                                                                                          (o, v) => o.LinkTo = v);

        private bool _topcontentVisible;

        public bool TopContentVisible
        {
            get => _topcontentVisible;
            private set => SetAndRaise(TopContentIsNullProperty, ref _topcontentVisible, value);
        }

        public readonly static DirectProperty<NavigationViewLinker, bool> TopContentIsNullProperty =
            AvaloniaProperty.RegisterDirect<NavigationViewLinker, bool>(nameof(TopContentVisible), o => o.TopContentVisible);
    }
}