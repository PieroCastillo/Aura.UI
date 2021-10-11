using Aura.UI.Extensions;
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

        public NavigationViewLinker()
        {
            TopContentProperty.Changed.Subscribe(SetTopContentIsNull);
        }

        private void SetTopContentIsNull(AvaloniaPropertyChangedEventArgs<object> e)
        {
            if (TopContent is null)
            {
                TopContentVisible = false;
            }
            else
            {
                TopContentVisible = true;
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