using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Aura.UI.Services
{
    internal static class ContentDialogService
    {
        internal  static void ShowDialogOn(WindowBase window, Control dialog)
        {
           Dispatcher.UIThread.Post(() =>
           {
               dialog.Width = window.Bounds.Width;
               dialog.Height = window.Bounds.Height;
               window.PropertyChanged += (s,e) =>
               {
                   dialog.Width = window.Bounds.Width;
                   dialog.Height = window.Bounds.Height;
               };
               var layer = OverlayLayer.GetOverlayLayer(window);
               layer.Children.Add(dialog);
               Debug.WriteLine("dialog added");
           });
        }

        internal static void CloseDialogOn(WindowBase window, Control dialog)
        {
           Dispatcher.UIThread.Post(() => 
           {
               var layer = OverlayLayer.GetOverlayLayer(window);
               if (layer.Children.Contains(dialog))
               {
                   layer.Children.Remove(dialog);
               }
               Debug.WriteLine("dialog closed");
           });
        }
    } 
}
