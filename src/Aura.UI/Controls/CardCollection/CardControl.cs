using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;
using System;
using System.Linq;
using System.Windows.Input;

namespace Aura.UI.Controls
{
    public partial class CardControl : HeaderedContentControl, ICommandSource
    {
        private bool _commandCanExecute = false;

        static CardControl()
        {
            CommandProperty.Changed.Subscribe(CommandChanged);
            CommandParameterProperty.Changed.Subscribe(CommandParameterChanged);
            ClickModeProperty.OverrideDefaultValue<CardControl>(ClickMode.Release);
        }

        public CardControl()
        {

        }

        static void CommandChanged(AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Sender is CardControl c)
            {
                if (((ILogical)c).IsAttachedToLogicalTree)
                {
                    if (e.OldValue is ICommand oldCommand)
                    {
                        oldCommand.CanExecuteChanged -= c.CanExecuteChanged;
                    }

                    if (e.NewValue is ICommand newCommand)
                    {
                        newCommand.CanExecuteChanged += c.CanExecuteChanged;
                    }
                }

                c.CanExecuteChanged(c, EventArgs.Empty);
            }
        }

        static void CommandParameterChanged(AvaloniaPropertyChangedEventArgs<object> e)
        {
            if (e.Sender is CardControl c)
            {
                c.CanExecuteChanged(c, EventArgs.Empty);
            }
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed &&
                ClickMode == ClickMode.Press)
            {
                OnClick();
            }
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);

            if (e.InitialPressMouseButton == MouseButton.Left &&
                ClickMode == ClickMode.Release &&
                this.GetVisualsAt(e.GetPosition(this)).Any(c => this == c || this.IsVisualAncestorOf(c)))
            {
                OnClick();
            }
        }

        void CanExecuteChanged(object sender, EventArgs e)
        {
            var canExecute = Command == null || Command.CanExecute(CommandParameter);

            if (canExecute != _commandCanExecute)
            {
                _commandCanExecute = canExecute;
                //UpdateIsEffectivelyEnabled();
            }
        }

        protected virtual void OnClick()
        {
            if (Command?.CanExecute(CommandParameter) == true)
            {
                Command.Execute(CommandParameter);
            }
        }

        protected override void UpdateDataValidation(AvaloniaProperty property, BindingValueType state, Exception error)
        {
            base.UpdateDataValidation(property, state, error);

            if (property == CommandProperty)
            {
                if (state == BindingValueType.BindingError)
                {
                    if (_commandCanExecute)
                    {
                        _commandCanExecute = false;
                        //UpdateIsEffectivelyEnabled();
                    }
                }
            }
        }

        void ICommandSource.CanExecuteChanged(object sender, EventArgs e) => CanExecuteChanged(sender, e);
    }
}