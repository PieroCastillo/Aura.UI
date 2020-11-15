using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace Aura.UI.Controls
{
    public class RotatorDecorator : TemplatedControl
    {
        
        
        /// <summary>
        /// The angle in degrees of the control
        /// </summary>
        public double Angle
        {
            get => GetValue(AngleProperty);
            set => SetValue(AngleProperty, value);
        }

        public static readonly StyledProperty<double> AngleProperty =
            AvaloniaProperty.Register<RotatorDecorator,double>(nameof(Angle), 0);

        private Control _itemtorotate = new Control();
        public Control ItemToRotate
        {
            get => _itemtorotate;
            set => SetAndRaise(ItemToRotateProperty, ref _itemtorotate, value);
        }

        public static readonly DirectProperty<RotatorDecorator, Control> ItemToRotateProperty =
            AvaloniaProperty.RegisterDirect<RotatorDecorator, Control>(
                nameof(ItemToRotateProperty),
                o => o.ItemToRotate,
                (o, v) => o.ItemToRotate = v);
        
        private double _skewx = 0;
        /// <summary>
        /// Gets or Sets the Skew X angle
        /// </summary>
        public double SkewX
        {
            get => _skewx;
            set => SetAndRaise(SkewXProperty, ref _skewx, value);
        }

        public readonly static DirectProperty<RotatorDecorator, double> SkewXProperty =
            AvaloniaProperty.RegisterDirect<RotatorDecorator, double>(
                nameof(SkewX),
                o => o.SkewX,
                (o, v) => o.SkewX = v,
                0);
        
        private double _skewy = 0;
        /// <summary>
        /// Gets or Sets the Skew X angle
        /// </summary>
        public double SkewY
        {
            get => _skewy;
            set => SetAndRaise(SkewYProperty, ref _skewy, value);
        }

        public readonly static DirectProperty<RotatorDecorator, double> SkewYProperty =
            AvaloniaProperty.RegisterDirect<RotatorDecorator, double>(
                nameof(SkewY),
                o => o.SkewY,
                (o, v) => o.SkewY = v,
                0);

        public bool IsVisibleDecorations
        {
            get => GetValue(IsVisibleDecorationsProperty);
            set => SetValue(IsVisibleDecorationsProperty, value);
        }

        public static readonly StyledProperty<bool> IsVisibleDecorationsProperty =
            AvaloniaProperty.Register<RotatorDecorator, bool>(nameof(IsVisibleDecorations), true);

    }
}