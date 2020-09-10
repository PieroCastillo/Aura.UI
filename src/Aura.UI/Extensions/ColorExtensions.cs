using Aura.UI.Helpers;
using Avalonia.Media;
using ColorPicker.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Extensions
{
    public static class ColorExtensions
    {
       public static HSLStruct ToHSV(this Color color)
        {
            return new HSLStruct(color);
        }
    }
}
