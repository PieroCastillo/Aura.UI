using System;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace Aura.UI.Controls
{
    public class AuraStudioControl :  HeaderedSelectingItemsControl
    {
        private double _headermaxlength = 0;
        public double HeaderMaxLength
        {
            get => _headermaxlength;
            set => SetAndRaise(HeaderMaxLengthProperty, _headermaxlength, value);
        }

        public readonly static DirectProperty<AuraStudioControl, double> HeaderMaxLengthProperty =
                AvaloniaProperty.RegisterDirect<AuraStudioControl, double>(
                    nameof(HeaderMaxLength),
                    o => o.HeaderMaxLength,
                    (o,v) => o.HeaderMaxLength = v);
    }
}