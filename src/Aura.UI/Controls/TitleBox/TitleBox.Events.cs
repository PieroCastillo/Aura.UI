using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class TitleBox
    {
        public event EventHandler<RoutedEventArgs> MainButtonClick
        {
            add => AddHandler(MainButtonClickEvent, value);
            remove => RemoveHandler(MainButtonClickEvent, value);
        }
        public static readonly RoutedEvent<RoutedEventArgs> MainButtonClickEvent =
            RoutedEvent.Register<TitleBox, RoutedEventArgs>(nameof(MainButtonClick), RoutingStrategies.Bubble);


        public event EventHandler<RoutedEventArgs> SecondaryButtonClick
        {
            add => AddHandler(SecondaryButtonClickEvent, value);
            remove => RemoveHandler(SecondaryButtonClickEvent, value);
        }
        public static readonly RoutedEvent<RoutedEventArgs> SecondaryButtonClickEvent =
            RoutedEvent.Register<TitleBox, RoutedEventArgs>(nameof(SecondaryButtonClick), RoutingStrategies.Bubble);
    }
}
