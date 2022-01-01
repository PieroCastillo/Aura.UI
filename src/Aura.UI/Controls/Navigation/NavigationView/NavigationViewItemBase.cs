using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Interactivity;
using System;
using System.Diagnostics;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.LogicalTree;

namespace Aura.UI.Controls.Navigation
{
    [PseudoClasses(":opened", ":closed", ":selected", ":compact")]
    public partial class NavigationViewItemBase : TreeViewItem, IHeadered
    {
        private object _content = "Content";
        static NavigationViewItemBase()
        {
            IsExpandedProperty.Changed.AddClassHandler<NavigationViewItemBase>(
                (x, e) =>
                {
                    if (x.IsExpanded == true)
                    {
                        var o_e = new RoutedEventArgs(OpenedEvent);
                        x.RaiseEvent(o_e);
                    }
                    else if (x.IsExpanded == false)
                    {
                        var c_e = new RoutedEventArgs(ClosedEvent);
                        x.RaiseEvent(c_e);
                    }
                });
            OpenedEvent.AddClassHandler<NavigationViewItemBase>((x, e) => x.OnOpened(x, e));
            ClosedEvent.AddClassHandler<NavigationViewItemBase>((x, e) => x.OnClosed(x, e));
            IsSelectedProperty.Changed.AddClassHandler<NavigationViewItemBase>
                ((x, e) =>
                {
                    if (x.IsSelected)
                    {
                        x.OnSelected(x, e);
                    }
                    else if (!x.IsSelected)
                    {
                        x.OnDeselected(x, e);
                    }
                });
            IsOpenProperty.Changed.Subscribe(e => OnIsOpenChanged(e));
            OpenPaneLengthProperty.Changed.Subscribe(OnPaneSizesChanged);
            CompactPaneLengthProperty.Changed.Subscribe(OnPaneSizesChanged);
        }

        private static void OnPaneSizesChanged(AvaloniaPropertyChangedEventArgs<double> e)
        {
            if (e.Sender is NavigationViewItemBase n)
            {
                n.ExternalLength = n.OpenPaneLength - n.CompactPaneLength;
            }
        }

        private static void OnIsOpenChanged(AvaloniaPropertyChangedEventArgs<bool> e)
        {
            if (e.Sender is NavigationViewItem sender)
            {
                if (sender.IsSelected && sender.Parent is NavigationViewItem nw && nw.Parent is NavigationView nwp && nw.SelectOnClose)
                {
                    nwp.SelectSingleItem(nw);
                }

                switch (sender.IsOpen)
                {
                    case true:
                        sender.RaiseEvent(new RoutedEventArgs(OpenedEvent));
                        break;
                    case false:
                        sender.IsExpanded = false;
                        sender.RaiseEvent(new RoutedEventArgs(ClosedEvent));
                        break;
                }
            }
        }

        public NavigationViewItemBase()
        {
            NavigationViewDistance = 0;
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            UpdatePseudoClasses();
        }

        protected virtual void OnDeselected(object sender, AvaloniaPropertyChangedEventArgs e)
        {

        }

        protected virtual void OnSelected(object sender, AvaloniaPropertyChangedEventArgs e)
        {

        }

        protected virtual void OnOpened(object sender, RoutedEventArgs e)
        {
            UpdatePseudoClasses();
        }

        protected virtual void OnClosed(object sender, RoutedEventArgs e)
        {
            IsExpanded = false;
            UpdatePseudoClasses();
        }

        private void UpdatePseudoClasses()
        {
            if (IsOpen)
            {
                PseudoClasses.Remove(":closed");
                PseudoClasses.Add(":opened");
            }
            else
            {
                PseudoClasses.Remove(":opened");
                PseudoClasses.Add(":closed");
            }
        }

        public event EventHandler<RoutedEventArgs> Opened
        {
            add => AddHandler(OpenedEvent, value);
            remove => RemoveHandler(OpenedEvent, value);
        }

        public static readonly RoutedEvent<RoutedEventArgs> OpenedEvent =
            RoutedEvent.Register<NavigationViewItemBase, RoutedEventArgs>(nameof(Opened), RoutingStrategies.Bubble);

        public event EventHandler<RoutedEventArgs> Closed
        {
            add => AddHandler(ClosedEvent, value);
            remove => RemoveHandler(ClosedEvent, value);
        }

        public static readonly RoutedEvent<RoutedEventArgs> ClosedEvent =
            RoutedEvent.Register<NavigationViewItemBase, RoutedEventArgs>(nameof(Closed), RoutingStrategies.Bubble);
    }
}