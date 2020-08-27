using Avalonia;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Avalonia.ThemeManager;
using Aura.UI.Attributes;

namespace Aura.UI.UIExtensions
{
    public static class ThemeSelectorExtensions
    {
        [Experimental]
        [InDeveloping]
        public static void EnableThemeOnApp(this IThemeSelector selector, Application App)
        {
            //IDisposable? disposable = null;

            if (selector.SelectedTheme != null)
            {
                App.Styles.Add(selector.SelectedTheme.Style);
            }

            /*window.Opened += (sender, e) =>
            {
                if (_windows != null)
                {
                    _windows.Add(window);
                    disposable = this.WhenAnyValue(x => x.SelectedLanguage).Where(x => x != null).Subscribe(x =>
                    {
                        if (x != null && x.Style != null)
                        {
                            window.Styles[1] = x.Style;
                        }
                    });
                }
            };

            window.Closing += (sender, e) =>
            {
                disposable?.Dispose();
                if (_windows != null)
                {
                    _windows.Remove(window);
                }
            };*/
        }
             
    }
}
