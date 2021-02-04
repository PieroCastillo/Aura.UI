using Aura.UI.Controls.Primitives;
using Avalonia;
using Avalonia.Controls;

namespace Aura.UI.Controls.Ribbon
{
    /// <summary>
    /// This control separates the <see cref="RibbonGroup"/> in the <see cref="RibbonPanel"/>
    /// </summary>
    public class RibbonSeparator : Separator, ICustomCornerRadius
    {
        /// <summary>
        /// Defines the CornerRadius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<RibbonSeparator, CornerRadius>(nameof(CornerRadius), new CornerRadius(1));
    }
}