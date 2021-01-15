using Aura.UI.UIExtensions;
using Avalonia.Controls.Mixins;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Navigation
{
    public class SuperNavigationViewItem : SuperNavigationViewItemBase
    {
        static SuperNavigationViewItem()
        {
            SelectableMixin.Attach<SuperNavigationViewItem>(IsSelectedProperty);
        }

        protected override void OnClosed(object sender, RoutedEventArgs e)
        {
            base.OnClosed(sender, e);

            this.GetParentTOfLogical<SuperNavigationView>().SelectSingleItem(this);
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            e.Handled = true;

            if (!IsSelected)
            {
                this.GetParentTOfLogical<SuperNavigationView>().SelectSingleItem(this);
            }
        }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            base.OnPointerMoved(e);

            e.Handled = true;
        }
    }
}
