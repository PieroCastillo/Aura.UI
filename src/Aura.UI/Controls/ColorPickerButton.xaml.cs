using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using ThemeEditor.Controls.ColorPicker;
using Avalonia.Collections;
using Avalonia.Media;
using Aura.UI.Windows;
using Avalonia.LogicalTree;
using Avalonia.Platform;
using Avalonia.VisualTree;
using Avalonia.Controls.Platform;
using Avalonia.Layout;
using Avalonia.Controls.ApplicationLifetimes;
using Aura.UI.UIExtensions;

namespace Aura.UI.Controls
{
    public class ColorPickerButton : Button
    {
        ColorWindowSmall colorWindow;
        public ColorPickerButton()
        {
            this.InitializeComponent();

            this.Background = Brushes.White;

            
        }

        private void ColorWindow_Closed(object sender, System.EventArgs e)
        {
            this.Background = colorWindow.SelectedBrush;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public int ThicknessOfBorder
        {
            get { return (int)GetValue(ThicknessOfBorderProperty); }
            set { SetValue(ThicknessOfBorderProperty, value); }
        }
        public static readonly AvaloniaProperty<int> ThicknessOfBorderProperty =
            AvaloniaProperty.Register<ColorPickerButton, int>(nameof(ThicknessOfBorder),10);



        protected override void OnClick()
        {
            colorWindow = new ColorWindowSmall();
            colorWindow.ShowDialog(this.GetParentWindowOfLogical());
            
            colorWindow.Closed += ColorWindow_Closed;
        }

    }
}
