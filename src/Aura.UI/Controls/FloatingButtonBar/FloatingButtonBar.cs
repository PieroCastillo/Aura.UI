using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public class FloatingButtonBar : ItemsControl
    {
        public bool IsExpanded
        {
            get => GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }
        public static readonly StyledProperty<bool> IsExpandedProperty =
            AvaloniaProperty.Register<FloatingButtonBar, bool>(nameof(IsExpanded), false);

        public FloatingButtonBarExpandDirection ExpandDirection
        {
            get => GetValue(ExpandDirectionProperty);
            set => SetValue(ExpandDirectionProperty, value);
        }
        public static readonly StyledProperty<FloatingButtonBarExpandDirection> ExpandDirectionProperty =
            AvaloniaProperty.Register<FloatingButtonBar, FloatingButtonBarExpandDirection>(nameof(ExpandDirection), FloatingButtonBarExpandDirection.ToRight);
    
        public IImage Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        public static readonly StyledProperty<IImage> IconProperty =
            AvaloniaProperty.Register<FloatingButtonBar, IImage>(nameof(Icon));

        public double OpenLength
        {
            get => GetValue(OpenLengthProperty);
            set => SetValue(OpenLengthProperty, value);
        }
        public readonly static StyledProperty<double> OpenLengthProperty =
            AvaloniaProperty.Register<FloatingButtonBar, double>(nameof(OpenLength));
    }

    public enum FloatingButtonBarExpandDirection
    {
        ToLeft,
        ToRight,
        ToTop,
        ToBottom
    }
}
