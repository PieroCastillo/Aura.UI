using System;
using Aura.UI.Controls.Primitives;
using Avalonia.Interactivity;
using JetBrains.Annotations;

namespace Aura.UI.Controls
{
    public partial class DesignerCanvas
    {
        public event EventHandler<RoutedEventArgs> SelectedControlChanged
        {
            add => AddHandler(SelectedControlChangedEvent, value);
            remove => RemoveHandler(SelectedControlChangedEvent, value);
        }

        public static readonly RoutedEvent<RoutedEventArgs> SelectedControlChangedEvent =
            RoutedEvent.Register<DesignerCanvas, RoutedEventArgs>(nameof(SelectedControlChanged), RoutingStrategies.Bubble);
    }
}