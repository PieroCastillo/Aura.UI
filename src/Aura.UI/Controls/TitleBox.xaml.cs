using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Aura.UI.UIExtensions;
using Aura.UI.Attributes;

namespace Aura.UI.Controls
{
    /// <summary>
    /// It's similar to <see cref="GroupBox"/>, but has a Two button on the TopRight
    /// </summary>
    [TemplatePart(Name = "PART_B1", Type = typeof(Button))]
    [TemplatePart(Name = "PART_B2", Type = typeof(Button))]
    public class TitleBox : HeaderedContentControl
    {
        Button B1;
        Button B2;
        public TitleBox()
        {
            this.InitializeComponent();
            
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            B1 = this.GetControl<Button>(e, "PART_B1");
            B2 = this.GetControl<Button>(e, "PART_B2");
            B1.Click += B1_Click;
            B2.Click += B2_Click;
        }

        protected void B2_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.OnClickInButton2();
        }

        protected void B1_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.OnClickInButton1();
        }
 
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

         #region Properties    
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
        #endregion

        /// <summary>
        /// Do something when the first button is clicked
        /// </summary>
        public virtual void OnClickInButton1() { }
        /// <summary>
        /// Do something when the second button is clicked
        /// </summary>
        public virtual void OnClickInButton2() { }
    }
}
