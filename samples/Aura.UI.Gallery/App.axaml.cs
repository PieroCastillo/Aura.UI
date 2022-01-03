using Aura.UI.Gallery.ViewModels;
using Aura.UI.Gallery.Views;
using AuraUtilities.Configuration;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using Avalonia.Threading;
using ReactiveUI;
using System;
using System.Diagnostics;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using System.Threading;

namespace Aura.UI.Gallery
{
    public class App : Application
    {
        public override void Initialize()
        {
            var settings_prov = new SettingsProvider();
            Settings = settings_prov.Load<AppSettings>();

            switch (Settings.Theme)
            {
                case Theme.Light:
                    Styles.Insert(0, App.FluentLight);
                    break;

                case Theme.Dark:
                    Styles.Insert(0, App.FluentDark);
                    break;
            }

            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {

                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel()
                };

                desktop.Exit += (s, e) =>
                {
                    new SettingsProvider().Save(Settings);
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
                            Application.Current.Styles[0] = App.FluentLight;
                            break;
                        case Theme.Dark:
                            Application.Current.Styles[0] = App.FluentDark;
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



        public readonly static Styles FluentDark = new Styles
        {
            new StyleInclude(new Uri("avares://Aura.UI.Gallery/Styles"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/FluentDark.xaml")
            },
            new StyleInclude(new Uri("avares://Aura.UI.Gallery/Styles"))
            {
                Source = new Uri("avares://Aura.UI.FluentTheme/AuraUI.xaml")
            }
        };

        public readonly static Styles FluentLight = new Styles
        {
            new StyleInclude(new Uri("avares://Aura.UI.Gallery/Styles"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/FluentLight.xaml")
            },
            new StyleInclude(new Uri("avares://Aura.UI.Gallery/Styles"))
            {
                Source = new Uri("avares://Aura.UI.FluentTheme/AuraUI.xaml")
            }
        };
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
