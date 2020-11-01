using Avalonia;
using Avalonia.Dialogs;
using Avalonia.Controls.ApplicationLifetimes;
using System;

namespace UI.Tests
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseManagedSystemDialogs()
                .UseSkia()
                .With<Win32PlatformOptions>(new Win32PlatformOptions() { UseWindowsUIComposition = true })
                .LogToTrace();
               
    }
}
