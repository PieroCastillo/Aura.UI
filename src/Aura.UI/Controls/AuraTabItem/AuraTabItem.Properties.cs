using Avalonia;
using Avalonia.Media;

namespace Aura.UI.Controls
{
    public partial class AuraTabItem
    {
        /// <summary>
        /// Icon of the AuraTabItem
        /// </summary>
        public IImage Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="Icon"/> property.
        /// </summary>
        public static readonly StyledProperty<IImage> IconProperty =
            AvaloniaProperty.Register<AuraTabItem, IImage>(nameof(Icon));

        /// <summary>
        /// This property sets if the AuraTabItem can be closed
        /// </summary>
        public bool IsClosable
        {
            get => GetValue(IsClosableProperty);
            set => SetValue(IsClosableProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="IsClosable"/> property.
        /// </summary>
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

        /// <summary>
        /// Defines the <see cref="IsClosing"/> property.
        /// </summary>
        public readonly static DirectProperty<AuraTabItem, bool> IsClosingProperty =
            AvaloniaProperty.RegisterDirect<AuraTabItem, bool>(nameof(IsClosing), o => o.IsClosing);

        /// <summary>
        /// Gets or Sets the CornerRadius
        /// </summary>
        public new CornerRadius CornerRadius
        {
            get => GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="CornerRadius"/> property.
        /// </summary>
        public static new readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<MaterialButton, CornerRadius>(nameof(CornerRadius), new CornerRadius(7));

        public bool CanBeDragged
        {
            get => GetValue(CanBeDraggedProperty);
            set => SetValue(CanBeDraggedProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="CanBeDragged"/> property.
        /// </summary>
        public static readonly StyledProperty<bool> CanBeDraggedProperty =
            AvaloniaProperty.Register<AuraTabItem, bool>(nameof(CanBeDragged), true);
    }
}