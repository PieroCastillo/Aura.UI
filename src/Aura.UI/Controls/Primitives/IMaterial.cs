using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Primitives
{
    public interface IMaterial : IAvaloniaObject
    {
        public ExperimentalAcrylicMaterial Material { get; set; }
        public bool MaterialIsVisible { get; set; }
    }
}
