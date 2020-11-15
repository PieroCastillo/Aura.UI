using Aura.UI.Controls.Primitives;
using Avalonia;
using Avalonia.Controls;
using JetBrains.Annotations;

namespace Aura.UI.Controls
{
    public partial class DesignerCanvas
    {
        private IDesignable _indesigncontrol;
        
        [CanBeNull]
        public IDesignable InDesignControl
        {
            get => _indesigncontrol;
            set => SetAndRaise(InDesignControlProperty, ref _indesigncontrol, value);
        }

        public static readonly DirectProperty<DesignerCanvas, IDesignable> InDesignControlProperty =
            AvaloniaProperty.RegisterDirect<DesignerCanvas, IDesignable>(
                nameof(InDesignControl),
                o => o.InDesignControl,
                (o, v) => o.InDesignControl = v);
    }
}