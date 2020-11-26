using Aura.UI.Attributes;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading.Tasks;
using Aura.UI.Controls.Primitives;

namespace Aura.UI.Controls
{
    /// <summary>
    /// A powered-up TabControl
    /// For add a new Tab by code use the <see cref="AuraTabView.AdderButton"/>
    /// </summary>
    [TemplatePart(Name = "PART_AdderButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_InternalBorder", Type = typeof(Border))]
    public partial class AuraTabView : TabControl, IHeadered, IFootered
    {
        #region Fiels
        /// <summary>
        /// This Button add a new TabItem
        /// </summary>
        public Button AdderButton;

        public double lastselectindex = 0;
        protected Border b_;
        protected Grid g_;
        protected internal DockPanel dock_container;
        [Obsolete]
        protected IEnumerable<Action> Actions = new List<Action>();
        #endregion
        #region Methods
        
        /// <summary>
        /// You should overwrite this Method for add your custom tabitem
        /// </summary>
        /// <param name="sender">the sender object</param>
        /// <param name="e">the information of the event</param>
        [Obsolete]
        protected virtual void OnAdding(object sender, RoutedEventArgs e)
        {
            //this.AddTab(new AuraTabItem() { Header = "HeaderTest", Content = "ContentTest" }, true) ;
            foreach (Action action in Actions)
            {
                action.Invoke();
            }
        }
        
        protected void AdderButtonClicked(object sender, RoutedEventArgs e)
        {
            var e_ = new RoutedEventArgs(ClickOnAddingButtonEvent);
            RaiseEvent(e_);
            e_.Handled = true;
        }

        static AuraTabView()
        {
            SelectionModeProperty.OverrideDefaultValue<AuraTabView>(SelectionMode.Toggle);
        }

        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        {
            base.OnPropertyChanged(change);

            if (this.SelectedItem == null)
            {
                double d = ((double)ItemCount / 2);
                if (this.lastselectindex < d)
                {
                    SelectedItem = (Items as IList).OfType<object>().FirstOrDefault();
                }
                else if (lastselectindex >= d)
                {
                    SelectedItem = (Items as IList).OfType<object>().LastOrDefault();
                }
            }
        }

        /// <summary>
        /// Execute the action what is putted
        /// </summary>
        /// <param name="action">The action to execute</param>
        [Obsolete]
        public void AddActionToAdderButton(Action action)
        {
            (Actions as IList<Action>).Add(action);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            AdderButton = this.GetControl<Button>(e, "PART_AdderButton");
            
#pragma warning disable 612
            AdderButton.Click += OnAdding; // In the future this will be removed
#pragma warning restore 612

            AdderButton.Click += AdderButtonClicked;

            b_ = this.GetControl<Border>(e, "PART_InternalBorder");
            g_ = this.GetControl<Grid>(e, "PART_InternalGrid");
            dock_container = this.GetControl<DockPanel>(e, "PART_DockContainer");

            this.PropertyChanged += AuraTabView_PropertyChanged;
        }

        private void AuraTabView_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            this.WidthRemainingSpace = g_.Bounds.Width;
            this.HeightRemainingSpace = g_.Bounds.Height;

            /*if (e.Property.Name == SelectedItemProperty.Name)
            {
                if (this.ItemCount == 0)
                {
                    SelectedItem = null;
                }
                else
                {
                    this.SelectedItem = (this.Items as IList)[this.SelectedIndex];
                }
            }*/
        }

        #endregion

    }
}
