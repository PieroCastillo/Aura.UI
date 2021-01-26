using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Aura.UI.Exceptions;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System.Collections;

namespace Aura.UI.Controls.Ribbon
{
    /// <summary>
    /// This control use shows a Ribbon in the Top
    /// Use a <see cref="RibbonItem"/> to add Headers and Contents
    /// </summary>
    public class Ribbon : TabViewBase, IHeadered
    {
        public MaterialButton LeftButton;
        public MaterialButton RightButton;
        ToggleButton ToggleStateButton;

        public Ribbon()
        {
            SelectedItemProperty.Changed.AddClassHandler<Ribbon>((x,e) => x.OnSelectionChanged(x,e));
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
            catch (AuraException<Ribbon> e)
            {
                throw new AuraException<Ribbon>("The RibbonItem inserted does not exist", e);
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
            catch (AuraException<Ribbon> e)
            {
                if (showException != false)
                {
                    throw new AuraException<Ribbon>("The RibbonItem indexed does not exist", e);
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
        /// <summary>
        /// LeftContent of the the Ribbon
        /// </summary>
        public object LeftContent
        {
            get { return GetValue(LeftContentProperty); }
            set { SetValue(LeftContentProperty, value); }
        }
        public static readonly StyledProperty<object> LeftContentProperty =
             AvaloniaProperty.Register<Ribbon, object>(nameof(LeftContent), "Left");
        /// <summary>
        /// RightContent of the the Ribbon
        /// </summary>
        public object RightContent
        {
            get { return GetValue(RightContentProperty); }
            set { SetValue(RightContentProperty, value); }
        }
        public static readonly StyledProperty<object> RightContentProperty =
            AvaloniaProperty.Register<Ribbon, object>(nameof(RightContent), "Right");
        /// <summary>
        /// Header of the the Ribbon
        /// </summary>
        public object Header
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public static readonly StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<Ribbon, object>(nameof(Header), "Avalonia.App");
        /// <summary>
        /// Get or set the expansion state of the Ribbon
        /// </summary>
        public ExpansionState ExpansionState
        {
            get { return GetValue(ExpansionStateProperty); }
            set { SetValue(ExpansionStateProperty, value); }
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
        #endregion
    }
}
