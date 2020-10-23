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
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Aura.UI.Controls
{
    /// <summary>
    /// A powered-up TabControl
    /// For add a new Tab by code use the <see cref="AuraTabView.AdderButton"/>
    /// </summary>
    [TemplatePart(Name = "PART_AdderButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_InternalBorder", Type = typeof(Border))]
    public class AuraTabView : TabControl
    {
        #region Fiels
        /// <summary>
        /// This Button add a new TabItem
        /// </summary>
        public Button AdderButton;
        protected Border b_;
        protected IEnumerable<Action> Actions = new List<Action>();
        #endregion
        #region Methods
        /// <summary>
        /// You should overwrite this Method for add your custom tabitem
        /// </summary>
        /// <param name="sender">the sender object</param>
        /// <param name="e">the information of the event</param>
        protected virtual void OnAdding(object sender, RoutedEventArgs e)
        {
            //this.AddTab(new AuraTabItem() { Header = "HeaderTest", Content = "ContentTest" }, true) ;
            foreach (Action action in Actions)
            {
                action.Invoke();
            }
        }
        /// <summary>
        /// Execute the action what is putted
        /// </summary>
        /// <param name="action">The action to execute</param>
        public void AddActionToAdderButton(Action action)
        {
            (Actions as IList<Action>).Add(action);
        }
        
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            AdderButton = this.GetControl<Button>(e, "PART_AdderButton");
            AdderButton.Click += OnAdding;

            b_ = this.GetControl<Border>(e, "PART_InternalBorder");
            this.PropertyChanged += AuraTabView_PropertyChanged;
        }

        private void AuraTabView_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            this.LateralSpaceLeftOver = b_.Width;
        }

        #endregion

        #region Properties
        /// <summary>
        /// This property defines if the <see cref="AuraTabView.AdderButton"/> can be visible, the default value is true
        /// </summary>
        public bool AdderButtonIsVisible
        {
            get { return GetValue(AdderButtonIsVisibleProperty); }
            set { SetValue(AdderButtonIsVisibleProperty, value); }
        }
        public static readonly StyledProperty<bool> AdderButtonIsVisibleProperty =
            AvaloniaProperty.Register<AuraTabView, bool>(nameof(AdderButtonIsVisible), true);
       
        /// <summary>
        /// This property defines what is the maximum width of the ItemsPresenter
        /// </summary>
        public int MaxWidthOfItemsPresenter
        {
            get { return GetValue(MaxWidthOfItemsPresenterProperty); }
            set { SetValue(MaxWidthOfItemsPresenterProperty, value); }
        }
        public readonly static StyledProperty<int> MaxWidthOfItemsPresenterProperty =
            AvaloniaProperty.Register<AuraTabView, int>(nameof(MaxWidthOfItemsPresenter), int.MaxValue);
        /// <summary>
        /// Gets or Sets the SecondaryBackground
        /// </summary>
        public IBrush SecondaryBackground
        {
            get => GetValue(SecondaryBackgroundProperty);
            set => SetValue(SecondaryBackgroundProperty, value);
        }
        public readonly static StyledProperty<IBrush> SecondaryBackgroundProperty =
            AvaloniaProperty.Register<AuraTabView, IBrush>(nameof(SecondaryBackground));

        /// <summary>
        /// Sets the margin of the itemspresenter
        /// </summary>
        public Thickness ItemsMargin
        {
            get => GetValue(ItemsMarginProperty);
            set => SetValue(ItemsMarginProperty, value);
        }
        public readonly static StyledProperty<Thickness> ItemsMarginProperty =
            AvaloniaProperty.Register<AuraTabView, Thickness>(nameof(ItemsMargin));

        private double _lateralspaceleftover;
        /// <summary>
        /// Gets the space that remains in the top
        /// </summary>
        public double LateralSpaceLeftOver
        {
            get => _lateralspaceleftover;
            private set => SetAndRaise(LateralSpaceLeftOverProperty, ref _lateralspaceleftover, value);
        }
        public readonly static DirectProperty<AuraTabView, double> LateralSpaceLeftOverProperty =
            AvaloniaProperty.RegisterDirect<AuraTabView, double>(
                nameof(LateralSpaceLeftOver),
                o => o.LateralSpaceLeftOver);
        #endregion
    }
}
