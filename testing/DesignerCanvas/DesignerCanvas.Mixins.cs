using System;
using Aura.UI.Controls.Primitives;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Aura.UI.Controls
{
    public partial class DesignerCanvas
    {
        public static void MakeDesignable<T>(AvaloniaProperty<bool> inDesignProperty) where T : Control, IDesignable
        {
            Contract.Requires<ArgumentNullException>(inDesignProperty != null);

            inDesignProperty.Changed.Subscribe(x =>
            {
                var sender = x.Sender as T;

                if (sender != null)
                {
                    ((IPseudoClasses)sender.Classes).Set(":indesign", x.NewValue.GetValueOrDefault());
                    
                    sender.RaiseEvent(new RoutedEventArgs
                    {
                        RoutedEvent = DesignerCanvas.SelectedControlChangedEvent
                    });
                }
            });
        }
    }
}