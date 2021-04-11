using Aura.UI.Controls.Primitives;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Aura.UI.Controls.Legacy
{
    public partial class ToolWindow : CustomWindow
    {
        public ToolWindow()
        {
            AvaloniaXamlLoader.Load(this);
            Button PART_CloseButton = this.Find<Button>("PART_CloseButton");
            PART_CloseButton.Click += delegate
            {
                Close();
            };

            MakeWindowDragger(this.Find<Border>("PART_DragBorder"));
        }
    }
}