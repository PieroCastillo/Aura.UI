using Avalonia.Controls;
using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Primitives
{
    public interface IMultiSliderItem : IContentControl
    {
        double UbicationValue { get; set; }
    }
}
