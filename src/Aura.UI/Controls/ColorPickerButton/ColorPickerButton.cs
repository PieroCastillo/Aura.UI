using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
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
    /// <summary>
    /// This control shows a <see cref="SuperColorPicker"/> in a Window when is clicked.
    /// The selected color is in the Background property.
    /// </summary>
    public class ColorPickerButton : Button
    {
        ColorWindowSmall colorWindow;
        public ColorPickerButton()
        {
            this.Background = Brushes.White;         
        }

        private void ColorWindow_Closed(object sender, System.EventArgs e)
        {
            this.Background = colorWindow.SelectedBrush;
        }

        protected override void OnClick()
        {
            colorWindow = new ColorWindowSmall();
            colorWindow.ShowDialog(this.GetParentWindowOfLogical());
            
            colorWindow.Closed += ColorWindow_Closed;
        }

    }
}
