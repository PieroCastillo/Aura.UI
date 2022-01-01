using Aura.UI.Gallery;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

namespace Aura.UI.Gallery.Pages
{
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();

            if (Application.Current is App app)
            {
                switch (app.GetTheme())
                {
                    case Theme.Light:
                        PART_DarkOption.IsChecked = false;
                        PART_LightOption.IsChecked = true;
                        break;
                    case Theme.Dark:
                        PART_DarkOption.IsChecked = true;
                        PART_LightOption.IsChecked = false;
                        break;
                }
            }

            PART_DarkOption.Checked += async (s, e) =>
            {
                if (Application.Current is App app)
                {
                    Debug.WriteLine("dark checked");
                    await app.SetTheme(Theme.Dark);
                }
            };

            PART_LightOption.Checked += async (s, e) =>
            {
                if (Application.Current is App app)
                {
                    Debug.WriteLine("light checked");
                    await app.SetTheme(Theme.Light);
                }
            };

        }
    }
}
