using Aura.UI.Controls.Primitives;
using Avalonia.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Collections
{
    /// <summary>
    /// It's a collection of <see cref="SelectableThumb{TCustomValue}"/>
    /// </summary>
    /// <typeparam name="TCustomValue"></typeparam>
    public class SelectableThumbs<TCustomValue> : AvaloniaList<SelectableThumb<TCustomValue>>
    {
    }
}
