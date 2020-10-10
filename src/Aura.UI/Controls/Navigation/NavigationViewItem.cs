using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Media;
using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Navigation
{
    public class NavigationViewItem : TabItem
    {
        /// <summary>
        /// Get or set the expansion state of the NavigationViewItem
        /// </summary>
        public bool IsOpen
        {
            get { return GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }
        public static readonly StyledProperty<bool> IsOpenProperty =
            AvaloniaProperty.Register<NavigationViewItem, bool>(nameof(IsOpen), false);

        //public double CompactLength
        //{
        //    get { return GetValue(CompactLengthProperty); }
        //    set { SetValue(CompactLengthProperty, value); }
        //}
        //public static readonly StyledProperty<double> CompactLengthProperty =
        //    AvaloniaProperty.Register<NavigationViewItem, double>(nameof(CompactLength), 50);
        //public double OpenLength
        //{
        //    get { return GetValue(OpenLengthProperty); }
        //    set { SetValue(OpenLengthProperty, value); }
        //}
        //public static readonly StyledProperty<double> OpenLengthProperty =
        //    AvaloniaProperty.Register<NavigationViewItem, double>(nameof(OpenLength), 150);

        public IImage Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        public static readonly StyledProperty<IImage> IconProperty =
            AvaloniaProperty.Register<NavigationViewItem, IImage>(nameof(Icon));

        public bool IsHeader
        {
            get => GetValue(IsHeaderProperty);
            set => SetValue(IsHeaderProperty, value);
        }
        public static readonly StyledProperty<bool> IsHeaderProperty =
            AvaloniaProperty.Register<NavigationViewItem, bool>(nameof(IsHeader), false);

        public bool ShowToggleButton
        {
            get => GetValue(ShowToggleButtonProperty);
            set => SetValue(ShowToggleButtonProperty, value);
        }
        public static readonly StyledProperty<bool> ShowToggleButtonProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(ShowToggleButton), true);

        public object Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public static readonly StyledProperty<object> TitleProperty =
            AvaloniaProperty.Register<NavigationViewItem, object>(nameof(Title), "Title");

        public ITemplate TitleTemplate
        {
            get => GetValue(TitleTemplateProperty);
            set => SetValue(TitleTemplateProperty, value);
        }
        public static readonly StyledProperty<ITemplate> TitleTemplateProperty =
            AvaloniaProperty.Register<NavigationViewItem, ITemplate>(nameof(TitleTemplate));
    }
}