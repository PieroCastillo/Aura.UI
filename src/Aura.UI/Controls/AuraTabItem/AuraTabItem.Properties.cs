using Avalonia;

namespace Aura.UI.Controls
{
    public partial class AuraTabItem
    {
        /// <summary>
        /// This property defines if the AuraTabItem can be closed
        /// </summary>
        public bool IsClosable
        {
            get { return GetValue(IsClosableProperty); }
            set { SetValue(IsClosableProperty, value); }
        }

        public static readonly StyledProperty<bool> IsClosableProperty =
            AvaloniaProperty.Register<AuraTabItem, bool>(nameof(IsClosable), true);

        private bool _isclosing = false;

        /// <summary>
        /// Returns if the tab is closing.
        /// </summary>
        public bool IsClosing
        {
            get => _isclosing;
            private set => SetAndRaise(IsClosingProperty, ref _isclosing, value);
        }

        public readonly static DirectProperty<AuraTabItem, bool> IsClosingProperty =
            AvaloniaProperty.RegisterDirect<AuraTabItem, bool>(nameof(IsClosing), o => o.IsClosing);

        /// <summary>
        /// Defines the CornerRadius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<MaterialButton, CornerRadius>(nameof(CornerRadius), new CornerRadius(7));

        public bool CanBeDragged
        {
            get => GetValue(CanBeDraggedProperty);
            set => SetValue(CanBeDraggedProperty, value);
        }

        public static readonly StyledProperty<bool> CanBeDraggedProperty =
            AvaloniaProperty.Register<AuraTabItem, bool>(nameof(CanBeDragged), true);
    }
}