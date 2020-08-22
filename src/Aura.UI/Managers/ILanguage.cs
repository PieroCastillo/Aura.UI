using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Styling;
using Avalonia.Themes;

namespace Aura.UI.Managers
{
#nullable enable
    public interface ILanguage
    {
        string Name { get; set; }
        IStyle? Style { get; set; }
        ILanguageManager? Manager { get; set; }
        void ApplyLanguage();
    }
}
