using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;

namespace Aura.UI.Controls
{
    /// <summary>
    /// A <see cref="FilledSlider"/> with acrylicstyles
    /// </summary>
    [TemplatePart(Name = "PART_Br_Left", Type = typeof(ExperimentalAcrylicBorder))]
    [TemplatePart(Name = "PART_Br_Right", Type = typeof(ExperimentalAcrylicBorder))]
    public partial class ModernSlider : FilledSlider, ICustomCornerRadius
    {
        
    }
}
