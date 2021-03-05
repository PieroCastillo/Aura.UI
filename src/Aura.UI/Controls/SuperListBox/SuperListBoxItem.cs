using Aura.UI.Attributes;
using Aura.UI.Dragging.Controls.Iteming;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Aura.UI.Controls
{
    /// <summary>
    /// This item shows a Icon, Maintext and secondarytext for the <see cref="ListBox"/> control
    /// </summary>
    public partial class SuperListBoxItem : DraggableListBoxItem
    {
        //Text 1
        /// <summary>
        /// MainText, it's ubicate in the top
        /// </summary>
        public string MainText
        {
            get => GetValue(MainTextProperty);
            set => SetValue(MainTextProperty, value);
        }

        public static readonly StyledProperty<string> MainTextProperty =
            AvaloniaProperty.Register<SuperListBoxItem, string>(nameof(MainText), "MainText");

        //Text 2
        /// <summary>
        /// Secondary Text, it's ubicate in the bottom
        /// </summary>
        public string SecondaryText
        {
            get => GetValue(SecondaryTextProperty);
            set => SetValue(SecondaryTextProperty, value);
        }

        public static readonly StyledProperty<string> SecondaryTextProperty =
            AvaloniaProperty.Register<SuperListBoxItem, string>(nameof(SecondaryText), "SecondaryText");

        /// <summary>
        /// Icon of the Item, it's recommended that use a <see cref="DrawingImage"/> like an image
        /// </summary>
        public IImage Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly StyledProperty<IImage> IconProperty =
            AvaloniaProperty.Register<SuperListBoxItem, IImage>(nameof(Icon));
    }
}