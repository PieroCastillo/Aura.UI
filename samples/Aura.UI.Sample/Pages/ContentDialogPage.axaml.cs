using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Aura.UI.Services;

namespace Aura.UI.ControlsGallery.Pages
{
    public class ContentDialogPage : UserControl
    {
        public ContentDialogPage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void OnClikedButton(object sender, RoutedEventArgs e)
        {
            this.GetParentTOfLogical<Window>()
                .NewContentDialog("Nice, you're watching a Content Dialog", null, null, null, null);
        }
    }
}
