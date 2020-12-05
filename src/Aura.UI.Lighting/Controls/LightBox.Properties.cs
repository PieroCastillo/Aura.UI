using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

namespace Aura.UI.Lighting.Controls
{
    public partial class LightBox
    {
        public static readonly AttachedProperty<CornerRadius> LightCornerRadiusProperty =
                AvaloniaProperty.RegisterAttached<LightBox, Control, CornerRadius>("LightCornerRadius", new CornerRadius(0));

        public static CornerRadius GetLightCornerRadius(Control control)
        {
            return control.GetValue(LightCornerRadiusProperty);
        }

        public static void SetLightCornerRadius(Control control, CornerRadius value)
        {
            control.SetValue(LightCornerRadiusProperty, value);
        }

        /// <summary>
        /// Gets or Sets the Light Height
        /// </summary>
        public double LightHeight
        {
            get => GetValue(LightHeightProperty);
            set => SetValue(LightHeightProperty, value);
        }
        public static readonly StyledProperty<double> LightHeightProperty =
            AvaloniaProperty.Register<LightBox, double>(nameof(LightHeight), 5);
        public LightPoint LightPoint
        {
            get => GetValue(LightPointProperty);
            set => SetValue(LightPointProperty, value);
        }

        public static readonly StyledProperty<LightPoint> LightPointProperty =
            AvaloniaProperty.Register<LightBox, LightPoint>(nameof(LightPoint), new LightPoint(LightDefaultPositions.Center));
    }

    
}