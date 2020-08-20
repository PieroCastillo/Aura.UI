using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using System;

namespace Aura.UI.Controls
{
    public class TitleBarWindow : Window
    {
        Button min_btn;
        Button max_btn;
        Button close_btn;
        Image windowIcon_icn;
        Grid HeaderPanel;
        public TitleBarWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
 #region Properties
        public object TitleBarContent
        {
            get { return GetValue(TitleBarContentProperty); }
            set { SetValue(TitleBarContentProperty, value); }
        }
        public static readonly StyledProperty<object> TitleBarContentProperty =
            AvaloniaProperty.Register<TitleBarWindow, object>(nameof(TitleBarContent), "Hello World :D");
        #endregion
        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            base.OnTemplateApplied(e);


        }
        void SetupSide(string name, StandardCursorType cursor, WindowEdge edge)
        {
            var ctl = this.FindControl<Control>(name);
            ctl.Cursor = new Cursor(cursor);
            ctl.PointerPressed += (i, e) =>
            {
                PlatformImpl?.BeginResizeDrag(edge, e);
            };
        }
    }
}
