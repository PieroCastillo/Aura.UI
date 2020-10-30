using Avalonia;
using Avalonia.Layout;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class SuperColorPicker
    {
        /// <summary>
        /// The orientation of the supercolorpicker
        /// </summary>
        public Orientation Orientation
        {
            get => GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
        public static readonly StyledProperty<Orientation> OrientationProperty =
            AvaloniaProperty.Register<SuperColorPicker, Orientation>(nameof(Orientation), Orientation.Horizontal);

        /// <summary>
        /// Defines the CornerRadius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<MaterialButton, CornerRadius>(nameof(CornerRadius), new CornerRadius(0));

        /// <summary>
        /// Return the Selected Color of the ColorPicker
        /// </summary>
        public Color SelectedColor
        {
            get { return GetValue(SelectedColorProperty); }
            private set { SetValue(SelectedColorProperty, value); }
        }
        public static readonly StyledProperty<Color> SelectedColorProperty =
            AvaloniaProperty.Register<SuperColorPicker, Color>(nameof(SelectedColor), Colors.White);
    }
}
