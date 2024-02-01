using Aura.UI.Gallery.ViewModels;
using Aura.UI.Gallery.Views;
using AuraUtilities.Configuration;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Avalonia.Threading;
using System;
using System.Threading.Tasks;

namespace Aura.UI.Gallery
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            var settings_prov = new SettingsProvider();
            Settings = settings_prov.Load<AppSettings>();

            switch (Settings.Theme)
            {
                case Theme.Light:
                    SetTheme(Theme.Light);
                    break;

                case Theme.Dark:
                    SetTheme(Theme.Dark);
                    break;
            }
        }


        public override void OnFrameworkInitializationCompleted()
        {
            // NavigationViewStatic();
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {

                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel()
                };

                desktop.Exit += (s, e) =>
                {
                    //new SettingsProvider().Save(Settings);
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime single)
            {
                single.MainView = new MainView()
                {
                    DataContext = new MainWindowViewModel()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
        private AppSettings Settings
        {
            get;
            set;
        }
        public Theme GetTheme() => Settings.Theme;

        public async Task SetTheme(Theme theme)
        {
            try
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    switch (theme)
                    {
                        case Theme.Light:
                            RequestedThemeVariant = ThemeVariant.Light;
                            break;
                        case Theme.Dark:
                            RequestedThemeVariant = ThemeVariant.Dark;
                            break;
                    }
                }, (DispatcherPriority)1);

                Settings.Theme = theme;
            }
            catch (Exception)
            {
                Console.WriteLine($"some error has executed");
            }
        }
    }

    [Serializable]
    public class AppSettings : ISettings
    {
        public Theme Theme
        {
            get;
            set;
        }
    }

    [Serializable]
    public enum Theme
    {
        Light,
        Dark
    }
}
