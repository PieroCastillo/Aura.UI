using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ThemeManager;

namespace UI.Tests
{
    public class App : Application
    {
        public static IThemeSelector? Selector { get; set; }
        public static IThemeSelector? Language { get; set; }
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                Selector = ThemeSelector.Create("Themes");
                Selector.LoadSelectedTheme("Tests.theme");
                desktop.MainWindow = new MainWindow()
                {
                    DataContext = Selector
                };
                desktop.Exit += (sennder, e) => Selector.SaveSelectedTheme("Tests.theme");
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
