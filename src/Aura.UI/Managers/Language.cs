using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Managers
{
    public class Language : ReactiveObject, ILanguage
    {
#pragma warning disable CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
        
        private string _name = string.Empty;
        private IStyle? _style;
        private ILanguageManager? _manager;

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public IStyle? Style
        {
            get => _style;
            set => this.RaiseAndSetIfChanged(ref _style, value);
        }

        public ILanguageManager? Manager
       {
            get => _manager;
            set => this.RaiseAndSetIfChanged(ref _manager, value);
        }

        public void ApplyLanguage()
        {
            Manager?.ApplyLanguage(this);
        }
        #pragma warning restore CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
 
    }

    public enum Languages
    {
        Spanish,
        English
    }
}
