using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Xaml.Interactivity;

namespace Aura.UI.Behaviors
{
    public class CanvasDragBehavior : Behavior<Control>
    {
        private bool _enableDrag;
        private Point _start;
        private Canvas? _canvas;
        private Control? _draggedContainer;
        private Control? _adorner;

        protected override void OnAttached()
        {
            base.OnAttached();

            if (AssociatedObject is { })
            {
                AssociatedObject.AddHandler(InputElement.PointerReleasedEvent, Released, RoutingStrategies.Tunnel);
                AssociatedObject.AddHandler(InputElement.PointerPressedEvent, Pressed, RoutingStrategies.Tunnel);
                AssociatedObject.AddHandler(InputElement.PointerMovedEvent, Moved, RoutingStrategies.Tunnel);
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (AssociatedObject is { })
            {
                AssociatedObject.RemoveHandler(InputElement.PointerReleasedEvent, Released);
                AssociatedObject.RemoveHandler(InputElement.PointerPressedEvent, Pressed);
                AssociatedObject.RemoveHandler(InputElement.PointerMovedEvent, Moved);
            }
        }

        private void AddAdorner(Control control)
        {
            var layer = AdornerLayer.GetAdornerLayer(control);
            if (layer is null)
            {
                return;
            }

            _adorner = new SelectionAdorner()
            {
                [AdornerLayer.AdornedElementProperty] = control
            };

            ((ISetLogicalParent)_adorner).SetParent(control);
            layer.Children.Add(_adorner);
        }

        private void RemoveAdorner(Control control)
        {
            var layer = AdornerLayer.GetAdornerLayer(control);
            if (layer is null || _adorner is null)
            {
                return;
            }

            layer.Children.Remove(_adorner);
            ((ISetLogicalParent)_adorner).SetParent(null);
            _adorner = null;
        }

        private void Pressed(object? sender, PointerPressedEventArgs e)
        {
            if (AssociatedObject?.Parent is not Canvas canvas)
            {
                return;
            }

            _enableDrag = true;
            _start = e.GetPosition(AssociatedObject.Parent);
            _canvas = canvas;
            _draggedContainer = AssociatedObject;

            // AddAdorner(_draggedContainer);
        }

        private void Released(object? sender, PointerReleasedEventArgs e)
        {
            if (_enableDrag)
            {
                if (_canvas is { } && _draggedContainer is { })
                {
                    // RemoveAdorner(_draggedContainer);
                }

                _enableDrag = false;
                _canvas = null;
                _draggedContainer = null;
            }
        }

        private void Moved(object? sender, PointerEventArgs e)
        {
            if (_canvas is null || _draggedContainer is null || !_enableDrag)
            {
                return;
            }

            var position = e.GetPosition(_canvas);
            var deltaX = position.X - _start.X;
            var deltaY = position.Y - _start.Y;
            _start = position;
            var left = Canvas.GetLeft(_draggedContainer);
            var top = Canvas.GetTop(_draggedContainer);
            Canvas.SetLeft(_draggedContainer, left + deltaX);
            Canvas.SetTop(_draggedContainer, top + deltaY);
        }
    }
}