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
                    case Gallery.Theme.Light:
                        PART_DarkOption.IsChecked = false;
                        PART_LightOption.IsChecked = true;
                        break;
                    case Gallery.Theme.Dark:
                        PART_DarkOption.IsChecked = true;
                        PART_LightOption.IsChecked = false;
                        break;
                }
            }

            PART_DarkOption.IsCheckedChanged += async (s, e) =>
            {
                if (PART_DarkOption.IsChecked == true && Application.Current is App app)
                {
                    Debug.WriteLine("dark checked");
                    await app.SetTheme(Gallery.Theme.Dark);
                }
            };

            PART_LightOption.IsCheckedChanged += async (s, e) =>
            {
                if (PART_LightOption.IsChecked == true && Application.Current is App app)
                {
                    Debug.WriteLine("light checked");
                    await app.SetTheme(Gallery.Theme.Light);
                }
            };

        }
    }
}
