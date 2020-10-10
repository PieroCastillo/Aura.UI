using Aura.UI.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UI.Tests.Views
{
    public class CustomNavigationViewWindow : ContentWindow
    {
        Border drag;
        public CustomNavigationViewWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            drag = this.Find<Border>("drag_border");
            drag.PointerPressed += Drag_PointerPressed;
        }

        private void Drag_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            this.BeginMoveDrag(e);
        }
    }
}
