using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Avalonia;
using Avalonia.Data;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;
using Avalonia.Media;
using Avalonia.Collections;
using Aura.UI.UIExtensions;

namespace Aura.UI.Controls
{
    public class ColorPickerButtonCollection : ItemsControl 
    {
        IPanel itemspanel_;
        public ColorPickerButtonCollection() : base()
        {
            
        }

        public void AddButton(int index)
        {
            ((IList)this.Items).Insert(index, new ColorPickerButton());
        }

        public void DeleteButton(int index)
        {
            try
            {
                ((IList)this.Items).RemoveAt(index);
            }
            catch(ArgumentNullException e)
            {
                throw new ArgumentNullException("The \"index\" parameter is null", e);
            }
        }


        public Color GetColor(int index)
        {
            return ((ISolidColorBrush)(((IList)this.Items)[index] as ColorPickerButton).Background).Color;
        }

        protected override void ItemsChanged(AvaloniaPropertyChangedEventArgs e)
        {
            base.ItemsChanged(e);
        }

        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            base.OnTemplateApplied(e);

            itemspanel_ = this.GetControl<Panel>(e, "items_panel");
            itemspanel_.Children.CollectionChanged += Children_CollectionChanged;
        }

        private void Children_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #region Properties & events

        private ICommand _command;

        public static readonly StyledProperty<ClickMode> ClickModeProperty =
         AvaloniaProperty.Register<Button, ClickMode>(nameof(ClickMode));

        /// <summary>
        /// Defines the <see cref="Command"/> property.
        /// </summary>
        public static readonly DirectProperty<Button, ICommand> CommandProperty =
            AvaloniaProperty.RegisterDirect<Button, ICommand>(nameof(Command),
                button => button.Command, (button, command) => button.Command = command, enableDataValidation: true);

        /// <summary>
        /// Defines the <see cref="CommandParameter"/> property.
        /// </summary>
        public static readonly StyledProperty<object> CommandParameterProperty =
            AvaloniaProperty.Register<Button, object>(nameof(CommandParameter));

        /// <summary>
        /// Defines the <see cref="Click"/> event.
        /// </summary>
        public static readonly RoutedEvent<RoutedEventArgs> ClickEvent =
            RoutedEvent.Register<Button, RoutedEventArgs>(nameof(Click), RoutingStrategies.Bubble);
        /// <summary>
        /// Raised when the user clicks the button.
        /// </summary>
        public event EventHandler<RoutedEventArgs> Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating how the <see cref="Button"/> should react to clicks.
        /// </summary>
        public ClickMode ClickMode
        {
            get { return GetValue(ClickModeProperty); }
            set { SetValue(ClickModeProperty, value); }
        }

        /// <summary>
        /// Gets or sets an <see cref="ICommand"/> to be invoked when the button is clicked.
        /// </summary>
        public ICommand Command
        {
            get { return _command; }
            set { SetAndRaise(CommandProperty, ref _command, value); }
        }

        /// <summary>
        /// Gets or sets a parameter to be passed to the <see cref="Command"/>.
        /// </summary>
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

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

        
    }
}
