using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Lighting
{
    public partial class Shadow
    {
        /// <summary>
        /// Defines if the Shadow are enabled
        /// </summary>
        public static readonly AttachedProperty<bool> EnabledProperty =
            AvaloniaProperty.RegisterAttached<Shadow, WindowBase, bool>(
                "Enabled", false, true, BindingMode.TwoWay);
        public static bool GetEnabled(WindowBase element) 
            => element.GetValue(EnabledProperty);

        public static void SetEnabled(WindowBase element, bool value)
            => element.SetValue(EnabledProperty, value);

        /// <summary>
        /// Defines the Shadow that decorates the control
        /// </summary>
        public static readonly AttachedProperty<BoxShadows> BoxShadowProperty =
            AvaloniaProperty.RegisterAttached<Shadow, Control, BoxShadows>(
                "BoxShadow", Shadows.DefaultShadow, true, BindingMode.TwoWay);

        public static BoxShadows GetBoxShadow(Control element) 
            => element.GetValue(BoxShadowProperty);
        public static void SetBoxShadow(WindowBase element, bool value) 
            => element.SetValue(EnabledProperty, value);

        /// <summary>
        /// Defines the CornerRadius of the Shadow
        /// </summary>
        public static readonly AttachedProperty<CornerRadius> ShadowCornerRadiusProperty =
            AvaloniaProperty.RegisterAttached<Shadow, Control, CornerRadius>(
                "ShadowCornerRadius", new CornerRadius(0), true, BindingMode.TwoWay);

        public static CornerRadius GetShadowCornerRadius(Control element)
            => element.GetValue(ShadowCornerRadiusProperty);
        public static void SetShadowCornerRadius(Control element, CornerRadius value)
            => element.SetValue(ShadowCornerRadiusProperty, value);

        public static readonly AttachedProperty<Border> CurrentProperty =
            AvaloniaProperty.RegisterAttached<Shadow, Control, Border>("Current");

        public static Border GetCurrent(Control element)
            => element.GetValue(CurrentProperty);
        public static void SetCurrent(Control element, Border value)
            => element.SetValue(CurrentProperty, value);
    }
}
