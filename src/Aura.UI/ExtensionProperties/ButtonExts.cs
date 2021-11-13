using Avalonia;
using Avalonia.Controls;
using System;
using AuraUtilities;

namespace Aura.UI.ExtensionProperties
{
    public class ButtonExts : AvaloniaObject
    {
        public static readonly AttachedProperty<string> UrlProperty =
                AvaloniaProperty.RegisterAttached<ButtonExts, Button, string>("Url");

        public static string GetUrl(Button button) => button.GetValue(UrlProperty);
        public static void SetUrl(Button button, string url) => button.SetValue(UrlProperty, url);

        static ButtonExts()
        {
            UrlProperty.Changed.Subscribe(onNext: e =>
            {
                if (e.Sender is Button btn)
                {
                    btn.Click += (s, e) =>
                    {
                        if (!string.IsNullOrEmpty(GetUrl(btn)))
                        {
                            UrlUtils.OpenUrl(GetUrl(btn));
                        }
                    };
                }
            });
        }
    }
}