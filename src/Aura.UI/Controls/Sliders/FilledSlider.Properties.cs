using Avalonia;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;

namespace Aura.UI.Controls
{
    public partial class FilledSlider
    {
        /// <summary>
        /// Template for the Thumb of the <see cref="FilledSlider"/>
        /// </summary>
        public ControlTemplate ThumbTemplate
        {
            get => GetValue(ThumbTemplateProperty);
            set => SetValue(ThumbTemplateProperty, value);
        }

        public static readonly StyledProperty<ControlTemplate> ThumbTemplateProperty =
            AvaloniaProperty.Register<FilledSlider, ControlTemplate>(nameof(ThumbTemplate));

        /// <summary>
        /// Shows a content in the right
        /// </summary>
        public object RightContent
        {
            get => GetValue(RightContentProperty);
            set => SetValue(RightContentProperty, value);
        }

        public static readonly StyledProperty<object> RightContentProperty =
            AvaloniaProperty.Register<FilledSlider, object>(nameof(RightContent), "Right");

        /// <summary>
        /// Shows a content in the left
        /// </summary>
        public object LeftContent
        {
            get => GetValue(LeftContentProperty);
            set => SetValue(LeftContentProperty, value);
        }

        public static readonly StyledProperty<object> LeftContentProperty =
            AvaloniaProperty.Register<FilledSlider, object>(nameof(LeftContent), "Left");
    }
}