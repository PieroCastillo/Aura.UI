using Aura.UI.Attributes;
using Avalonia;
using Avalonia.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    [Experimental]
    public class ProgressRing : TemplatedControl
    {
        public int Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        public readonly static StyledProperty<int> ValueProperty =
            AvaloniaProperty.Register<ProgressRing, int>(nameof(Value));

        public bool Undefined
        {
            get => GetValue(UndefinedProperty);
            set => SetValue(UndefinedProperty, value);
        }
        public readonly static StyledProperty<bool> UndefinedProperty =
            AvaloniaProperty.Register<ProgressRing, bool>(nameof(Undefined), true);
    }
}
