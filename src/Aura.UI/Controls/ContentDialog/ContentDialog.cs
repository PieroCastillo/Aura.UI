using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class ContentDialog : ContentDialogBase
    {
        private Button OkButton;
        private Button CancelButton;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            OkButton = this.GetControl<Button>(e, "PART_OkButton");
            CancelButton = this.GetControl<Button>(e, "PART_CancelButton");
            var bs = this.GetControl<Grid>(e, "PART_GridContainer");
            bs.PointerPressed += (s, n) =>
            {
                this.GetParentTOfVisual<Window>().BeginMoveDrag(n);
            };

            OkButton.Click += (s, e) =>
            {
                var x = new RoutedEventArgs(OkButtonClickEvent);
                RaiseEvent(x);
                x.Handled = true;
            };
            CancelButton.Click += (s, e) =>
            {
                var l = new RoutedEventArgs(CancelButtonClickEvent);
                RaiseEvent(l);
                l.Handled = true;
            };
        }
    }
}
