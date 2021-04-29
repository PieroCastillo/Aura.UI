using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Aura.UI.Controls.Navigation
{
    public partial class NavigationViewItemBase
    {
        public object Content
        {
            get => _content;
            set => SetAndRaise(ContentProperty, ref _content, value);
        }

        public static readonly DirectProperty<NavigationViewItemBase, object> ContentProperty =
            AvaloniaProperty.RegisterDirect<NavigationViewItemBase, object>(
                nameof(Content),
                o => o.Content,
                (o, v) => o.Content = v);

        private IImage _icon;

        public IImage Icon
        {
            get => _icon;
            set => SetAndRaise(IconProperty, ref _icon, value);
        }

        public readonly static DirectProperty<NavigationViewItemBase, IImage> IconProperty =
            AvaloniaProperty.RegisterDirect<NavigationViewItemBase, IImage>(
                nameof(Icon),
                o => o.Icon,
                (o, v) => o.Icon = v);

        private object _title = "Title";

        public object Title
        {
            get => _title;
            set => SetAndRaise(TitleProperty, ref _title, value);
        }

        public static readonly DirectProperty<NavigationViewItemBase, object> TitleProperty =
            AvaloniaProperty.RegisterDirect<NavigationViewItemBase, object>(
                nameof(Title),
                o => o.Title,
                (o, v) => o.Title = v);

        public bool IsOpen
        {
            get => GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        public static readonly StyledProperty<bool> IsOpenProperty =
            AvaloniaProperty.Register<NavigationViewItemBase, bool>(nameof(IsOpen), true);

        public bool SelectOnClose
        {
            get => GetValue(SelectOnCloseProperty);
            set => SetValue(SelectOnCloseProperty, value);
        }

        public static readonly StyledProperty<bool> SelectOnCloseProperty =
            AvaloniaProperty.Register<NavigationViewItemBase, bool>(nameof(SelectOnClose), false);

        public ClickMode ClickMode
        {
            get => GetValue(ClickModeProperty);
            set => SetValue(ClickModeProperty, value);
        }

        public static readonly StyledProperty<ClickMode> ClickModeProperty =
            Button.ClickModeProperty.AddOwner<NavigationViewItemBase>();
    }
}