using Aura.UI.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.LogicalTree;
using Avalonia.Reactive;
using System;

namespace Aura.UI.Controls.Generators
{
    public class AuraTabItemContainerGenerator : ItemContainerGenerator<AuraTabItem>
    {
        public AuraTabItemContainerGenerator(AuraTabView owner,
            AvaloniaProperty contentProperty,
            AvaloniaProperty contentTemplateProperty,
            AvaloniaProperty headerProperty,
            AvaloniaProperty iconProperty,
            AvaloniaProperty<bool> isClosableProperty) : base(owner, contentProperty, contentTemplateProperty)
        {
            HeaderProperty = headerProperty;
            IconProperty = iconProperty;
            IsClosableProperty = isClosableProperty;
        }

        private AvaloniaProperty HeaderProperty, IsClosableProperty, IconProperty;

        private IControl CreateContainer<T>(object item) where T : class, IControl, new()
        {
            var container = item as T;

            if (container != null)
            {
                return container;
            }
            else
            {
                var result = new T();

                if (ContentTemplateProperty != null)
                {
                    result.SetValue(ContentTemplateProperty, ItemTemplate, BindingPriority.Style);
                }

                result.SetValue(ContentProperty, item, BindingPriority.Style);

                if (!(item is IControl))
                {
                    result.DataContext = item;
                }

                return result;
            }
        }

        protected override IControl CreateContainer(object item)
        {
            var container = item as AuraTabItem;

            var tabItem = (AuraTabItem)CreateContainer<AuraTabItem>(item);

            tabItem.Bind(TabItem.TabStripPlacementProperty, new OwnerBinding<Dock>(
                tabItem,
                TabControl.TabStripPlacementProperty));

            if (tabItem.HeaderTemplate == null)
            {
                tabItem.Bind(AuraTabItem.HeaderTemplateProperty, new OwnerBinding<IDataTemplate>(
                    tabItem,
                    AuraTabView.ItemTemplateProperty));
            }

            if (tabItem.Header == null)
            {
                if (item is IHeadered headered)
                {
                    tabItem.Header = headered.Header;
                }
                else
                {
                    if (!(tabItem.DataContext is IControl))
                    {
                        tabItem.Header = tabItem.DataContext;
                    }
                }
            }

            if (!(tabItem.Content is IControl))
            {
                tabItem.Bind(TabItem.ContentTemplateProperty, new OwnerBinding<IDataTemplate>(
                    tabItem,
                    TabControl.ContentTemplateProperty));
            }

            if(item is IAuraTabItemTemplate tab)
            {
                if(tab.Icon is not null)
                    tabItem.SetValue(IconProperty, tab.Icon, BindingPriority.Style);
                
                tabItem.SetValue(IsClosableProperty, tab.IsClosable, BindingPriority.Style);
            }

            return tabItem;

            //if (item is IAuraTabItemTemplate temp)
            //{
            //    var tab = new AuraTabItem();
                
            //    tab.SetValue(HeaderProperty, temp.Header, BindingPriority.Style);
            //    tab.SetValue(IconProperty, temp.Icon, BindingPriority.Style);
            //    tab.SetValue(ContentProperty, temp.Content);
            //    tab.SetValue(IsClosableProperty, temp.IsClosable);

            //    tab.Bind(AuraTabItem.TabStripPlacementProperty, Owner.GetObservable(AuraTabView.TabStripPlacementProperty), BindingPriority.Style);
                
            //    return tab;
            //}
            //else if (item is not null)
            //{
            //    container.Bind(AuraTabItem.TabStripPlacementProperty, Owner.GetObservable(AuraTabView.TabStripPlacementProperty), BindingPriority.Style);
            //    return container;
            //}
            //else
            //{
            //    var tb = new AuraTabItem();
            //    tb.Bind(AuraTabItem.TabStripPlacementProperty, Owner.GetObservable(AuraTabView.TabStripPlacementProperty), BindingPriority.Style);
            //    return tb;
            //}
        }

        private class OwnerBinding<T> : SingleSubscriberObservableBase<T>
        {
            private readonly TabItem _item;
            private readonly StyledProperty<T> _ownerProperty;
            private IDisposable _ownerSubscription;
            private IDisposable _propertySubscription;

            public OwnerBinding(TabItem item, StyledProperty<T> ownerProperty)
            {
                _item = item;
                _ownerProperty = ownerProperty;
            }

            protected override void Subscribed()
            {
                _ownerSubscription = ControlLocator.Track(_item, 0, typeof(TabControl)).Subscribe(OwnerChanged);
            }

            protected override void Unsubscribed()
            {
                _ownerSubscription?.Dispose();
                _ownerSubscription = null;
            }

            private void OwnerChanged(ILogical c)
            {
                _propertySubscription?.Dispose();
                _propertySubscription = null;

                if (c is TabControl tabControl)
                {
                    _propertySubscription = tabControl.GetObservable(_ownerProperty)
                        .Subscribe(x => PublishNext(x));
                }
            }
        }
    }
}