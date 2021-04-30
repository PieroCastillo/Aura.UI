using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using DynamicData;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Interactivity;

namespace Aura.UI.Gallery.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void EnableDrag(object sender, PointerPressedEventArgs e)
        {
            BeginMoveDrag(e);
        }
        
        public void DoubleTappedTitleBar(object sender, RoutedEventArgs e)
        {
            switch (WindowState)
            {
                case WindowState.Maximized: 
                    WindowState = WindowState.Normal;
                    break;
                case WindowState.Normal:
                    WindowState = WindowState.Maximized;
                    break;
            }
        }
    }
}
