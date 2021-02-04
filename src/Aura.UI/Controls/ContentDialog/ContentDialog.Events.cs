using Avalonia.Interactivity;
using System;

namespace Aura.UI.Controls
{
    public partial class ContentDialog
    {
        public event EventHandler<RoutedEventArgs> OkButtonClick
        {
            add => AddHandler(OkButtonClickEvent, value);
            remove => RemoveHandler(OkButtonClickEvent, value);
        }

        public static readonly RoutedEvent<RoutedEventArgs> OkButtonClickEvent =
            RoutedEvent.Register<ContentDialog, RoutedEventArgs>(nameof(OkButtonClick), RoutingStrategies.Bubble);

        public event EventHandler<RoutedEventArgs> CancelButtonClick
        {
            add => AddHandler(CancelButtonClickEvent, value);
            remove => RemoveHandler(CancelButtonClickEvent, value);
        }

        public static readonly RoutedEvent<RoutedEventArgs> CancelButtonClickEvent =
            RoutedEvent.Register<ContentDialog, RoutedEventArgs>(nameof(CancelButtonClick), RoutingStrategies.Bubble);
    }
}