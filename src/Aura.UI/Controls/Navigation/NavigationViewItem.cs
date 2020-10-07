using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Navigation
{
    public class NavigationViewItem : TabItem, IHeadered
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

        public double CompactLength
        {
            get { return GetValue(CompactLengthProperty); }
            set { SetValue(CompactLengthProperty, value); }
        }
        public static readonly StyledProperty<double> CompactLengthProperty =
            AvaloniaProperty.Register<NavigationViewItem, double>(nameof(CompactLength), 50);
        public double OpenLength
        {
            get { return GetValue(OpenLengthProperty); }
            set { SetValue(OpenLengthProperty, value); }
        }
        public static readonly StyledProperty<double> OpenLengthProperty =
            AvaloniaProperty.Register<NavigationViewItem, double>(nameof(OpenLength), 150);

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

        public object Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public static readonly StyledProperty<object> TitleProperty =
            AvaloniaProperty.Register<NavigationViewItem, object>(nameof(Title), "Title");
    }
}