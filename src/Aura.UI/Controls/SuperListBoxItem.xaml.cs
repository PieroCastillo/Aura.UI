using Aura.UI.Attributes;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace Aura.UI.Controls
{
    /// <summary>
    /// This item shows a Icon, Maintext and secondarytext for the <see cref="ListBox"/> control
    /// </summary>
    [Experimental]
    [TemplatePart(Name = "PART_PrincipalText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_SecondaryText", Type = typeof(TextBlock))]
    public class SuperListBoxItem : ListBoxItem
    {
        public SuperListBoxItem()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        //Text 1
        /// <summary>
        /// MainText, it's ubicate in the top
        /// </summary>
        public string MainText
        {
            get { return GetValue(MainTextProperty); }
            set { SetValue(MainTextProperty, value); }
        }
        public static readonly StyledProperty<string> MainTextProperty =
            AvaloniaProperty.Register<SuperListBoxItem, string>(nameof(MainText),"MainText");
        //Text 2
        /// <summary>
        /// Secondary Text, it's ubicate in the bottom
        /// </summary>
        public string SecondaryText
        {
            get { return GetValue(SecondaryTextProperty); }
            set { SetValue(SecondaryTextProperty, value); }
        }
        public static readonly StyledProperty<string> SecondaryTextProperty =
            AvaloniaProperty.Register<SuperListBoxItem, string>(nameof(SecondaryText), "SecondaryText");
        /// <summary>
        /// Icon of the Item, it's recommended that use a <see cref="DrawingImage"/> like an image
        /// </summary>
        public IImage Icon
        {
            get { return GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly StyledProperty<IImage> IconProperty =
            AvaloniaProperty.Register<SuperListBoxItem, IImage>(nameof(Icon));

    }
}
