using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Metadata;
using AvaloniaEdit;
using Aura.UI.Extensions;
using AvaloniaEdit.Indentation.CSharp;
using System;
using Avalonia.Collections;
using Avalonia.LogicalTree;
using Avalonia.Controls.Metadata;
using TextMateSharp.Grammars;
using AvaloniaEdit.TextMate;
using Avalonia.Styling;

namespace Aura.UI.Gallery.Controls
{
    [TemplatePart(Name = "PART_editor_xaml", Type = typeof(TextEditor))]
    [TemplatePart(Name = "PART_editor_csharp", Type = typeof(TextEditor))]
    public class CodeExample : TemplatedControl
    {
        static CodeExample()
        {
            ControlProperty.Changed.Subscribe(ControlChildChanged);
        }

        private static void ControlChildChanged(AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Sender is CodeExample ce && ce.LogicalChildren is AvaloniaList<ILogical> lc)
            {
                if (e.OldValue is ILogical oldChild)
                {
                    lc.Remove(oldChild);
                }

                if (e.NewValue is ILogical newChild)
                {
                    lc.Add(newChild);
                }
            }
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            this.GetControl(e, "PART_editor_csharp", out TextEditor editor_csharp);
            this.GetControl(e, "PART_editor_xaml", out TextEditor editor_xaml);

            editor_xaml.Text = XAMLText;
            editor_csharp.Text = CSharpText;

            editor_xaml.ShowLineNumbers = true;
            editor_csharp.ShowLineNumbers = true;

            RegistryOptions _registryOptions;
            if (App.Current.RequestedThemeVariant == ThemeVariant.Light)
            {
                _registryOptions = new RegistryOptions(ThemeName.Light);
            }
            else
            {
               _registryOptions = new RegistryOptions(ThemeName.Dark);
            }
            

            //Initial setup of TextMate.
            var _textMateCSharp = editor_csharp.InstallTextMate(_registryOptions);
            _textMateCSharp.SetGrammar(_registryOptions.GetScopeByLanguageId(_registryOptions.GetLanguageByExtension(".cs").Id));

            var _textMateXaml = editor_xaml.InstallTextMate(_registryOptions);
            _textMateXaml.SetGrammar(_registryOptions.GetScopeByLanguageId(_registryOptions.GetLanguageByExtension(".axaml").Id));
        }

        [Content]
        public Control Control
        {
            get => GetValue(ControlProperty);
            set => SetValue(ControlProperty, value);
        }
        public static readonly StyledProperty<Control> ControlProperty =
            AvaloniaProperty.Register<CodeExample, Control>(nameof(Control));

        public string CSharpText
        {
            get => GetValue(CSharpTextProperty);
            set => SetValue(CSharpTextProperty, value);
        }
        public static readonly StyledProperty<string> CSharpTextProperty =
            AvaloniaProperty.Register<CodeExample, string>(nameof(CSharpText));

        public string XAMLText
        {
            get => GetValue(XAMLTextProperty);
            set => SetValue(XAMLTextProperty, value);
        }
        public static readonly StyledProperty<string> XAMLTextProperty =
            AvaloniaProperty.Register<CodeExample, string>(nameof(XAMLText));

        public bool CSharpVisible
        {
            get => GetValue(CSharpVisibleProperty);
            set => SetValue(CSharpVisibleProperty, value);
        }
        public static readonly StyledProperty<bool> CSharpVisibleProperty =
            AvaloniaProperty.Register<CodeExample, bool>(nameof(CSharpVisible));

        public bool XAMLVisible
        {
            get => GetValue(XAMLVisibleProperty);
            set => SetValue(XAMLVisibleProperty, value);
        }
        public static readonly StyledProperty<bool> XAMLVisibleProperty =
            AvaloniaProperty.Register<CodeExample, bool>(nameof(XAMLVisible));

        public string Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public static readonly StyledProperty<string> TitleProperty =
            AvaloniaProperty.Register<CodeExample, string>(nameof(Title));
        public string TitleTwo
        {
            get => GetValue(TitleTwoProperty);
            set => SetValue(TitleTwoProperty, value);
        }
        public static readonly StyledProperty<string> TitleTwoProperty =
            AvaloniaProperty.Register<CodeExample, string>(nameof(TitleTwo));
    }
}
