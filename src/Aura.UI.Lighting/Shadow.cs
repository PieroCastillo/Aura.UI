using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Threading;
using Avalonia.VisualTree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Aura.UI.Lighting
{
    public partial class Shadow : AvaloniaObject
    {
        static Shadow()
        {
            //EnabledProperty.Changed.Subscribe(OnEnabledPropertyChanged);
            BoxShadowProperty.Changed.Subscribe(Shadow.Current.ShadowChanged);
        }

        public static Shadow Current { get; } = new Shadow();

        internal void ShadowChanged(AvaloniaPropertyChangedEventArgs e)
        {
            var control = (Control)e.Sender;
            AttachShadow(control);
        }

        public static void AttachShadow(Control control)
        {
            var box = CreateBoxShadow(GetBoxShadow(control), GetShadowCornerRadius(control));
            AdornerLayer.SetAdornedElement(control, box);
            SetCurrent(control, box);
            Debug.WriteLine($"Shadow Attached on {control}");
        }

        public static void DetachShadow(Control control)
        {
            control.ClearValue(AdornerLayer.AdornedElementProperty);
            Debug.WriteLine($"Shadow Detached on {control}");
        }

        public static Border CreateBoxShadow(BoxShadows box, CornerRadius corners) => new Border { CornerRadius = corners, BoxShadow = box };
        /*public static Shadow Instance { get; } = new Shadow();

        internal async static void OnEnabledPropertyChanged(AvaloniaPropertyChangedEventArgs<bool> e)
        {
            var w = e.Sender as Control as IVisual;

            if(e.OldValue.Value & e.NewValue.Value)
            {
                await Task.Run(() => 
                {
                    foreach (Control control in w.VisualChildren)
                    {
                        DetachShadow(control);
                    }
                });
                await Task.Run(() =>
                {
                    foreach (Control control in w.VisualChildren)
                    {
                        AttachShadow(control);
                    }
                });
            }
            else if(!e.OldValue.Value & !e.NewValue.Value)
            {
                await Task.Run(() =>
                {
                    foreach (Control control in w.VisualChildren)
                    {
                        AttachShadow(control);
                    }
                });
                await Task.Run(() =>
                {
                    foreach (Control control in w.VisualChildren)
                    {
                        DetachShadow(control);
                    }
                });
            }
            else if(!e.OldValue.Value & e.NewValue.Value)
            {
                await Task.Run(() => 
                { 
                    foreach(Control control in w.VisualChildren)
                    {
                        AttachShadow(control);
                    }
                });
            }
            else if(e.OldValue.Value & !e.NewValue.Value)
            {
                await Task.Run(() =>
                {
                    foreach (Control control in w.VisualChildren)
                    {
                        DetachShadow(control);
                    }
                });
            }
        }*/

    }
}
