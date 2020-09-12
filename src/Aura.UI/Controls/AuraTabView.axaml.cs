using Aura.UI.Attributes;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Aura.UI.Controls
{
    [TemplatePart(Name = "PART_AdderButton", Type = typeof(Button))]
    public class AuraTabView : TabControl
    {
        public Button AdderButton;
        public AuraTabView()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// You should overwrite this Method for add your custom tabitem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnAdding(object sender, RoutedEventArgs e)
        {
            this.AddTab(new AuraTabItem() { Header = "HeaderTest", Content = "ContentTest" }, true) ;
        }

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

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public int MaxWidthOfItemsPresenter
        {
            get { return GetValue(MaxWidthOfItemsPresenterProperty); }
            set { SetValue(MaxWidthOfItemsPresenterProperty, value); }
        }
        public readonly static StyledProperty<int> MaxWidthOfItemsPresenterProperty =
            AvaloniaProperty.Register<AuraTabView, int>(nameof(MaxWidthOfItemsPresenter), int.MaxValue);
    }
}
