using Aura.UI.Managers;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ThemeManager;
using System;
using System.Collections.Generic;

namespace UI.Tests
{
#nullable enable
    public class App : Application
    {
        public static IThemeSelector? Selector { get; set; }
        public static ILanguageManager? Manager { get; set; }
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                Selector = ThemeSelector.Create("Themes");
                Selector.LoadSelectedTheme("Theme.theme");
                
                Manager = LanguageManager.Create("Languages");
                Manager.LoadSelectedLanguage("Language.theme");
                desktop.MainWindow = new MainWindow()
                {
                    DataContext = Manager
                };
                desktop.Exit += (sender , e) =>
                {
                    Selector.SaveSelectedTheme("Theme.theme");
                    Manager.SaveSelectedLanguage("Language.theme");
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
