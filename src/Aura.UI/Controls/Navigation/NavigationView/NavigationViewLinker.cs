using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using System;
using Avalonia.Controls.Metadata;

namespace Aura.UI.Controls.Navigation
{
    [PseudoClasses(":pressed")]
    public partial class NavigationViewLinker : ContentControl
    {
        private bool _pointerOver;
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

        /// <inheritdoc/>
        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);
            if (LinkTo != null & e.InitialPressMouseButton == MouseButton.Left)
            {
                var parent = this.GetParentTOfVisual<NavigationView>();

                if (parent != null & this.PointerEffectivelyOver(e))
                {
                    parent.SelectSingleItem(LinkTo);
                }
            }

            PseudoClasses.Remove(":pressed");
        }

        /// <inheritdoc/>
        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            PseudoClasses.Add(":pressed");
        }

        /// <inheritdoc/>
        protected override void OnPointerLeave(PointerEventArgs e)
        {
            base.OnPointerLeave(e);
            _pointerOver = false;
        }
    }
}