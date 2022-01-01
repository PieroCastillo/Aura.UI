using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using System;

namespace Aura.UI.Gallery.Desktop
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
                .UseSkia()
                .UseReactiveUI()
                .With(new X11PlatformOptions() { UseDeferredRendering = true })
                .With(new MacOSPlatformOptions() { ShowInDock = true })
                .With(new Win32PlatformOptions() { AllowEglInitialization = true, UseDeferredRendering = true })
                .LogToTrace();
    }
}
