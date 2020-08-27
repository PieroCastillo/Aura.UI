using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Aura.UI.Controls.Primitives
{
    public interface IClickable
    {
        public ClickMode ClickMode { get; set; }
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }
        public bool IsPressed { get; }
        public event EventHandler<RoutedEventArgs> Click;
    }
}
