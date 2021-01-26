using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

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
            get { return GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<GroupBox, CornerRadius>(nameof(CornerRadius), new CornerRadius(7));

    }
}
