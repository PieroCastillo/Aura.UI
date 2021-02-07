﻿using Avalonia;

namespace Aura.UI.Controls
{
    public partial class ModernSlider
    {
        /// <summary>
        /// Defines the CornerRadius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get => GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<MaterialButton, CornerRadius>(nameof(CornerRadius), new CornerRadius(7));
    }
}