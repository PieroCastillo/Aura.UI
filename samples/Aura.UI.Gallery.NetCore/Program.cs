using System;
using Avalonia;
using Avalonia.ReactiveUI;

namespace Aura.UI.Gallery.NetCore
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
                .With(new Win32PlatformOptions 
                {
                    AllowEglInitialization = true, 
                    UseDeferredRendering = true, 
                    OverlayPopups = true,
                })
                .With(new X11PlatformOptions
                {
                    OverlayPopups = true
                })
                .With(new MacOSPlatformOptions
                {
                    ShowInDock = true
                })
                .LogToTrace()
                .UseReactiveUI();
    }
}
