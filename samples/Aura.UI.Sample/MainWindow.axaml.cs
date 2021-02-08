using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace Aura.UI.ControlsGallery
{
    public class MainWindow : Window
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

            var themes = this.Find<ComboBox>("Themes");
            themes.SelectionChanged += (s, e) =>
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
            };
        }

        public void EnableDrag(object sender, PointerPressedEventArgs e)
        {
            BeginMoveDrag(e);
        }
    }
}
