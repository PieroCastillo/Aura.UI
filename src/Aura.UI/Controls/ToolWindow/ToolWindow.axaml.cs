using Aura.UI.Controls.Primitives;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Aura.UI.Controls
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class ToolWindow : CustomWindow
    {
        public ToolWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
            PART_CloseButton.Click += delegate
            {
                Close();
            };
            
            MakeWindowDragger(PART_DragBorder);
        }
    }
}