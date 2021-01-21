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
using Aura.UI.Services;

namespace Aura.UI.Controls
{
    /// <summary>
    /// This control shows a <see cref="SuperColorPicker"/> in a Dialog when is clicked.
    /// The selected color is in the Background property.
    /// </summary>
    public class ColorPickerButton : Button
    {
        public ColorPickerButton()
        {
            this.Background = Brushes.White;         
        }


        protected override void OnClick()
        {
            /*colorWindow = new ColorWindowSmall();
            colorWindow.ShowDialog(this.GetParentWindowOfLogical());
            
            colorWindow.Closed += ColorWindow_Closed;
            */
            var owner = this.GetParentWindowOfLogical();
            var cp = new SuperColorPicker();
            cp.PreviewColor = (Background as ISolidColorBrush).Color;

            owner.NewContentDialog(cp,
                (a,r) => { this.Background = new SolidColorBrush(cp.SelectedColor); },
                (a,r) => { this.Background = new SolidColorBrush(cp.PreviewColor); },
                "Ok","Cancel");
        }

    }
}
