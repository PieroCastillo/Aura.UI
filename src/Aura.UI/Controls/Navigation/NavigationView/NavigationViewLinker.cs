using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using System;

namespace Aura.UI.Controls.Navigation
{
    public partial class NavigationViewLinker : ContentControl
    {
        static NavigationViewLinker()
        {
            TopContentIsNullProperty.Changed.Subscribe(SetTopContentIsNull);
        }

        private static void SetTopContentIsNull(AvaloniaPropertyChangedEventArgs<bool> e)
        {
            var c = e.Sender as NavigationViewLinker;

            if (c != null)
            {
                if (c.TopContent != null)
                {
                    c.TopContentIsNull = false;
                }

                if (c.TopContent is null)
                {
                    c.TopContentIsNull = true;
                }
            }
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);
            if (LinkTo != null & e.InitialPressMouseButton == MouseButton.Left)
            {
                var parent = this.GetParentTOfVisual<NavigationView>();

                if (parent != null & IsPointerOver)
                {
                    parent.SelectSingleItem(LinkTo);
                }
            }
        }
    }
}