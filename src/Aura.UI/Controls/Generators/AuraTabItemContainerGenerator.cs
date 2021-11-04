using Aura.UI.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Primitives;
using Avalonia.Data;

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


        protected override IControl CreateContainer(object item)
        {
            var container = item as AuraTabItem;
            
            if (item is IAuraTabItemTemplate temp)
            {
                var tab = new AuraTabItem();
                tab.SetValue(HeaderProperty, temp.Header, BindingPriority.Style);
                tab.SetValue(IconProperty, temp.Icon, BindingPriority.Style);
                tab.SetValue(ContentProperty, temp.Content);
                tab.SetValue(IsClosableProperty, temp.IsClosable);

                tab.Bind(AuraTabItem.TabStripPlacementProperty, Owner.GetObservable(AuraTabView.TabStripPlacementProperty), BindingPriority.Style);
                
                return tab;
            }
            else if (item is not null)
            {
                container.Bind(AuraTabItem.TabStripPlacementProperty, Owner.GetObservable(AuraTabView.TabStripPlacementProperty), BindingPriority.Style);
                return container;
            }
            else
            {
                var tb = new AuraTabItem();
                tb.Bind(AuraTabItem.TabStripPlacementProperty, Owner.GetObservable(AuraTabView.TabStripPlacementProperty), BindingPriority.Style);
                return tb;
            }
        }
    }
}