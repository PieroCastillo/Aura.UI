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

        private Color _selectedColor;
        /// <summary>
        /// Return the Selected Color of the ColorPicker
        /// </summary>
        public Color SelectedColor
        {
            get => _selectedColor;
            set => SetAndRaise(SelectedColorProperty, ref _selectedColor, value);
        }
        public static readonly DirectProperty<SuperColorPicker, Color> SelectedColorProperty =
            AvaloniaProperty.RegisterDirect<SuperColorPicker, Color>(
                nameof(SelectedColor),
                o => o.SelectedColor,
                unsetValue: Colors.White);

        private double _red;
        public double Red
        {
            get => _red;
            set => SetAndRaise(RedProperty, ref _red, value);
        }
        public readonly static DirectProperty<SuperColorPicker, double> RedProperty =
            AvaloniaProperty.RegisterDirect<SuperColorPicker, double>(
                nameof(Red),
                o => o.Red,
                (o, v) => o.Red = v, 255);


        private double _green;
        public double Green
        {
            get => _green;
            set => SetAndRaise(GreenProperty, ref _green, value);
        }
        public readonly static DirectProperty<SuperColorPicker, double> GreenProperty =
            AvaloniaProperty.RegisterDirect<SuperColorPicker, double>(
                nameof(Green),
                o => o.Green,
                (o, v) => o.Green = v, 255);


        private double _blue;
        public double Blue
        {
            get => _blue;
            set => SetAndRaise(BlueProperty, ref _red, value);
        }
        public readonly static DirectProperty<SuperColorPicker, double> BlueProperty =
            AvaloniaProperty.RegisterDirect<SuperColorPicker, double>(
                nameof(Blue),
                o => o.Blue,
                (o, v) => o.Blue = v, 255);
        private double _alpha;
        public double Alpha
        {
            get => _alpha;
            set => SetAndRaise(AlphaProperty, ref _red, value);
        }
        public readonly static DirectProperty<SuperColorPicker, double> AlphaProperty =
            AvaloniaProperty.RegisterDirect<SuperColorPicker, double>(
                nameof(Alpha),
                o => o.Alpha,
                (o, v) => o.Alpha = v, 255);
    }
}
