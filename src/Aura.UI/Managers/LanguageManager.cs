using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using System.Reactive.Linq;
using System.Collections;
using DynamicData;
using Aura.UI.UIExtensions;

namespace Aura.UI.Managers
{
    public sealed class LanguageManager : ReactiveObject, ILanguageManager
    {
#pragma warning disable CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
        private ILanguage? _selectedLanguage;
        private IList<ILanguage>? _languages;
        private IList<Window>? _windows;


        public ILanguage? SelectedLanguage
        {
            get => _selectedLanguage;
            set => this.RaiseAndSetIfChanged(ref _selectedLanguage, value);
        }

        public IList<ILanguage>? Languages
        {
            get => _languages;
            set => this.RaiseAndSetIfChanged(ref _languages, value);
        }

        public IList<Window>? Windows
        {
            get => _windows;
            set => this.RaiseAndSetIfChanged(ref _windows, value);
        }


        public static ILanguageManager Create(string path)
        {
            return new LanguageManager()
            {
                Languages = new ObservableCollection<ILanguage>(),
                Windows = new ObservableCollection<Window>()
            }.LoadLanguages(path);
        }

        private ILanguageManager LoadLanguages(string path) 
        {
            try
            {
                foreach (string file in System.IO.Directory.EnumerateFiles(path, "*.xaml"))
                {
                    var lang = LoadLanguage(file);
                    if (lang != null)
                    {
                        _languages?.Add(lang);
                    }
                }
            }
            catch (Exception)
            {
            }

            if (_languages?.Count == 0)
            {
                var spanish = new StyleInclude(new Uri("resm:Languages?assembly=Aura.UI"))
                {
                    Source = new Uri("avares://Aura.UI/Languages/SpanishLanguage.xaml")
                };
                var english = new StyleInclude(new Uri("resm:Languages?assembly=Aura.UI"))
                {
                    Source = new Uri("avares://Aura.UI/Languages/EnglishLanguage.xaml")
                };
                _languages.Add(new Language() { Name = "Spanish", Style = spanish, Manager = this });
                _languages.Add(new Language() { Name = "English", Style = english, Manager = this });
            }

            _selectedLanguage = _languages?.FirstOrDefault();

            return this;
        }

        public ILanguage LoadLanguage(string file)
        {
            var name = System.IO.Path.GetFileNameWithoutExtension(file);
            var xaml = System.IO.File.ReadAllText(file);
            var style = AvaloniaRuntimeXamlLoader.Parse<IStyle>(xaml);
            return new Language() { Name = name, Style = style, Manager = this };
        }

        public void EnableLanguages(Window window)
        {
            IDisposable? disposable = null;

            if (_selectedLanguage != null)
            {
                window.Styles.Add(_selectedLanguage.Style);
            }

            window.Opened += (sender, e) =>
            {
                if (_windows != null)
                {
                    _windows.Add(window);
                    disposable = this.WhenAnyValue(x => x.SelectedLanguage).Where(x => x != null).Subscribe(x =>
                    {
                        if (x != null && x.Style != null)
                        {
                            window.Styles[0] = x.Style;
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
            };
        }

        public void ApplyLanguage(ILanguage language)
        {
            if (language != null)
            {
                SelectedLanguage = language;
            }
        }

        public void LoadSelectedLanguage(string file)
        {
            try
            {
                if (System.IO.File.Exists(file) == true)
                {
                    var name = System.IO.File.ReadAllText(file);
                    if (name != null)
                    {
                        var language = _languages.FirstOrDefault(x => x.Name == name);
                        if (language != null)
                        {
                            SelectedLanguage = language;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void SaveSelectedLanguage(string file) 
        {
            try
            {
                System.IO.File.WriteAllText(file, _selectedLanguage?.Name);
            }
            catch (Exception)
            {
            }
        }
#pragma warning restore CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
    }
}
