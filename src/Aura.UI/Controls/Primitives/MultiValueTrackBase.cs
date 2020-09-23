using Aura.UI.Attributes;
using Aura.UI.Collections;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Primitives
{
    [Primitive]
    public class MultiValueTrackBase<TCustomValue> : Control, ICustomValueControl<TCustomValue>
    {
        public TCustomValue Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly StyledProperty<TCustomValue> ValueProperty =
            AvaloniaProperty.Register<MultiValueTrackBase<TCustomValue>, TCustomValue>(nameof(Value));

        public SelectableThumbs<TCustomValue> SelectableThumbs
        {
            get { return GetValue(SelectableThumbsProperty); }
            set { SetValue(SelectableThumbsProperty, value); }
        }
        public static readonly StyledProperty<SelectableThumbs<TCustomValue>> SelectableThumbsProperty =
            AvaloniaProperty.Register<MultiValueTrackBase<TCustomValue>, SelectableThumbs<TCustomValue>>(nameof(SelectableThumbs));
        
        public double MaximumPosition
        {
            get { return GetValue(MaximumPositionProperty); }
            set { SetValue(MaximumPositionProperty, value); }
        }
        public readonly static StyledProperty<double> MaximumPositionProperty =
            AvaloniaProperty.Register<MultiValueTrackBase<TCustomValue>, double>(nameof(MaximumPosition));
    }
}
