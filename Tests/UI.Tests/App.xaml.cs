using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;
using Aura.UI.Controls;
using Avalonia.Controls;
using ReactiveUI;

namespace UI.Tests
{
#nullable enable
    public class App : Application
    {
        //public static IThemeSelector? Selector { get; set; }
        //public static ILanguageManager? Manager { get; set; }
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            
            base.OnFrameworkInitializationCompleted();
        }

    }
}
