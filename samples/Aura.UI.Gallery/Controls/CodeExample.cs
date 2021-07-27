using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Metadata;
using AvaloniaEdit;
using Aura.UI.Extensions;
using AvaloniaEdit.Indentation.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Layout;
using Avalonia.LogicalTree;

namespace Aura.UI.Gallery.Controls
{
    public class CodeExample : TemplatedControl, ILogical
    {
        static CodeExample()
        {
            ControlProperty.Changed.Subscribe(ControlChildChanged);
        }
        private TextEditor xaml_edit;
        private TextEditor c_edit;
        private IAvaloniaReadOnlyList<ILogical> _logicalChildren1;

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

            xaml_edit = this.GetControl<TextEditor>(e, "editor_xaml");
            c_edit = this.GetControl<TextEditor>(e, "editor_csharp");

            c_edit.TextArea.IndentationStrategy = new CSharpIndentationStrategy();

            xaml_edit.Text = XAMLText;
            c_edit.Text = CSharpText;
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
        
        IAvaloniaReadOnlyList<ILogical> ILogical.LogicalChildren => this.LogicalChildren;
    }
}
