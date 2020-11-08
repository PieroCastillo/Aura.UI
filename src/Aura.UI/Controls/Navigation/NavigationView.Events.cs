using System;
using Avalonia.Interactivity;

namespace Aura.UI.Controls.Navigation
{
    public partial class NavigationView
    {
        public event EventHandler<RoutedEventArgs> FooterItemsChanged
        {
            add => AddHandler(FooterItemsChangedEvent, value);
            remove => RemoveHandler(FooterItemsChangedEvent, value);
        }

        public static readonly RoutedEvent<RoutedEventArgs> FooterItemsChangedEvent =
            RoutedEvent.Register<NavigationView, RoutedEventArgs>(nameof(FooterItemsChanged), RoutingStrategies.Bubble);
    }
}