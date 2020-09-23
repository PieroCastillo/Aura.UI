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
    public class ModernSlider : FilledSlider, ICustomCornerRadius
    {
        ExperimentalAcrylicBorder leftborder;
        ExperimentalAcrylicBorder rightborder;
        public ModernSlider()
        {
            this.InitializeComponent();
        }
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            leftborder = this.GetControl<ExperimentalAcrylicBorder>(e, "PART_Br_Left");
            rightborder = this.GetControl<ExperimentalAcrylicBorder>(e, "PART_Br_Right");

            this.PropertyChanged += ModernSlider_PropertyChanged;
        }

        private void ModernSlider_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
                UpdateBorder();
        }

        internal void UpdateBorder()
        {
            switch (Orientation)
            {
                case Orientation.Horizontal:
                {
                      leftborder.CornerRadius = new CornerRadius(CornerRadius.TopLeft, 0, 0, CornerRadius.BottomLeft);
                      rightborder.CornerRadius = new CornerRadius(0 , CornerRadius.TopRight, CornerRadius.BottomRight, 0);
                      break;
                }
                case Orientation.Vertical:
                {
                        leftborder.CornerRadius = new CornerRadius(CornerRadius.TopLeft, CornerRadius.TopRight, 0, 0);
                        rightborder.CornerRadius = new CornerRadius(0, 0, CornerRadius.BottomRight, CornerRadius.BottomLeft);
                        break;
                }
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Defines the CornerRadius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<MaterialButton, CornerRadius>(nameof(CornerRadius), new CornerRadius(7));
    }
}
