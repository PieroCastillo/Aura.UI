using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Aura.UI.Data
{
    public interface IFloatingButtonTemplate
    {
        public IImage Icon { get; }
        public string ToolTip { get; }
        public ICommand Command { get; }
        public object CommandParameter { get; }
    }
}
