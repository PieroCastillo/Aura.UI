﻿using Aura.UI.Attributes;
using Aura.UI.Controls.Generators;
using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using System.Collections;
using System.Linq;

namespace Aura.UI.Controls
{
    /// <summary>
    /// A powered-up TabControl
    /// For add a new Tab by code use the <see cref="AuraTabView.AdderButton"/>
    /// </summary>
    [TemplatePart(Name = "PART_AdderButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_InternalBorder", Type = typeof(Border))]
    public partial class AuraTabView : TabViewBase, IHeadered, IFootered
    {
        #region Fiels

        /// <summary>
        /// This Button add a new TabItem
        /// </summary>
        public Button AdderButton;

        public double lastselectindex = 0;
        protected Border b_;
        protected Grid g_;

        #endregion Fiels

        #region Methods

        protected void AdderButtonClicked(object sender, RoutedEventArgs e)
        {
            var e_ = new RoutedEventArgs(ClickOnAddingButtonEvent);
            RaiseEvent(e_);
            e_.Handled = true;
        }

        static AuraTabView()
        {
            SelectionModeProperty.OverrideDefaultValue<AuraTabView>(SelectionMode.Single);
        }

        protected override IItemContainerGenerator CreateItemContainerGenerator()
        {
            return new AuraTabItemContainerGenerator(this);
        }

        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        {
            base.OnPropertyChanged(change);

            if (this.SelectedItem == null)
            {
                double d = ((double)ItemCount / 2);
                if (this.lastselectindex < d & ItemCount != 0)
                {
                    SelectedItem = (Items as IList).OfType<object>().FirstOrDefault();
                }
                else if (lastselectindex >= d & ItemCount != 0)
                {
                    SelectedItem = (Items as IList).OfType<object>().LastOrDefault();
                }
            }
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            AdderButton = this.GetControl<Button>(e, "PART_AdderButton");

            AdderButton.Click += AdderButtonClicked;

            b_ = this.GetControl<Border>(e, "PART_InternalBorder");
            g_ = this.GetControl<Grid>(e, "PART_InternalGrid");
            //dock_container = this.GetControl<DockPanel>(e, "PART_DockContainer");

            this.PropertyChanged += AuraTabView_PropertyChanged;
        }

        private void AuraTabView_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            this.WidthRemainingSpace = g_.Bounds.Width;
            this.HeightRemainingSpace = g_.Bounds.Height;
        }

        #endregion Methods
    }
}