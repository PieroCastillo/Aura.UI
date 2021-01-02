using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Generators
{
    public class AuraTabItemContainerGenerator : ItemContainerGenerator<AuraTabItem>
    {
        public AuraTabItemContainerGenerator(AuraTabView owner) : base(owner, ContentControl.ContentProperty, ContentControl.ContentTemplateProperty)
        {
            Owner = owner;
        }

        public new AuraTabView Owner { get; }

        protected override IControl CreateContainer(object item)
        {
            var tabItem = (AuraTabItem)base.CreateContainer(item);

            tabItem[~TabControl.TabStripPlacementProperty] = Owner[~TabControl.TabStripPlacementProperty];

            if (tabItem.HeaderTemplate == null)
            {
                tabItem[~HeaderedContentControl.HeaderTemplateProperty] = Owner[~ItemsControl.ItemTemplateProperty];
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
                tabItem[~ContentControl.ContentTemplateProperty] = Owner[~AuraTabView.ContentTemplateProperty];
            }

            return tabItem;
        }
    }
}
