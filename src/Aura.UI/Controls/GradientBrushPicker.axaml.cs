using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Visuals.Media.Imaging;

namespace Aura.UI.Controls
{
    public class GradientBrushPicker : UserControl
    {
        Rectangle rect_fill_;
        Rectangle rect_1_bg_;
        Rectangle rect_2_bg_;
        public GradientBrushPicker()
        {
            this.InitializeComponent();

            rect_fill_ = this.Find<Rectangle>("rect_bg_");
            rect_1_bg_ = this.Find<Rectangle>("rect_1_bg_");
            rect_2_bg_ = this.Find<Rectangle>("rect_2_bg_");

            /*var gb =  new VisualBrush(new Image()
            { 
                Source = new Bitmap(@"Resources/TransparentBackground.png") 
            });
            gb.TileMode = TileMode.Tile;
            rect_fill_.Fill = gb; */
            rect_1_bg_.Fill = new SolidColorBrush(Colors.SkyBlue);
            rect_2_bg_.Fill = new SolidColorBrush(Colors.SkyBlue,0.2);

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
