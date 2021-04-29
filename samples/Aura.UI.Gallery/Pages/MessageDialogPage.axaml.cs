using System;
using Aura.UI.Services;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Aura.UI.Gallery.Pages
{
    public partial class MessageDialogPage : UserControl
    {
        public MessageDialogPage()
        {
            InitializeComponent();
        }

        public void ShowMessageDialog(object sender, RoutedEventArgs e)
        {
            this.NewMessageDialog("Your Message Title", "Your Message Content", null, (DrawingImage)this.FindResource("VSCodeDark.warning"));
        }
    }
}