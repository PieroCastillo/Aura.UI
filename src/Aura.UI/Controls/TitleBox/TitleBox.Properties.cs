using Avalonia;

namespace Aura.UI.Controls
{
    public partial class TitleBox
    {
        /// <summary>
        /// Content of the primary button
        /// </summary>
        public object Button1Content
        {
            get { return GetValue(Button1ContentProperty); }
            set { SetValue(Button1ContentProperty, value); }
        }

        public static readonly StyledProperty<object> Button1ContentProperty =
            AvaloniaProperty.Register<TitleBox, object>(nameof(Button1Content), "1");

        /// <summary>
        /// Content of the secondary button
        /// </summary>
        public object Button2Content
        {
            get { return GetValue(Button2ContentProperty); }
            set { SetValue(Button2ContentProperty, value); }
        }

        public static readonly StyledProperty<object> Button2ContentProperty =
            AvaloniaProperty.Register<TitleBox, object>(nameof(Button2Content), "2");

        /// <summary>
        /// Defines if the primary button is visible
        /// </summary>
        public bool Button1Active
        {
            get { return GetValue(Button1ActiveProperty); }
            set { SetValue(Button1ActiveProperty, value); }
        }

        public static readonly StyledProperty<bool> Button1ActiveProperty =
            AvaloniaProperty.Register<TitleBox, bool>(nameof(Button1Active), true);

        /// <summary>
        /// Defines if the secondary button is visible
        /// </summary>
        public bool Button2Active
        {
            get { return GetValue(Button2ActiveProperty); }
            set { SetValue(Button2ActiveProperty, value); }
        }

        public static readonly StyledProperty<bool> Button2ActiveProperty =
            AvaloniaProperty.Register<TitleBox, bool>(nameof(Button2Active), true);

        /// <summary>
        /// Defines the CornerRadius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<MaterialButton, CornerRadius>(nameof(CornerRadius), new CornerRadius(2.5));
    }
}