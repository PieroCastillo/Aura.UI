using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;

namespace Aura.UI.Controls
{
    /// <summary>
    /// This control shows a content but has to be whitin <see cref="PagesView"/>
    /// </summary>
    public class Page : ContentControl, ISelectable
    {
        public Page()
        {
            this.InitializeComponent();
            ViewerParent = this.GetParentTOfLogical<PagesView>();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public PagesView ViewerParent { get; set; }

        /// <summary>
        /// Defines the Title of the Parent Window
        /// </summary>
        public string Title
        {
            get { return GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly StyledProperty<string> TitleProperty =
            AvaloniaProperty.Register<Page, string>(nameof(Title), "Page");
        /// <summary>
        /// Indicates if the Page is selected
        /// </summary>
        public bool IsSelected
        {
            get { return GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public static readonly StyledProperty<bool> IsSelectedProperty =
            AvaloniaProperty.Register<Page, bool>(nameof(IsSelected), false);

    }
}
