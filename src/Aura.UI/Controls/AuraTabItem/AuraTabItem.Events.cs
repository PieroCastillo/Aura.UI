using Avalonia.Interactivity;
using System;

namespace Aura.UI.Controls
{
    public partial class AuraTabItem
    {
        /// <summary>
        /// Is called before <see cref="AuraTabItem.Closing"/> occurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnClosing(object sender, RoutedEventArgs e)
        {
            IsClosing = true;
        }

        public event EventHandler<RoutedEventArgs> Closing
        {
            add => AddHandler(ClosingEvent, value);
            remove => RemoveHandler(ClosingEvent, value);
        }

        public static readonly RoutedEvent<RoutedEventArgs> ClosingEvent =
            RoutedEvent.Register<AuraTabItem, RoutedEventArgs>(nameof(Closing), RoutingStrategies.Bubble);

        public event EventHandler<RoutedEventArgs> CloseButtonClick
        {
            add => AddHandler(CloseButtonClickEvent, value);
            remove => RemoveHandler(CloseButtonClickEvent, value);
        }

        public static readonly RoutedEvent<RoutedEventArgs> CloseButtonClickEvent =
            RoutedEvent.Register<AuraTabItem, RoutedEventArgs>(nameof(CloseButtonClick), RoutingStrategies.Bubble);
    }
}