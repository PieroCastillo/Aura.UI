using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class AuraColorPicker
    {
        /// <summary>
        /// Raised when the Color 
        /// </summary>
        public event EventHandler<ColorChangedEventArgs> ColorChanged
        {
            add => AddHandler(ColorChangedEvent, value);
            remove => RemoveHandler(ColorChangedEvent, value);
        }

        public static readonly RoutedEvent<ColorChangedEventArgs> ColorChangedEvent =
            RoutedEvent.Register<AuraColorPicker, ColorChangedEventArgs>(nameof(ColorChanged), RoutingStrategies.Bubble);
    }
}
