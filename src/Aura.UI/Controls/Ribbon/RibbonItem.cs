using Aura.UI.Controls.Primitives;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Ribbon
{
    public class RibbonItem : TabItem, IMaterial
    {
        public ExperimentalAcrylicMaterial Material
        {
            get { return GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }
        public static readonly StyledProperty<ExperimentalAcrylicMaterial> MaterialProperty =
            AvaloniaProperty.Register<RibbonItem, ExperimentalAcrylicMaterial>(nameof(Material),
                new ExperimentalAcrylicMaterial()
                {
                    TintColor = Colors.Black,
                    MaterialOpacity = 1,
                    TintOpacity = 0.85
                });

        public bool MaterialIsVisible
        {
            get { return GetValue(MaterialIsVisibleProperty); }
            set { SetValue(MaterialIsVisibleProperty, value); }
        }
        public static readonly StyledProperty<bool> MaterialIsVisibleProperty =
             AvaloniaProperty.Register<RibbonItem, bool>(nameof(MaterialIsVisible), true);
    }
}
