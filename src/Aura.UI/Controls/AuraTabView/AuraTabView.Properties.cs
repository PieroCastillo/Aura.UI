using Avalonia;
using Avalonia.Layout;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Styling;

namespace Aura.UI.Controls
{
    public partial class AuraTabView
    {
        object _fallbackcontent = new TextBlock { Text = "Nothing here",
                                                  HorizontalAlignment = HorizontalAlignment.Center,
                                                  VerticalAlignment = VerticalAlignment.Center, FontSize = 16};
        /// <summary>
        /// This content is showed when there is not item.
        /// </summary>
        public object FallBackContent
        {
            get => _fallbackcontent;
            set => SetAndRaise(FallBackContentProperty, ref _fallbackcontent, value);
        }
        public static readonly DirectProperty<AuraTabView, object> FallBackContentProperty =
            AvaloniaProperty.RegisterDirect<AuraTabView, object>
            (nameof(FallBackContent),
             o => o.FallBackContent,
             (o, v) => o.FallBackContent = v);

        /// <summary>
        /// Defines the Header
        /// </summary>
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
        public static readonly StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<AuraTabView, object>(nameof(Header));

        /// <summary>
        /// Defines the Header Template
        /// </summary>
        public ITemplate HeaderTemplate
        {
            get => GetValue(HeaderTemplateProperty);
            set => SetValue(HeaderTemplateProperty, value);
        }
        public static readonly StyledProperty<ITemplate> HeaderTemplateProperty =
            AvaloniaProperty.Register<AuraTabView, ITemplate>(nameof(HeaderTemplate));
/// <summary>
/// Defines the Footer
/// </summary>
        public object Footer
        {
            get => GetValue(FooterProperty);
            set => SetValue(FooterProperty, value);
        }
        public static readonly StyledProperty<object> FooterProperty =
            AvaloniaProperty.Register<AuraTabView, object>(nameof(Footer));
/// <summary>
/// Defines the Footer Template
/// </summary>
        public ITemplate FooterTemplate
        {
            get => GetValue(FooterTemplateProperty);
            set => SetValue(FooterTemplateProperty, value);
        }
        public static readonly StyledProperty<ITemplate> FooterTemplateProperty =
            AvaloniaProperty.Register<AuraTabView, ITemplate>(nameof(FooterTemplateProperty));
        
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
        public double MaxWidthOfItemsPresenter
        {
            get { return GetValue(MaxWidthOfItemsPresenterProperty); }
            set { SetValue(MaxWidthOfItemsPresenterProperty, value); }
        }
        public readonly static StyledProperty<double> MaxWidthOfItemsPresenterProperty =
            AvaloniaProperty.Register<AuraTabView, double>(nameof(MaxWidthOfItemsPresenter), double.PositiveInfinity);
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

        private double _heightremainingspace;
        /// <summary>
        /// Gets the space that remains in the top
        /// </summary>
        public double HeightRemainingSpace
        {
            get => _heightremainingspace;
            private set => SetAndRaise(HeightRemainingSpaceProperty, ref _heightremainingspace, value);
        }
        public readonly static DirectProperty<AuraTabView, double> HeightRemainingSpaceProperty =
            AvaloniaProperty.RegisterDirect<AuraTabView, double>(
                nameof(HeightRemainingSpace),
                o => o.HeightRemainingSpace);

        private double _widthremainingspace;
        /// <summary>
        /// Gets the space that remains in the top
        /// </summary>
        public double WidthRemainingSpace
        {
            get => _widthremainingspace;
            private set => SetAndRaise(WidthRemainingSpaceProperty, ref _widthremainingspace, value);
        }
        public readonly static DirectProperty<AuraTabView, double> WidthRemainingSpaceProperty =
            AvaloniaProperty.RegisterDirect<AuraTabView, double>(
                nameof(WidthRemainingSpace),
                o => o.WidthRemainingSpace);

        public bool ReorderableTabs
        {
            get => GetValue(ReorderableTabsProperty);
            set => SetValue(ReorderableTabsProperty, value);
        }

        public readonly static StyledProperty<bool> ReorderableTabsProperty =
            AvaloniaProperty.Register<AuraTabView, bool>(nameof(ReorderableTabs), true);
    }
}
