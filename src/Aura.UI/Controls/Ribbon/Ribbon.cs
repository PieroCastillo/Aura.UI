using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Ribbon
{
    [TemplatePart(Name = "PART_RightButton", Type = typeof(MaterialButton))]
    [TemplatePart(Name = "PART_LeftButton", Type = typeof(MaterialButton))]
    public class Ribbon : TabControl, IMaterial, IHeadered
    {
        public MaterialButton LeftButton;
        public MaterialButton RightButton;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            LeftButton = this.GetControl<MaterialButton>(e, "PART_LeftButton");
            RightButton = this.GetControl<MaterialButton>(e, "PART_RightButton");
        }
        public ExperimentalAcrylicMaterial Material
        {
            get { return GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }
        public static readonly StyledProperty<ExperimentalAcrylicMaterial> MaterialProperty =
            AvaloniaProperty.Register<Ribbon, ExperimentalAcrylicMaterial>(nameof(Material),
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
             AvaloniaProperty.Register<Ribbon, bool>(nameof(MaterialIsVisible), true);

        public object LeftContent
        {
            get { return GetValue(LeftContentProperty); }
            set { SetValue(LeftContentProperty, value); }
        }
        public static readonly StyledProperty<object> LeftContentProperty =
             AvaloniaProperty.Register<Ribbon, object>(nameof(LeftContent), "Left");

        public object RightContent
        {
            get { return GetValue(RightContentProperty); }
            set { SetValue(RightContentProperty, value); }
        }
         public static readonly StyledProperty<object> RightContentProperty =
             AvaloniaProperty.Register<Ribbon, object>(nameof(RightContent), "Right");

        public object Header
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public static readonly StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<Ribbon, object>(nameof(Header), "Avalonia.App");
    }
}
