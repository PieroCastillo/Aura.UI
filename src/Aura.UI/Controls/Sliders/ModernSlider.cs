using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Avalonia.Controls;

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