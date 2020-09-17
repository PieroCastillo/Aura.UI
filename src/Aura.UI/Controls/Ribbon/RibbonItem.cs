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
    [TemplatePart(Name = "PART_ButtonContainer", Type = typeof(Button))]
    public class RibbonItem : TabItem, IMaterial
    {
        Button btn_cont;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            btn_cont = this.GetControl<Button>(e, "PART_ButtonContainer");
            btn_cont.Click += Btn_cont_Click;
            btn_cont.Click += Btn_cont_Click;
        }

        private void Btn_cont_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if(this.IsSelected != false)
            {
                this.ToggleRibbonRootState();
                e.Handled = true;
            }
            else
            {
                this.IsSelected = true;
            }
        }

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
