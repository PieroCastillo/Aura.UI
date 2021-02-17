using Aura.UI.Services;
using Aura.UI.UIExtensions;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Aura.UI.ControlsGallery.Pages
{
    public partial class MessageDialogPage : UserControl
    {
        public MessageDialogPage()
        {
            InitializeComponent();
        }

        public void ShowMessageDialog(object sender, RoutedEventArgs e)
        {
            var win = this.GetParentTOfVisual<Window>();
            win.NewMessageDialog("Your Message Title", "Your Message Content", null);
        }
    }
}