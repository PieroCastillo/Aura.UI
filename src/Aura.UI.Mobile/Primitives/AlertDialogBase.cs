using Aura.UI.Attributes;
using Aura.UI.Mobile.Dialogs;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Mobile.Primitives
{
    /// <summary>
    /// This control shows an alert dialog
    /// </summary>
    [TemplatePart(Name = "PART_AgreeButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_CancelButton", Type = typeof(Button))]
    public class AlertDialogBase : DialogBase
    {
        public Button CancelButton;

        public AlertDialogBase()
        {
            PseudoClasses.Set(":emergency", IsEmergency == true);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            CancelButton = this.GetControl<Button>(e, "PART_CancelButton");

            CancelButton.Click += OnCancelButtonClick;
        }

        #region Funcionaties
        /// <summary>
        /// Do something when the Cancel Button is  Clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The Information of the event</param>
        protected virtual void OnCancelButtonClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            
        }

        public void ApplyAlertDialogParameters(AlertDialogParameters dialogParameters)
        {
            this.Header = dialogParameters.Header;
            this.Content = dialogParameters.Content;
            this.AgreeButtonContent = dialogParameters.AgreeContentButton;
            this.CancelButtonContent = dialogParameters.CancelContentButton;

            this.AgreeButton.Click += (sender, e) =>
            {
                dialogParameters.AgreeClick.Invoke();
            };
            this.CancelButton.Click += (sender, e) =>
            {
                dialogParameters.CancelClick.Invoke();
            };
        }
        #endregion

        #region Properties
        /// <summary>
        /// Defines the content of the cancel button
        /// </summary>
        public object CancelButtonContent
        {
            get => GetValue(CancelButtonContentProperty);
            set => SetValue(CancelButtonContentProperty, value);
        }
        public static readonly StyledProperty<object> CancelButtonContentProperty =
            AvaloniaProperty.Register<AlertDialogBase, object>(nameof(CancelButtonContent), "Cancel");

        public bool IsEmergency
        {
            get => GetValue(IsEmergencyProperty);
            set => SetValue(IsEmergencyProperty, value);
        }
        public static readonly StyledProperty<bool> IsEmergencyProperty =
            AvaloniaProperty.Register<AlertDialogBase, bool>(nameof(IsEmergency), false);
        #endregion
    }
}
