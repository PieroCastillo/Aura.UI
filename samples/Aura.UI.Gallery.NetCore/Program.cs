﻿using System;
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
                .With(new Win32PlatformOptions 
                { 
                    CompositionMode = new[] {  Win32CompositionMode.WinUIComposition },
                    RenderingMode = new[] { Win32RenderingMode.Software },
                })
                .UseSkia()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
    }
}
