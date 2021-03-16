﻿using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Aura.UI.Services;

namespace Aura.UI.ControlsGallery.Pages
{
    public partial class ContentDialogPage : UserControl
    {
        public ContentDialogPage()
        {
            InitializeComponent();
        }

        public void OnClikedButton(object sender, RoutedEventArgs e)
        {
            this.GetParentTOfLogical<Window>()
                .NewContentDialog("Nice, you're watching a Content Dialog", null, null, null, null);
        }
    }
}
