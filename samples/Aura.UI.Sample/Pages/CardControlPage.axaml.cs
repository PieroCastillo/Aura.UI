﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Aura.UI.ControlsGallery.Pages
{
    public partial class CardControlPage : UserControl
    {
        public CardControlPage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}