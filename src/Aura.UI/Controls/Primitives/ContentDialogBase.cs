using Aura.UI.Services;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Aura.UI.Controls.Primitives
{
    public partial class ContentDialogBase : ContentControl
    {
        public void SetOwner(WindowBase owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException("The Owner can't be null.");
            }

            this.Owner = owner;
        }

        public void Show()
        {
            ContentDialogService.ShowDialogOn(Owner, this);
            var e = new RoutedEventArgs(ShowingEvent);
            RaiseEvent(e);
            e.Handled = true;
        }

        public virtual void Close()
        {
            var e = new RoutedEventArgs(ClosingEvent);
            this.RaiseEvent(e);
            e.Handled = true;
            ContentDialogService.CloseDialogOn(Owner, this);
        }

        public event EventHandler<RoutedEventArgs> Showing
        {
            add => AddHandler(ShowingEvent, value);
            remove => RemoveHandler(ShowingEvent, value);
        }

        public static readonly RoutedEvent<RoutedEventArgs> ShowingEvent =
            RoutedEvent.Register<ContentDialogBase, RoutedEventArgs>(nameof(Showing), RoutingStrategies.Bubble);

        public event EventHandler<RoutedEventArgs> Closing
        {
            add => AddHandler(ClosingEvent, value);
            remove => RemoveHandler(ClosingEvent, value);
        }

        public static readonly RoutedEvent<RoutedEventArgs> ClosingEvent =
            RoutedEvent.Register<ContentDialogBase, RoutedEventArgs>(nameof(Closing), RoutingStrategies.Bubble);

        private WindowBase Owner
        {
            get;
            set;
        }
    }
}