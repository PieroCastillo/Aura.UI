using System;
using Avalonia;
using Avalonia.Controls;

namespace Aura.UI.Controls
{
    public partial class ControlDesigner
    {
        public double SkewAngleX
        {
            get => GetValue(SkewAngleXProperty);
            set => SetValue(SkewAngleXProperty, value);
        }

        public static readonly StyledProperty<double> SkewAngleXProperty =
            AvaloniaProperty.Register<ControlDesigner, double>(nameof(SkewAngleX), 0);

        public double SkewAngleY
        {
            get => GetValue(SkewAngleYProperty);
            set => SetValue(SkewAngleYProperty, value);
        }

        public static readonly StyledProperty<double> SkewAngleYProperty =
            AvaloniaProperty.Register<ControlDesigner, double>(nameof(SkewAngleY), 0);

        public double RotationAngle
        {
            get => GetValue(RotationAngleProperty);
            set => SetValue(RotationAngleProperty, value);
        }

        public static readonly StyledProperty<double> RotationAngleProperty =
            AvaloniaProperty.Register<ControlDesigner, double>(nameof(RotationAngle), 0);

        private Control _controltodesign = new Control();
        
        public Control ControlToDesign
        {
            get => _controltodesign;
            set => SetAndRaise(ControlToDesignProperty, ref _controltodesign, value);
        }

        public static readonly DirectProperty<ControlDesigner, Control> ControlToDesignProperty =
            AvaloniaProperty.RegisterDirect<ControlDesigner, Control>(
                nameof(ControlToDesign),
                o => o.ControlToDesign,
                (o, v) => o.ControlToDesign = v);

        public EditMode EditMode
        {
            get => GetValue(EditModeProperty);
            set => SetValue(EditModeProperty, value);
        }

        public readonly static StyledProperty<EditMode> EditModeProperty =
            AvaloniaProperty.Register<ControlDesigner, EditMode>(nameof(EditMode), EditMode.None);
    }

    public enum EditMode
    {
        None,
        Resize,
        Rotate
    }
}