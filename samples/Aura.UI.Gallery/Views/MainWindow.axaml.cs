using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using DynamicData;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Interactivity;

namespace Aura.UI.Gallery.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DragBorder.PointerPressed += (s, e) =>
            {
                BeginMoveDrag(e);
            };
        }
    }
}
