using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Xaml
{
    public class AcrylicMaterialExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ExperimentalAcrylicMaterial 
            { 
                TintColor = TintColor,
                FallbackColor = FallBackColor,
                TintOpacity = TintOpacity,
                MaterialOpacity = MaterialOpacity
                
            };
        }
        public Color TintColor { get; set; }
        public Color FallBackColor { get; set; }
        public double TintOpacity { get; set; }
        public double MaterialOpacity { get; set; }
    }
}
