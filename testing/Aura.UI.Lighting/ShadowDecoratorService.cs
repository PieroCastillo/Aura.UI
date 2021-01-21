using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.LogicalTree;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Aura.UI.Lighting
{
    internal sealed class ShadowDecoratorService
    {
        public static ShadowDecoratorService Current { get; } = new ShadowDecoratorService();

        internal void ShadowChanged(Control s, AvaloniaPropertyChangedEventArgs e)
        {
            if ( AdornerLayer.GetAdornerLayer(e.Sender as Control) != null)//e.NewValue != null &
            {
                Detach(e.Sender as Control);
                 Attach(e.Sender as Control);
                Debug.WriteLine("Shadow Changed");
            }
        }

        internal void ShadowCornerRadiusChanged(Control s, AvaloniaPropertyChangedEventArgs e)
        {
            if (AdornerLayer.GetAdornerLayer(e.Sender as Control) != null)//e.NewValue != null & 
            {
                Detach(e.Sender as Control);
                Attach(e.Sender as Control);
                Debug.WriteLine("Shadow Corner Radius Changed");
            }
        }

        internal void VisibleChanged(AvaloniaPropertyChangedEventArgs<bool> e)
        {
           // Debug.WriteLine($"The old Shadow visibility is {e.OldValue}");

            var n = e.NewValue.Value;
            //var o = e.OldValue.Value;
            var c = e.Sender as Control;

            if (n & AdornerLayer.GetAdornerLayer(e.Sender as Control) != null)
            {
                Attach(e.Sender as Control);
            }
            else if (!n & AdornerLayer.GetAdornerLayer(e.Sender as Control) != null)
            {
                Detach(e.Sender as Control);
            }

            Debug.WriteLine($"The new Shadow visibility is {e.NewValue}");
        }

        private void Attach(Control control)
        {
            var bx = ShadowDecorator.GetShadow(control);
            var cr = ShadowDecorator.GetShadowCornerRadius(control);
            var br = new Border { BoxShadow = bx, CornerRadius = cr};// Width = control.Width - 20, Height = control.DesiredSize.Height - 20

            var adornerLayer = AdornerLayer.GetAdornerLayer(control);
            //if(adornerLayer != null)
            //{
            
                ShadowDecorator.SetCurrent(control, br);
                AdornerLayer.SetAdornedElement(br, control);
                adornerLayer.Children.Add(br);
                br.PropertyChanged += (s, e) => { br.Clip = null; };
                Debug.WriteLine("attached");
            //};
            //}

        }
        private void Detach(Control control)
        {
            var layer = AdornerLayer.GetAdornerLayer(control);

            var br = ShadowDecorator.GetCurrent(control);
            if(br != null )//& layer != null
            {
                control.ClearValue(AdornerLayer.AdornedElementProperty);
                control.ClearValue(ShadowDecorator.CurrentProperty);
                layer.Children.Remove(br);
                Debug.WriteLine("detach");
            }
        }

    }
}
