using Aura.UI.Attributes;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Aura.UI.Controls
{
    /// <summary>
    /// A powered-up TabControl
    /// For add a new Tab by code use the <see cref="AuraTabView.AdderButton"/>
    /// </summary>
    [TemplatePart(Name = "PART_AdderButton", Type = typeof(Button))]
    public class AuraTabView : TabControl
    {
        /// <summary>
        /// This Button add a new TabItem
        /// </summary>
        public Button AdderButton;
        /// <summary>
        /// You should overwrite this Method for add your custom tabitem
        /// </summary>
        /// <param name="sender">the sender object</param>
        /// <param name="e">the information of the event</param>
        protected virtual void OnAdding(object sender, RoutedEventArgs e)
        {
            this.AddTab(new AuraTabItem() { Header = "HeaderTest", Content = "ContentTest" }, true) ;
        }
        /// <summary>
        /// This property defines if the <see cref="AuraTabView.AdderButton"/> can be visible, the default value is true
        /// </summary>
        public bool AdderButtonIsVisible
        {
            get { return GetValue(AdderButtonIsVisibleProperty); }
            set { SetValue(AdderButtonIsVisibleProperty, value); }
        }
        public static readonly StyledProperty<bool> AdderButtonIsVisibleProperty =
            AvaloniaProperty.Register<AuraTabView, bool>(nameof(AdderButtonIsVisible), true);
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            AdderButton = this.GetControl<Button>(e, "PART_AdderButton");
            AdderButton.Click += OnAdding;
        }
        /// <summary>
        /// This property defines what is the maximum width of the ItemsPresenter
        /// </summary>
        public int MaxWidthOfItemsPresenter
        {
            get { return GetValue(MaxWidthOfItemsPresenterProperty); }
            set { SetValue(MaxWidthOfItemsPresenterProperty, value); }
        }
        public readonly static StyledProperty<int> MaxWidthOfItemsPresenterProperty =
            AvaloniaProperty.Register<AuraTabView, int>(nameof(MaxWidthOfItemsPresenter), int.MaxValue);
    }
}
