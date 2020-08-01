using Avalonia.Controls.Primitives;
using Avalonia.Controls;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.UIExtensions
{
    public static class TemplatedControlExtensions
    {
        public static T GetControl<T>(this TemplatedControl templatedControl ,TemplateAppliedEventArgs e, string name) where T : AvaloniaObject
        {
            return e.NameScope.Find<T>(name);
        }
    }
}
