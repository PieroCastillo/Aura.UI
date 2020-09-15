using Aura.UI.Controls.Primitives;
using Avalonia;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Ribbon
{
    public class RibbonSeparator : Separator, ICustomCornerRadius
    {
        public CornerRadius CornerRadius
        {
            get { return GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<RibbonSeparator, CornerRadius>(nameof(CornerRadius), new CornerRadius(1));
    }
}
