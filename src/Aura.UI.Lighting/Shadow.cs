using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Threading;
using Avalonia.VisualTree;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aura.UI.Lighting
{
    public partial class Shadow : AvaloniaObject
    {
        static Shadow()
        {
            EnabledProperty.Changed.Subscribe(OnEnabledPropertyChanged);
        }

        internal static void OnEnabledPropertyChanged(AvaloniaPropertyChangedEventArgs<bool> e)
        {
            var w = e.Sender as Control as IVisual;

            if(e.OldValue.Value & e.NewValue.Value)
            {
            
            }
            else if(!e.OldValue.Value & !e.NewValue.Value)
            {

            }
            else if(!e.OldValue.Value & e.NewValue.Value)
            {
                Dispatcher.UIThread.InvokeAsync(
                    async () => 
                    {
                        await Task.Run(() => 
                        { 
                            foreach(Control control in w.VisualChildren)
                            {
                                AttachShadow(control);
                            }
                        });
                    });
            }
        }

        public static void AttachShadow(Control control)
        {
            var box = CreateBoxShadow(GetBoxShadow(control), GetShadowCornerRadius(control));
            AdornerLayer.SetAdornedElement(control, box);
            SetCurrent(control, box);
        }

        public static void DetachShadow(Control control)
        {
            //TODO: detach the shadow
        }

        public static Border CreateBoxShadow(BoxShadows box, CornerRadius corners) => new Border { CornerRadius = corners, BoxShadow = box };
    }
}
