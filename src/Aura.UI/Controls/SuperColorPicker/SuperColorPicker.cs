using Aura.UI.Attributes;
using Aura.UI.Controls.Indicators;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using ColorPicker;

namespace Aura.UI.Controls
{
    /// <summary>
    /// This control shows a color picker with RGB, HSL and Hex Indicators
    /// </summary>
    [TemplatePart(Name = "PART_ColorWheel", Type = typeof(ColorWheel))]
    [TemplatePart(Name = "PART_HSL", Type = typeof(HSLIndicator))]
    [TemplatePart(Name = "PART_RGB", Type = typeof(RGBIndicator))]
    [TemplatePart(Name = "PART_HEXText", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_SliderAlpha", Type = typeof(Slider))]
    [TemplatePart(Name = "PART_SliderDarkness", Type = typeof(Slider))]
    [TemplatePart(Name = "PART_Preview", Type = typeof(Border))]
    public partial class SuperColorPicker : TemplatedControl
    {
        ColorWheel color_W;
        Slider AlphaSL;
        Slider DarknessSL;
        

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            color_W = this.GetControl<ColorWheel>(e, "PART_ColorWheel");
            AlphaSL = this.GetControl<Slider>(e, "PART_SliderAlpha");
            DarknessSL = this.GetControl<Slider>(e, "PART_SliderDarkness");

            //color_W.PreviewColor = PreviewColor;

            color_W.PreviewColor = PreviewColor;

            //sets the cursor
            color_W.PointerMoved += (s, e) =>
            {
                color_W.Cursor = new Cursor(StandardCursorType.Cross);
            };
        }

        private Color _previewcolor;
        public Color PreviewColor
        {
            get => _previewcolor;
            set => SetAndRaise(PreviewColorProperty, ref _previewcolor, value);
        }
        public readonly static DirectProperty<SuperColorPicker, Color> PreviewColorProperty = 
            AvaloniaProperty.RegisterDirect<SuperColorPicker, Color>(
                nameof(PreviewColor),
                o => o.PreviewColor,
                (o,v) => o.PreviewColor = v, Colors.White);
    }
}
