using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;

namespace Aura.UI.Controls.Thumbs
{
    public class RotateThumb : Thumb
    {
        protected override void OnDragDelta(VectorEventArgs e)
        {
            base.OnDragDelta(e);

            var last_ = AngleValue;
            AngleValue = AngleValue + e.Vector.Length;
        }

        private double _anglevalue = 0;
        /// <summary>
        /// Gets or Sets the angle value
        /// </summary>
        public double AngleValue
        {
            get => _anglevalue;
            set => SetAndRaise(AngleValueProperty, ref _anglevalue, value);
        }

        public readonly static DirectProperty<RotateThumb, double> AngleValueProperty =
            AvaloniaProperty.RegisterDirect<RotateThumb, double>(
                nameof(AngleValue),
                o => o.AngleValue,
                (o, v) => o.AngleValue = v);
    }
}