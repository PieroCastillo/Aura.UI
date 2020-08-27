using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;

namespace Aura.UI.Controls.Primitives
{
    public class ClickableControl : TemplatedControl, IClickable
    {
        #region Properties
        public ClickMode ClickMode
        {
            get { return GetValue(ClickModeProperty); }
            set { SetValue(ClickModeProperty, value); }
        }
        public static readonly StyledProperty<ClickMode> ClickModeProperty =
            AvaloniaProperty.Register<ClickableControl, ClickMode>(nameof(ClickMode));
        public ICommand Command
        {
            get { return _command; }
            set { SetAndRaise(CommandProperty, ref _command, value); }
        }
        public static readonly DirectProperty<ClickableControl, ICommand> CommandProperty =
           AvaloniaProperty.RegisterDirect<ClickableControl, ICommand>(nameof(Command),
               clickablecontrol => clickablecontrol.Command, (clickablecontrol, command) => clickablecontrol.Command = command, enableDataValidation: true);
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public static readonly StyledProperty<object> CommandParameterProperty =
          AvaloniaProperty.Register<ClickableControl, object>(nameof(CommandParameter));
        public bool IsPressed
        {
            get { return GetValue(IsPressedProperty); }
            private set { SetValue(IsPressedProperty, value); }
        }
        public static readonly StyledProperty<bool> IsPressedProperty =
           AvaloniaProperty.Register<ClickableControl, bool>(nameof(IsPressed));
        #endregion
        #region Events
        public event EventHandler<RoutedEventArgs> Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }
        public static readonly RoutedEvent<RoutedEventArgs> ClickEvent =
            RoutedEvent.Register<ClickableControl, RoutedEventArgs>(nameof(Click), RoutingStrategies.Bubble);
        #endregion
        #region Fields
        private ICommand _command;
        private bool _commandCanExecute = true;
        #endregion
        protected virtual void OnClick()
        {
            var e = new RoutedEventArgs(ClickEvent);
            RaiseEvent(e);

            if (!e.Handled && Command?.CanExecute(CommandParameter) == true)
            {
                Command.Execute(CommandParameter);
                e.Handled = true;
            }
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            {
                IsPressed = true;
                e.Handled = true;

                if (ClickMode == ClickMode.Press)
                {
                    OnClick();
                }
            }
        }

        /// <inheritdoc/>
        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);

            if (IsPressed && e.InitialPressMouseButton == MouseButton.Left)
            {
                IsPressed = false;
                e.Handled = true;

                if (ClickMode == ClickMode.Release &&
                    this.GetVisualsAt(e.GetPosition(this)).Any(c => this == c || this.IsVisualAncestorOf(c)))
                {
                    OnClick();
                }
            }
        }

        protected override void OnPointerCaptureLost(PointerCaptureLostEventArgs e)
        {
            IsPressed = false;
        }
    }
}
