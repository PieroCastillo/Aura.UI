using Avalonia.Controls;

namespace Aura.UI.Controls.Primitives
{
    public interface ICustomValueControl<TCustomValue> : IControl
    {
        public TCustomValue Value { get; set; }
    }
}