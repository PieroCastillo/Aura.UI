using Aura.UI.Controls.Primitives;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Aura.UI.Controls
{
    public partial class DesignerCanvas : Canvas
    {
        public DesignerCanvas()
        {
            SelectedControlChanged += OnSelectedControlChanged;
        }

        protected virtual void OnSelectedControlChanged(object sender, RoutedEventArgs e)
        {
            InDesignControl = sender as IDesignable;
        }

        protected virtual void ShowDesignerOnChild<T>(T control) where T : Control, IDesignable
        {
            
        }
    }
}