using Aura.UI.Attributes;
using Aura.UI.Controls.Indicators;
using Aura.UI.Helpers;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using ColorPicker;
using System.Xml.Linq;

namespace Aura.UI.Controls
{
    /// <summary>
    /// This control shows a color picker with RGB, HSL and Hex Indicators
    /// </summary>
    [TemplatePart(Name = "PART_ColorWheel", Type = typeof(ColorWheel))]
    [TemplatePart(Name = "PART_HSL", Type = typeof(HSLIndicator))]
    [TemplatePart(Name = "PART_RGB", Type = typeof(RGBIndicator))]
    [TemplatePart(Name = "PART_HEXText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_SliderAlpha", Type = typeof(Slider))]
    [TemplatePart(Name = "PART_SliderDarkness", Type = typeof(Slider))]
    [TemplatePart(Name = "PART_Preview", Type = typeof(Border))]
    public class SuperColorPicker : TemplatedControl
    {
        ColorWheel color_W;
        HSLIndicator hSL;
        RGBIndicator rGB;
        TextBlock hextext;
        Slider AlphaSL;
        Slider DarknessSL;
        Border PreviewBorder;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            color_W = this.GetControl<ColorWheel>(e, "PART_ColorWheel");
            hSL = this.GetControl<HSLIndicator>(e, "PART_HSL");
            rGB = this.GetControl<RGBIndicator>(e, "PART_RGB");
            hextext = this.GetControl<TextBlock>(e, "PART_HEXText");
            AlphaSL = this.GetControl<Slider>(e, "PART_SliderAlpha");
            DarknessSL = this.GetControl<Slider>(e, "PART_SliderDarkness");
            PreviewBorder = this.GetControl<Border>(e, "PART_Preview");

            color_W.SelectedColor = new ColorPicker.Structures.RGBColor(255,255,255);
         
            color_W.PropertyChanged += SuperColorPicker_PropertyChanged;
            AlphaSL.PropertyChanged += SuperColorPicker_PropertyChanged;
            DarknessSL.PropertyChanged += SuperColorPicker_PropertyChanged;
        }

        private void SuperColorPicker_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            var _old = color_W.SelectedColor;
            byte a_ = (byte)(AlphaSL.Value * 255);
            double lightness_ = DarknessSL.Value;

            var rgb_S = RGBStruct.ApplyLightnessToRGB(new RGBStruct(_old), lightness_);
            var color_ = new Color(a_, rgb_S.r, rgb_S.g, rgb_S.b);

            SelectedColor = color_ ; 
            hSL.ColorToShow = color_;
            rGB.ColorToShow = color_;
            hextext.Text = color_.ToString();
            PreviewBorder.Background = new SolidColorBrush(color_);
             
        }
        /// <summary>
        /// The orientation of the supercolorpicker
        /// </summary>
        public Orientation Orientation
        {
            get => GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
        public static readonly StyledProperty<Orientation> OrientationProperty =
            AvaloniaProperty.Register<SuperColorPicker, Orientation>(nameof(Orientation), Orientation.Horizontal);

        /// <summary>
        /// Defines the CornerRadius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<MaterialButton, CornerRadius>(nameof(CornerRadius));

        /// <summary>
        /// Return the Selected Color of the ColorPicker
        /// </summary>
        public Color SelectedColor
        {
            get { return GetValue(SelectedColorProperty); }
            private set { SetValue(SelectedColorProperty, value); }
        }
        public static readonly StyledProperty<Color> SelectedColorProperty =
            AvaloniaProperty.Register<SuperColorPicker, Color>(nameof(SelectedColor), Colors.White);
    }
}
