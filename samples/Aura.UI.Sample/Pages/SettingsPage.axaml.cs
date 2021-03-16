using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

namespace Aura.UI.ControlsGallery.Pages
{
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();

            PART_DarkOption.Checked += (s, e) =>
            {
                if(Application.Current is App app)
                {
                    Debug.WriteLine("dark checked");
                    _ = app.SetTheme(Theme.Dark);
                }
            };

            PART_LightOption.Checked += (s, e) =>
            {
                if (Application.Current is App app)
                {
                    Debug.WriteLine("light checked");
                    _ = app.SetTheme(Theme.Light);
                }
            };
            
        }
    }
}
