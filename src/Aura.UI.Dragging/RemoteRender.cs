using Avalonia;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.VisualTree;

namespace Aura.UI.Dragging
{
    public static class VisualExtensions
    {
        public static void RemoteRender(IVisual visual, PointerPressedEventArgs e)
        {
            //visual.Render(new DrawingContext(AvaloniaLocator.Current.GetService<IDrawingContextImpl>()));
        }
    }
}