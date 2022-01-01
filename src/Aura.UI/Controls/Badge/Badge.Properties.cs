using Avalonia;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class Badge
    {
        private VerticalAlignment _BadgeVerticalAlignment;
        private HorizontalAlignment _BadgeHorizontalAlignment;
        private Thickness _BadgeThickness;

        public static readonly StyledProperty<object> BadgeContentProperty =
            AvaloniaProperty.Register<Badge, object>(nameof(BadgeContent));
        public static readonly StyledProperty<IDataTemplate> BadgeContentTemplateProperty =
            AvaloniaProperty.Register<Badge, IDataTemplate>(nameof(BadgeContentTemplate));
        public static readonly StyledProperty<BadgePosition> BadgePositionProperty =
            AvaloniaProperty.Register<Badge, BadgePosition>(nameof(BadgePosition));
        public static readonly DirectProperty<Badge, VerticalAlignment> BadgeVerticalAlignmentProperty =
            AvaloniaProperty.RegisterDirect<Badge, VerticalAlignment>(nameof(BadgeVerticalAlignment), o => o.BadgeVerticalAlignment);
        public static readonly DirectProperty<Badge, HorizontalAlignment> BadgeHorizontalAlignmentProperty =
            AvaloniaProperty.RegisterDirect<Badge, HorizontalAlignment>(nameof(BadgeHorizontalAlignment), o => o.BadgeHorizontalAlignment);
        public static readonly DirectProperty<Badge, Thickness> BadgeThicknessProperty =
            AvaloniaProperty.RegisterDirect<Badge, Thickness>(nameof(BadgeThickness), o => o.BadgeThickness);

        public object BadgeContent
        {
            get => GetValue(BadgeContentProperty);
            set => SetValue(BadgeContentProperty, value);
        }
        public IDataTemplate BadgeContentTemplate
        {
            get => GetValue(BadgeContentTemplateProperty);
            set => SetValue(BadgeContentTemplateProperty, value);
        }
        public BadgePosition BadgePosition
        {
            get => GetValue(BadgePositionProperty);
            set => SetValue(BadgePositionProperty, value);
        }
        public VerticalAlignment BadgeVerticalAlignment
        {
            get => _BadgeVerticalAlignment;
            private set => SetAndRaise(BadgeVerticalAlignmentProperty, ref _BadgeVerticalAlignment, value);
        }
        public HorizontalAlignment BadgeHorizontalAlignment
        {
            get => _BadgeHorizontalAlignment;
            private set => SetAndRaise(BadgeHorizontalAlignmentProperty, ref _BadgeHorizontalAlignment, value);
        }
        public Thickness BadgeThickness
        {
            get => _BadgeThickness;
            set => SetAndRaise(BadgeThicknessProperty, ref _BadgeThickness, value);
        }
    }
}
