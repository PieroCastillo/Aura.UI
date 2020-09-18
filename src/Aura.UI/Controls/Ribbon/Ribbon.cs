using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Aura.UI.Exceptions;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Aura.UI.Controls.Ribbon
{
    [TemplatePart(Name = "PART_RightButton", Type = typeof(MaterialButton))]
    [TemplatePart(Name = "PART_LeftButton", Type = typeof(MaterialButton))]
    [TemplatePart(Name = "PART_Toggle", Type = typeof(ToggleButton))]
    public class Ribbon : TabControl, IMaterial, IHeadered
    {
        public MaterialButton LeftButton;
        public MaterialButton RightButton;
        ToggleButton ToggleStateButton;
   
        #region Functionalities
        public void CloseRibbonItem(RibbonItem ribbonItemToClose)
        {
            try
            {
                if (ribbonItemToClose != null)
                {
                    (Items as IList).Remove(ribbonItemToClose);
                }
            }
            catch(AuraException<Ribbon> e)
            {
                throw new AuraException<Ribbon>("The RibbonItem inserted does not exist", e);
            }
        }

        public void CloseRibbonItem(int index, bool showException = true)
        {
            try
            {
                (Items as IList).RemoveAt(index);
            }
            catch (AuraException<Ribbon> e)
            { 
                if(showException != false)
                {
                    throw new AuraException<Ribbon>("The RibbonItem indexed does not exist", e);
                }
            }
        } 
        public void AddRibbonItem(RibbonItem ribbonItemToAdd, int index)
        { 
             if(ribbonItemToAdd != null)
            {
                (Items as IList).Insert(index, ribbonItemToAdd);
            }
        }
        #endregion
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            LeftButton = this.GetControl<MaterialButton>(e, "PART_LeftButton");
            RightButton = this.GetControl<MaterialButton>(e, "PART_RightButton");
            ToggleStateButton = this.GetControl<ToggleButton>(e, "PART_Toggle");
            ToggleStateButton.Checked += (sender, e) =>
            {
                ToggleState();
            };
            ToggleStateButton.Unchecked += (sender, e) =>
            {
                ToggleState();
            };
        }
        protected void ToggleState()
        {
            switch (this.ExpansionState)
            {
                case ExpansionState.Total:
                    this.ExpansionState = ExpansionState.Hidden;
                    break;
                //case ExpansionState.Floating:
                //    this.ExpansionState = ExpansionState.Hidden;
                //    break;
                case ExpansionState.Hidden:
                    this.ExpansionState = ExpansionState.Total;
                    break;
            }
        }

        #region Properties
        public ExperimentalAcrylicMaterial Material
        {
            get { return GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }
        public static readonly StyledProperty<ExperimentalAcrylicMaterial> MaterialProperty =
            AvaloniaProperty.Register<Ribbon, ExperimentalAcrylicMaterial>(nameof(Material),
                new ExperimentalAcrylicMaterial()
                {
                    TintColor = Colors.Black,
                    MaterialOpacity = 1,
                    TintOpacity = 0.85
                });

        public bool MaterialIsVisible
        {
            get { return GetValue(MaterialIsVisibleProperty); }
            set { SetValue(MaterialIsVisibleProperty, value); }
        }
        public static readonly StyledProperty<bool> MaterialIsVisibleProperty =
             AvaloniaProperty.Register<Ribbon, bool>(nameof(MaterialIsVisible), true);

        public object LeftContent
        {
            get { return GetValue(LeftContentProperty); }
            set { SetValue(LeftContentProperty, value); }
        }
        public static readonly StyledProperty<object> LeftContentProperty =
             AvaloniaProperty.Register<Ribbon, object>(nameof(LeftContent), "Left");

        public object RightContent
        {
            get { return GetValue(RightContentProperty); }
            set { SetValue(RightContentProperty, value); }
        }
         public static readonly StyledProperty<object> RightContentProperty =
             AvaloniaProperty.Register<Ribbon, object>(nameof(RightContent), "Right");

        public object Header
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public static readonly StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<Ribbon, object>(nameof(Header), "Avalonia.App");

        public ExpansionState ExpansionState
        {
            get { return GetValue(ExpansionStateProperty); }
            set { SetValue(ExpansionStateProperty, value); }
        }
        public static readonly StyledProperty<ExpansionState> ExpansionStateProperty =
            AvaloniaProperty.Register<Ribbon, ExpansionState>(nameof(ExpansionState), ExpansionState.Total);
        #endregion
    }
    public enum ExpansionState
    { 
       Total/*, Floating*/, Hidden 
    }
}
