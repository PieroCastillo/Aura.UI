using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
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
        public ExpansionState ExpansionState
        {
            get { return GetValue(ExpansionStateProperty); }
            set { SetValue(ExpansionStateProperty, value); }
        }
        public static readonly StyledProperty<ExpansionState> ExpansionStateProperty =
            AvaloniaProperty.Register<NavigationViewItem, ExpansionState>(nameof(ExpansionState), ExpansionState.Total);

        public IImage Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        public static readonly StyledProperty<IImage> IconProperty =
            AvaloniaProperty.Register<NavigationViewItem, IImage>(nameof(Icon));

    }
}