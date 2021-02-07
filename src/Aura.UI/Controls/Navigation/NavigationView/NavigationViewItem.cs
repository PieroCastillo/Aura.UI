using Aura.UI.UIExtensions;
using Avalonia.Controls.Mixins;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Aura.UI.Controls.Navigation
{
    public class NavigationViewItem : NavigationViewItemBase
    {
        static NavigationViewItem()
        {
            SelectableMixin.Attach<NavigationViewItem>(IsSelectedProperty);
            FocusableProperty.OverrideDefaultValue<NavigationViewItem>(true);
        }

        protected override void OnClosed(object sender, RoutedEventArgs e)
        {
            base.OnClosed(sender, e);

            this.GetParentTOfLogical<NavigationView>().SelectSingleItem(this);
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            e.Handled = true;

            if (!IsSelected)
            {
                this.GetParentTOfLogical<NavigationView>().SelectSingleItem(this);
            }
        }
    }
}