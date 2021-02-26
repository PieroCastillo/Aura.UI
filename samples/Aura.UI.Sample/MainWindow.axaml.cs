using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using DynamicData;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Aura.UI.ControlsGallery
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

        public async void ChangeTheme(object sender, SelectionChangedEventArgs e)
        {
            var themes = sender as SelectingItemsControl;
            Debug.WriteLine("attached");
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                switch (themes.SelectedIndex)
                {
                    case 0:
                        Application.Current.Styles[0] = App.FluentLight;
                        break;
                    case 1:
                        Application.Current.Styles[0] = App.FluentDark;
                        break;
                }
            }, (DispatcherPriority)1);
        }
         
        public void EnableDrag(object sender, PointerPressedEventArgs e)
        {
            BeginMoveDrag(e);
        }
    }
}
