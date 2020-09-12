using Aura.UI.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using System.ComponentModel;
using CP = ThemeEditor.Controls.ColorPicker;

namespace Aura.UI.Windows
{
    public class ColorWindowSmall : Window
    {
        SuperColorPicker colorPicker_;
        public ColorWindowSmall()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            colorPicker_ = this.Find<SuperColorPicker>("cp_picker");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public IBrush SelectedBrush
        {
            get { return GetValue(SelectedBrushProperty); }
            set { SetValue(SelectedBrushProperty, value); }
        }
        public static readonly StyledProperty<IBrush> SelectedBrushProperty =
            AvaloniaProperty.Register<ColorWindowSmall, IBrush>(nameof(SelectedBrush));

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            SelectedBrush = new SolidColorBrush(colorPicker_.SelectedColor);         
        }
    }
}
