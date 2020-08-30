using Aura.UI.Attributes;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using Avalonia.Styling;
using System;

namespace Aura.UI.Controls
{
    [TemplatePart( Name = "PART_AppTitleBar", Type = typeof(Grid))]
    public class ContentWindow : Window, IStyleable
    {
        Type IStyleable.StyleKey => typeof(Window);

        public ContentWindow()
        {
            AvaloniaXamlLoader.Load(this);

            ExtendClientAreaToDecorationsHint = true;
            ExtendClientAreaTitleBarHeightHint = -1;

            TransparencyLevelHint = WindowTransparencyLevel.AcrylicBlur;

            this.GetObservable(WindowStateProperty)
                .Subscribe(x =>
                {
                    PseudoClasses.Set(":maximized", x == WindowState.Maximized);
                    PseudoClasses.Set(":fullscreen", x == WindowState.FullScreen);
                });

            this.GetObservable(IsExtendedIntoWindowDecorationsProperty)
                .Subscribe(x =>
                {
                    if (!x)
                    {
                        SystemDecorations = SystemDecorations.Full;
                        TransparencyLevelHint = WindowTransparencyLevel.Blur;
                    }
                });
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            ExtendClientAreaChromeHints =
                ExtendClientAreaChromeHints.PreferSystemChrome |
                ExtendClientAreaChromeHints.OSXThickTitleBar;
        }
    }
}
