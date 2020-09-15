using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Ribbon
{
    public class RibbonPanel : StackPanel
    {
        public RibbonPanel()
        {
            Spacing = 10;
            Orientation = Avalonia.Layout.Orientation.Horizontal;
        }
    }
}
