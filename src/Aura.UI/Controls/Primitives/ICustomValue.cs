using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Primitives
{
    public interface ICustomValueControl<TCustomValue> : IControl
    {
        public TCustomValue Value { get; set; } 
    }
}
