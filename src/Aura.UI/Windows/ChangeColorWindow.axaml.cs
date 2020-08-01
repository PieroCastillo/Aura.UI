using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using ThemeEditor.Controls.ColorPicker;
using Avalonia.Media;
using Avalonia.VisualTree;
using Avalonia.Visuals;
using Avalonia.LogicalTree;
using Avalonia.Controls.Shapes;

namespace Aura.UI.Windows
{
    public class ChangeColorWindow : Window
    {
        Rectangle rectangle_;
        ColorPicker colorpicker_;
        Button agreebtn_;
        Button cancelbtn_;
        public ChangeColorWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            colorpicker_ = this.Find<ColorPicker>("colorPick_");
            agreebtn_ = this.Find<Button>("agree_btn");
            cancelbtn_ = this.Find<Button>("cancel_btn");
            rectangle_ = this.Find<Rectangle>("rect_");
            

            colorpicker_.Color = new Color(255, 255, 255, 255);
            agreebtn_.Click += Agreebtn__Click;
            cancelbtn_.Click += Cancelbtn__Click;
        }

        private void Cancelbtn__Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.IsReady = ReadyForChanges.UnReady;
        }

        private void Agreebtn__Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.IsReady = ReadyForChanges.Ready;
        }

        public void SetBrush(IBrush BrushProperty)
        {
            this.pbrush = this.GetBrush();
            BrushProperty = this.pbrush;
        }

        protected IBrush GetBrush()
        {
            return new LinearGradientBrush();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        internal ReadyForChanges IsReady { get; set; } = ReadyForChanges.OnWaiting;

        private IBrush pbrush;
    }

    internal enum ReadyForChanges
    {
       Ready, UnReady, OnWaiting  
    }
}
