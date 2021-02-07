using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace Aura.UI.Controls.Ribbon
{
    /// <summary>
    /// Defines a Item for the <see cref="Ribbon"/>
    /// </summary>
    [TemplatePart(Name = "PART_ButtonContainer", Type = typeof(Button))]
    public class RibbonItem : TabItem, IMaterial
    {
        private Button btn_cont;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            btn_cont = this.GetControl<Button>(e, "PART_ButtonContainer");
            btn_cont.Click += Btn_cont_Click;
        }

        private void Btn_cont_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (IsSelected != false)
            {
                this.ToggleRibbonRootState();
            }
            else
            {
                IsSelected = true;
            }
        }

        /// <summary>
        /// Defines the Material for the AcrylicBorder in the Template
        /// </summary>
        public ExperimentalAcrylicMaterial Material
        {
            get => GetValue(MaterialProperty);
            set => SetValue(MaterialProperty, value);
        }

        public static readonly StyledProperty<ExperimentalAcrylicMaterial> MaterialProperty =
            AvaloniaProperty.Register<RibbonItem, ExperimentalAcrylicMaterial>(nameof(Material),
                new ExperimentalAcrylicMaterial()
                {
                    TintColor = Colors.Black,
                    MaterialOpacity = 1,
                    TintOpacity = 0.85
                });

        /// <summary>
        /// Defines if the Material can be visible
        /// </summary>
        public bool MaterialIsVisible
        {
            get => GetValue(MaterialIsVisibleProperty);
            set => SetValue(MaterialIsVisibleProperty, value);
        }

        public static readonly StyledProperty<bool> MaterialIsVisibleProperty =
             AvaloniaProperty.Register<RibbonItem, bool>(nameof(MaterialIsVisible), true);
    }
}