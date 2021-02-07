using Avalonia.Interactivity;
using System;

namespace Aura.UI.Controls
{
    public partial class AuraTabView
    {
        /// <summary>
        /// It's raised when the adder button is clicked
        /// </summary>
        public event EventHandler<RoutedEventArgs> ClickOnAddingButton
        {
            add => AddHandler(ClickOnAddingButtonEvent, value);
            remove => RemoveHandler(ClickOnAddingButtonEvent, value);
        }

        /// <summary>
        /// Defines the <see cref="ClickOnAddingButton"/> event.
        /// </summary>
        public static readonly RoutedEvent<RoutedEventArgs> ClickOnAddingButtonEvent =
            RoutedEvent.Register<AuraTabView, RoutedEventArgs>(nameof(ClickOnAddingButton), RoutingStrategies.Bubble);
    }
}