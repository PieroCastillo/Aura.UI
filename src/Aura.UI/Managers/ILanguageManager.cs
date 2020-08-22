using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Managers
{
#nullable enable
    public interface ILanguageManager
    {
        ILanguage? SelectedLanguage { get; set; }
        IList<ILanguage>? Languages { get; set; }
        IList<Window>? Windows { get; set; }
        ILanguage LoadLanguage(string file);
        void EnableLanguages(Window window);
        void ApplyLanguage(ILanguage Language);
        void LoadSelectedLanguage(string file);
        void SaveSelectedLanguage(string file);
    }
}
