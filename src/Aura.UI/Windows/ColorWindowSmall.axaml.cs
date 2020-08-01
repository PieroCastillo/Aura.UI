using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using System.ComponentModel;
using ThemeEditor.Controls.ColorPicker;

namespace Aura.UI.Windows
{
    public class ColorWindowSmall : Window
    {
        ColorPicker colorPicker_;
        public ColorWindowSmall()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            colorPicker_ = this.Find<ColorPicker>("cp_picker");

            colorPicker_.PropertyChanged += ColorPicker__PropertyChanged;
        }

        private void ColorPicker__PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            SelectedBrush = new SolidColorBrush(colorPicker_.Color);
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

            SelectedBrush = new SolidColorBrush(colorPicker_.Color);

            
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            SelectedBrush = new SolidColorBrush(colorPicker_.Color);
        }
    }
}
