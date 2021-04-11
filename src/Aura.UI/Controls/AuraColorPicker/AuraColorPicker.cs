using Aura.UI.Controls.Components;
using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class AuraColorPicker : TemplatedControl
    {
        private Slider AlphaSliderVertical, AlphaSlider, RedSlider, BlueSlider, GreenSlider;
        private TextBox AlphaTextBox, RedTextBox, BlueTextBox, GreenTextBox, HexTextBox;
        private IHuePicker ValueSaturationPicker;
        private RadialColorSlider HueSlider;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            //gets sliders
            AlphaSliderVertical = this.GetControl<Slider>(e, "PART_AlphaSlider");

            AlphaSlider = this.GetControl<Slider>(e, "PART_AlphaSlider");
            RedSlider = this.GetControl<Slider>(e, "PART_AlphaSlider");
            BlueSlider = this.GetControl<Slider>(e, "PART_AlphaSlider");
            GreenSlider = this.GetControl<Slider>(e, "PART_AlphaSlider");

            //gets textboxs
            AlphaTextBox = this.GetControl<TextBox>(e, "PART_AlphaTextBox");
            RedTextBox = this.GetControl<TextBox>(e, "PART_AlphaTextBox");
            BlueTextBox = this.GetControl<TextBox>(e, "PART_AlphaTextBox");
            GreenTextBox = this.GetControl<TextBox>(e, "PART_AlphaTextBox");

            HexTextBox = this.GetControl<TextBox>(e, "PART_HexTextBox");

            ValueSaturationPicker = this.GetControl<HuePickerBase>(e, "PART_SaturationValuePicker");

            HueSlider = this.GetControl<RadialColorSlider>(e, "PART_HueSlider");
        }
    }
}
