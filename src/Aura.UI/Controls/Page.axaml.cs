using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Aura.UI.Controls
{
    public class Page : ContentControl, ISelectable
    {
        public Page()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public string Title
        {
            get { return GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly StyledProperty<string> TitleProperty =
            AvaloniaProperty.Register<Page, string>(nameof(Title), "Page");
        public bool IsSelected
        {
            get { return GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public static readonly StyledProperty<bool> IsSelectedProperty =
            AvaloniaProperty.Register<Page, bool>(nameof(IsSelected), false);
    }
}
