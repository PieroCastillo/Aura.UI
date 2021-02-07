using Aura.UI.Controls.Primitives;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace Aura.UI.Controls
{
    /// <summary>
    /// title and content in a single control
    /// </summary>
    public class GroupBox : HeaderedContentControl, ICustomCornerRadius
    {
        /// <summary>
        /// Defines the CornerRadious
        /// </summary>
        public CornerRadius CornerRadius
        {
            get => GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<GroupBox, CornerRadius>(nameof(CornerRadius), new CornerRadius(7));
    }
}