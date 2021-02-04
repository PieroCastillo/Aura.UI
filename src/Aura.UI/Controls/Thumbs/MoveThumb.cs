using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using System;

namespace Aura.UI.Controls.Thumbs
{
    /// <summary>
    /// Moves a control within a Canvas
    /// </summary>
    public class MoveThumb : Thumb
    {
        private Control _controltomove = new Control();

        /// <summary>
        /// The Control to Move
        /// </summary>
        public Control ControlToMove
        {
            get => _controltomove;
            set => SetAndRaise(ControlToMoveProperty, ref _controltomove, value);
        }

        public readonly static DirectProperty<MoveThumb, Control> ControlToMoveProperty =
            AvaloniaProperty.RegisterDirect<MoveThumb, Control>(
                nameof(ControlToMove),
                o => o.ControlToMove,
                (o, v) => o.ControlToMove = v);

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            e.Handled = false;
        }

        protected override void OnDragDelta(VectorEventArgs e)
        {
            base.OnDragDelta(e);

            if (ControlToMove != null)
            {
                double delta_v, delta_h;
                delta_v = Math.Min(e.Vector.Y, ControlToMove.Bounds.Height - ControlToMove.MinHeight);
                Canvas.SetTop(ControlToMove, Canvas.GetTop(ControlToMove) + delta_v);
                delta_h = Math.Min(e.Vector.X, ControlToMove.Bounds.Width + ControlToMove.MinWidth);
                Canvas.SetLeft(ControlToMove, Canvas.GetLeft(ControlToMove) + delta_h);
            }
        }
    }
}