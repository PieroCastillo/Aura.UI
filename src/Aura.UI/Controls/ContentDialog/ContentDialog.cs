using System;
using Aura.UI.Controls.Primitives;
using Aura.UI.Extensions;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;

namespace Aura.UI.Controls
{
    public partial class ContentDialog : ContentDialogBase
    {
        private Button? OkButton;
        private Button? CancelButton;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            var okButton = this.GetControl<Button>(e, "PART_OkButton");
            var cancelButton = this.GetControl<Button>(e, "PART_CancelButton");
            
            OkButton = okButton ?? throw new Exception("OkButton not found");
            //OkButton = this.GetControl<Button>(e, "PART_OkButton");
            
            CancelButton = cancelButton ?? throw new Exception("CancelButton not found");
            //CancelButton = this.GetControl<Button>(e, "PART_CancelButton");
            
            var bs = this.GetControl<Grid>(e, "PART_GridContainer");

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