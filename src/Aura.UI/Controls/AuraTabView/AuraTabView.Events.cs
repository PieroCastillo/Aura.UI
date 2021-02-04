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

        public static readonly RoutedEvent<RoutedEventArgs> ClickOnAddingButtonEvent =
            RoutedEvent.Register<AuraTabView, RoutedEventArgs>(nameof(ClickOnAddingButton), RoutingStrategies.Bubble);
    }
}