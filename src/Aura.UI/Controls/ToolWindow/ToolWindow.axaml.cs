using Aura.UI.Controls.Primitives;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Aura.UI.Controls
{
    public class ToolWindow : CustomWindow
    {
        public ToolWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            var close_b = this.Find<Button>("PART_CloseButton");
            close_b.Click += (s, e) =>
            {
                Close();
            };
            var drag = this.Find<Border>("PART_DragBorder");
            MakeWindowDragger(drag);
        }
    }
}