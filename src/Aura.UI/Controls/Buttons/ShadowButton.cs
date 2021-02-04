using Avalonia;
using Avalonia.Media;

namespace Aura.UI.Controls
{
    public class ShadowButton : MaterialButton
    {
        /// <summary>
        /// Defines the padding of the Shadow
        /// </summary>
        public Thickness ShadowPadding
        {
            get => GetValue(ShadowPaddingProperty);
            set => SetValue(ShadowPaddingProperty, value);
        }

        public static readonly StyledProperty<Thickness> ShadowPaddingProperty =
            AvaloniaProperty.Register<ShadowButton, Thickness>(nameof(ShadowPadding), new Thickness(5));

        /// <summary>
        /// Gets or sets the <see cref="BoxShadow"/> of the Button
        /// </summary>
        public BoxShadows BoxShadow
        {
            get => GetValue(BoxShadowProperty);
            set => SetValue(BoxShadowProperty, value);
        }

        public static readonly StyledProperty<BoxShadows> BoxShadowProperty =
            AvaloniaProperty.Register<ShadowButton, BoxShadows>(nameof(BoxShadow));
    }
}