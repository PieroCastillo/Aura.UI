using Aura.UI.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NugetTest
{
    public class MainWindow : ContentWindow
    {
        Border drag;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            drag = this.Find<Border>("drag");
            drag.PointerPressed += Drag_PointerPressed;
        }

        private void Drag_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            this.BeginMoveDrag(e);
        }
    }
}
