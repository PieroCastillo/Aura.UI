using Aura.UI.Attributes;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Mobile.Primitives
{
    [TemplatePart(Name = "PART_AgreeButton", Type = typeof(Button))]
    public class DialogBase : HeaderedContentControl
    {
        Button AgreeButton;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            AgreeButton = this.GetControl<Button>(e, "PART_AgreeButton");

            AgreeButton.Click += OnAgreeButtonClick;
        }

        #region Funcionaties
        /// <summary>
        /// Do something when the Cancel Button is  Clicked
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The Information of the event</param>
        protected virtual void OnAgreeButtonClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Defines the content of the agree button
        /// </summary>
        public object AgreeButtonContent
        {
            get => GetValue(AgreeButtonContentProperty);
            set => SetValue(AgreeButtonContentProperty, value);
        }
        public static readonly StyledProperty<object> AgreeButtonContentProperty =
            AvaloniaProperty.Register<DialogBase, object>(nameof(AgreeButtonContent), "OK");
        #endregion
    }
}
