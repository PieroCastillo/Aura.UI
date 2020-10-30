using Avalonia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class AuraTabItem
    {

        /// <summary>
        /// This property defines if the AuraTabItem can be closed
        /// </summary>
        public bool IsClosable
        {
            get { return GetValue(IsClosableProperty); }
            set { SetValue(IsClosableProperty, value); }
        }
        public static readonly StyledProperty<bool> IsClosableProperty =
            AvaloniaProperty.Register<AuraTabItem, bool>(nameof(IsClosable), true);

        /// <summary>
        /// Defines the CornerRadius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<MaterialButton, CornerRadius>(nameof(CornerRadius), new CornerRadius(7));

        //public bool CanBeDragged { get; }
        //public static readonly StyledProperty<bool> CanBeDraggedProperty =
        //    AvaloniaProperty.Register<AuraTabItem, bool>(nameof(CanBeDragged), true);

    }
}
