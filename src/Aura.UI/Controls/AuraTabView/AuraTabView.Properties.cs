using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Styling;

namespace Aura.UI.Controls
{
    public partial class AuraTabView
    {
        private object _fallbackcontent = new TextBlock
        {
            Text = "Nothing here",
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            FontSize = 16
        };

        /// <summary>
        /// This content is showed when there is no item.
        /// </summary>
        public object FallBackContent
        {
            get => _fallbackcontent;
            set => SetAndRaise(FallBackContentProperty, ref _fallbackcontent, value);
        }

        /// <summary>
        /// Defines the <see cref="FallBackContent"/> property.
        /// </summary>
        public static readonly DirectProperty<AuraTabView, object> FallBackContentProperty =
            AvaloniaProperty.RegisterDirect<AuraTabView, object>
            (nameof(FallBackContent),
             o => o.FallBackContent,
             (o, v) => o.FallBackContent = v);

        /// <summary>
        /// Gets or sets the Header.
        /// </summary>
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="Header"/> property.
        /// </summary>
        public static readonly StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<AuraTabView, object>(nameof(Header));

        /// <summary>
        /// Gets or sets the Header Template.
        /// </summary>
        public ITemplate HeaderTemplate
        {
            get => GetValue(HeaderTemplateProperty);
            set => SetValue(HeaderTemplateProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="HeaderTemplate"/> property.
        /// </summary>
        public static readonly StyledProperty<ITemplate> HeaderTemplateProperty =
            AvaloniaProperty.Register<AuraTabView, ITemplate>(nameof(HeaderTemplate));

        /// <summary>
        /// Gets or sets the Footer.
        /// </summary>
        public object Footer
        {
            get => GetValue(FooterProperty);
            set => SetValue(FooterProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="Footer"/> property.
        /// </summary>
        public static readonly StyledProperty<object> FooterProperty =
            AvaloniaProperty.Register<AuraTabView, object>(nameof(Footer));

        /// <summary>
        /// Defines the Footer Template.
        /// </summary>
        public ITemplate FooterTemplate
        {
            get => GetValue(FooterTemplateProperty);
            set => SetValue(FooterTemplateProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="FooterTemplate"/> property.
        /// </summary>
        public static readonly StyledProperty<ITemplate> FooterTemplateProperty =
            AvaloniaProperty.Register<AuraTabView, ITemplate>(nameof(FooterTemplateProperty));

        /// <summary>
        /// This property defines if the AdderButton can be visible, the default value is true.
        /// </summary>
        public bool AdderButtonIsVisible
        {
            get => GetValue(AdderButtonIsVisibleProperty);
            set => SetValue(AdderButtonIsVisibleProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="AdderButtonIsVisible"/> property.
        /// </summary>
        public static readonly StyledProperty<bool> AdderButtonIsVisibleProperty =
            AvaloniaProperty.Register<AuraTabView, bool>(nameof(AdderButtonIsVisible), true);

        /// <summary>
        /// This property defines what is the maximum width of the ItemsPresenter.
        /// </summary>
        public double MaxWidthOfItemsPresenter
        {
            get => GetValue(MaxWidthOfItemsPresenterProperty);
            set => SetValue(MaxWidthOfItemsPresenterProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="MaxWidthOfItemsPresenter"/> property.
        /// </summary>
        public readonly static StyledProperty<double> MaxWidthOfItemsPresenterProperty =
            AvaloniaProperty.Register<AuraTabView, double>(nameof(MaxWidthOfItemsPresenter), double.PositiveInfinity);

        /// <summary>
        /// Gets or Sets the SecondaryBackground.
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

        /// <summary>
        ///
        /// </summary>
        public readonly static StyledProperty<Thickness> ItemsMarginProperty =
            AvaloniaProperty.Register<AuraTabView, Thickness>(nameof(ItemsMargin));

        private double _heightremainingspace;

        /// <summary>
        /// Gets the space that remains in the top
        /// </summary>
        public double HeightRemainingSpace
        {
            get => _heightremainingspace;
            private set => SetAndRaise(HeightRemainingSpaceProperty, ref _heightremainingspace, value);
        }

        /// <summary>
        /// Defines the <see cref="HeightRemainingSpace"/> property.
        /// </summary>
        public readonly static DirectProperty<AuraTabView, double> HeightRemainingSpaceProperty =
            AvaloniaProperty.RegisterDirect<AuraTabView, double>(
                nameof(HeightRemainingSpace),
                o => o.HeightRemainingSpace);

        private double _widthremainingspace;

        /// <summary>
        /// Gets the space that remains in the top.
        /// </summary>
        public double WidthRemainingSpace
        {
            get => _widthremainingspace;
            private set => SetAndRaise(WidthRemainingSpaceProperty, ref _widthremainingspace, value);
        }

        /// <summary>
        /// Defines the <see cref="WidthRemainingSpace"/> property.
        /// </summary>
        public readonly static DirectProperty<AuraTabView, double> WidthRemainingSpaceProperty =
            AvaloniaProperty.RegisterDirect<AuraTabView, double>(
                nameof(WidthRemainingSpace),
                o => o.WidthRemainingSpace);

        /// <summary>
        /// Gets or Sets if the Children-Tabs can be reorganized by dragging.
        /// </summary>
        public bool ReorderableTabs
        {
            get => GetValue(ReorderableTabsProperty);
            set => SetValue(ReorderableTabsProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="ReorderableTabs"/> property.
        /// </summary>
        public readonly static StyledProperty<bool> ReorderableTabsProperty =
            AvaloniaProperty.Register<AuraTabView, bool>(nameof(ReorderableTabs), true);

        /// <summary>
        /// Gets or sets if the DraggableTabsChildren can be dragged Immediate or on PointerReleased only.
        /// </summary>
        public bool ImmediateDrag
        {
            get => GetValue(ImmediateDragProperty);
            set => SetValue(ImmediateDragProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="ImmediateDrag"/> property.
        /// </summary>
        public static readonly StyledProperty<bool> ImmediateDragProperty =
            AvaloniaProperty.Register<AuraTabView, bool>(nameof(ImmediateDrag), true);
    }
}