using Aura.UI.Controls.Primitives;
using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System;
using System.Collections;

namespace Aura.UI.Controls.Ribbon
{
    /// <summary>
    /// This control use shows a Ribbon in the Top
    /// Use a <see cref="RibbonItem"/> to add Headers and Contents
    /// </summary>
    public class Ribbon : TabViewBase
    {
        public MaterialButton? LeftButton;
        public MaterialButton? RightButton;
        private ToggleButton? ToggleStateButton;

        public Ribbon()
        {
            SelectedItemProperty.Changed.AddClassHandler<Ribbon>((x, e) => x.OnSelectionChanged(x, e));
        }

        protected override void OnSelectionChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            base.OnSelectionChanged(sender, e);

            PseudoClasses.Remove(":changing");
            PseudoClasses.Add(":changing");
        }

        #region Functionalities

        /// <summary>
        /// Close a RibbonItem
        /// </summary>
        /// <param name="ribbonItemToClose">The RibbonItem to close</param>
        public void CloseRibbonItem(RibbonItem ribbonItemToClose)
        {
            try
            {
                if (ribbonItemToClose != null)
                {
                    (Items as IList).Remove(ribbonItemToClose);
                }
            }
            catch (Exception e)
            {
                throw new Exception("The RibbonItem inserted does not exist", e);
            }
        }

        /// <summary>
        /// Close a RibbonItem
        /// </summary>
        /// <param name="index">The index of the RibbonItem to close</param>
        /// <param name="showException">Shows a Exception when the indexer point a RibbonItem that it doesn't exist</param>
        public void CloseRibbonItem(int index, bool showException = true)
        {
            try
            {
                (Items as IList).RemoveAt(index);
            }
            catch (Exception e)
            {
                if (showException != false)
                {
                    throw new Exception("The RibbonItem indexed does not exist", e);
                }
            }
        }

        /// <summary>
        /// Add a RibbonItem
        /// </summary>
        /// <param name="ribbonItemToAdd">The RibbonItem to Add</param>
        /// <param name="index">The Index of the RibbonItem</param>
        public void AddRibbonItem(RibbonItem ribbonItemToAdd, int index)
        {
            if (ribbonItemToAdd != null)
            {
                (Items as IList).Insert(index, ribbonItemToAdd);
            }
        }

        #endregion Functionalities

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            LeftButton = this.GetControl<MaterialButton>(e, "PART_LeftButton");
            RightButton = this.GetControl<MaterialButton>(e, "PART_RightButton");
            ToggleStateButton = this.GetControl<ToggleButton>(e, "PART_Toggle");
            
            if(ToggleStateButton is null) throw new Exception("The Ribbon must have a ToggleButton with the name PART_Toggle");

            ToggleStateButton.IsCheckedChanged+= (sender, e) =>
            {
                ToggleState();
            };
        }

        protected void ToggleState()
        {
            switch (ExpansionState)
            {
                case ExpansionState.Total:
                    ExpansionState = ExpansionState.Hidden;
                    break;
                //case ExpansionState.Floating:
                //    this.ExpansionState = ExpansionState.Hidden;
                //    break;
                case ExpansionState.Hidden:
                    ExpansionState = ExpansionState.Total;
                    break;
            }
        }

        #region Properties

        /// <summary>
        /// LeftContent of the the Ribbon
        /// </summary>
        public object LeftContent
        {
            get => GetValue(LeftContentProperty);
            set => SetValue(LeftContentProperty, value);
        }

        public static readonly StyledProperty<object> LeftContentProperty =
             AvaloniaProperty.Register<Ribbon, object>(nameof(LeftContent), "Left");

        /// <summary>
        /// Gets or Sets if the Left content is visible.
        /// </summary>
        public bool LeftContentVisible
        {
            get => GetValue(LeftContentVisibleProperty);
            set => SetValue(LeftContentVisibleProperty, value);
        }

        public static readonly StyledProperty<bool> LeftContentVisibleProperty =
             AvaloniaProperty.Register<Ribbon, bool>(nameof(LeftContent));


        /// <summary>
        /// RightContent of the the Ribbon
        /// </summary>
        public object RightContent
        {
            get => GetValue(RightContentProperty);
            set => SetValue(RightContentProperty, value);
        }

        public static readonly StyledProperty<object> RightContentProperty =
            AvaloniaProperty.Register<Ribbon, object>(nameof(RightContent), "Right");

        /// <summary>
        /// Gets or Sets if the Right content is visible.
        /// </summary>
        public bool RightContentVisible
        {
            get => GetValue(RightContentVisibleProperty);
            set => SetValue(RightContentVisibleProperty, value);
        }

        public static readonly StyledProperty<bool> RightContentVisibleProperty =
             AvaloniaProperty.Register<Ribbon, bool>(nameof(RightContent));

        /// <summary>
        /// Header of the the Ribbon
        /// </summary>
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<Ribbon, object>(nameof(Header), "Avalonia.App");

        /// <summary>
        /// Get or set the expansion state of the Ribbon
        /// </summary>
        public ExpansionState ExpansionState
        {
            get => GetValue(ExpansionStateProperty);
            set => SetValue(ExpansionStateProperty, value);
        }

        public static readonly StyledProperty<ExpansionState> ExpansionStateProperty =
            AvaloniaProperty.Register<Ribbon, ExpansionState>(nameof(ExpansionState), ExpansionState.Total);

        /// <summary>
        /// Defines the Pane Height of the Ribbon when this is opened
        /// </summary>
        public double OpenPaneHeight
        {
            get => GetValue(OpenPaneLengthProperty);
            set => SetValue(OpenPaneLengthProperty, value);
        }

        public static readonly StyledProperty<double> OpenPaneLengthProperty =
            AvaloniaProperty.Register<Ribbon, double>(nameof(OpenPaneHeight), 150);

        #endregion Properties
    }
}