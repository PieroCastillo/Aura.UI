using Aura.UI.Attributes;
using Aura.UI.Mobile.Dialogs;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Mobile.Primitives
{
    [TemplatePart(Name = "PART_AgreeButton", Type = typeof(Button))]
    public class DialogBase : HeaderedContentControl, IDialog, IHeadered
    {
        public Button AgreeButton;

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

        public void ApplyDialogParameters(DialogParameters dialogParameters)
        {
            this.Header = dialogParameters.Header;
            this.Content = dialogParameters.Content;
            this.AgreeButtonContent = dialogParameters.AgreeContentButton;

            //this.AgreeButton.Click += (sender, e) =>
            //{
            //    dialogParameters.AgreeClick.Invoke();
            //};
        }

        /// <summary>
        /// Tries to remove the Dialog from a panel
        /// </summary>
        /// <typeparam name="TPanel"></typeparam>
        /// <returns></returns>
        public bool TryToRemoveFromPanel(Panel panel)
        {
            try
            {
                //var panel = this.GetParentTOfLogical<TPanel>();
                panel.Children.Remove(this);
                return true;
            }
            catch
            {
                return false;
            }
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

        ///// <summary>
        ///// Defines the Header
        ///// </summary>
        //public object Header
        //{
        //    get => GetValue(HeaderProperty);
        //    set => SetValue(HeaderProperty, value);
        //}
        //public static readonly StyledProperty<object> HeaderProperty =
        //    AvaloniaProperty.Register<DialogBase, object>(nameof(Header), "Header");

        ///// <summary>
        ///// Defines the Template of the header
        ///// </summary>
        //public ITemplate HeaderTemplate
        //{
        //    get => GetValue(HeaderTemplateProperty);
        //    set => SetValue(HeaderTemplateProperty, value);
        //}
        //public static readonly StyledProperty<ITemplate> HeaderTemplateProperty =
        //    AvaloniaProperty.Register<DialogBase, ITemplate>(nameof(HeaderTemplate));
        #endregion
    }
}
