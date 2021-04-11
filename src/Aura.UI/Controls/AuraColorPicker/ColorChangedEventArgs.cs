using Aura.UI.Extensions;
using Aura.UI.Helpers;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public class ColorChangedEventArgs : RoutedEventArgs
    {
        public ColorChangedEventArgs(Color prevColor, Color oldColor, Color newColor, UpdatedColorReason reason)
        {
            PreviewColor = prevColor;
            OldColor = oldColor;
            NewColor = newColor;
            NewColorAsHSV = new HSVStruct(newColor);
            Reason = reason;
        }

        public Color PreviewColor { get; }
        public Color OldColor { get; }
        public Color NewColor { get; }

        public HSVStruct NewColorAsHSV { get; }
        public UpdatedColorReason Reason { get; }
    }

    public enum UpdatedColorReason
    {
        ValueChanged,
        HueAndSaturationChanged,
        AlphaChanged,
        ColorStringChanged,
        RChanged,
        GChanged,
        BChanged,
        AChanged,
        HexChanged,
    }
}
