using Aura.UI.Controls.Components;
using Aura.UI.Controls.Primitives;
using Aura.UI.Extensions;
using Aura.UI.Helpers;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class AuraColorPicker : TemplatedControl
    {
        private Slider AlphaSlider;
        private TextBox HexTextBox; //AlphaTextBox, RedTextBox, BlueTextBox, GreenTextBox, ;
        private IHuePicker ValueSaturationPicker;
        private RadialColorSlider HueSlider;

        protected void SelectNewColor(Color color, UpdatedColorReason reason)
        {
            var hsv = color.ToHSV();

            H = hsv.H;
            S = hsv.S;
            V = hsv.V;

            R = color.R;
            G = color.G;
            B = color.B;
            A = color.A;

            Debug.WriteLine(hsv.ToString());

            var oldColor = SelectedColor;

            SelectedColor = color;

            switch (reason)
            {
                case UpdatedColorReason.AChanged:
                    UpdateHexText();
                    Debug.WriteLine("alpha changed");
                    break;
                case UpdatedColorReason.HueChanged:
                    UpdateHexText();
                    Debug.WriteLine("hue changed");
                    break;
                case UpdatedColorReason.ValueAndSaturationChanged:
                    UpdateHexText();
                    Debug.WriteLine("value or saturation changed");
                    break;
                case UpdatedColorReason.HexChanged:
                    UpdateAlphaSlider();
                    UpdateHueSlider();
                    UpdateSaturationValuePicker();
                    Debug.WriteLine("hex changed");
                    break;

                case UpdatedColorReason.ColorPickerInitializated:
                    UpdateHexText();
                    UpdateAlphaSlider();
                    UpdateHueSlider();
                    UpdateSaturationValuePicker();
                    Debug.WriteLine("Initalized Correctly");
                    break;
            }

            var args = new ColorChangedEventArgs(ColorChangedEvent, PreviewColor, oldColor, color, reason);
            RaiseEvent(args);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            //gets slider
            AlphaSlider = this.GetControl<Slider>(e, "PART_AlphaSlider");

            HexTextBox = this.GetControl<TextBox>(e, "PART_HexTextBox");

            ValueSaturationPicker = this.GetControl<HuePickerBase>(e, "PART_SaturationValuePicker");

            HueSlider = this.GetControl<RadialColorSlider>(e, "PART_HueSlider");

            SelectNewColor(PreviewColor, UpdatedColorReason.ColorPickerInitializated);
            
            RadialColorSlider.ValueProperty.Changed.AddClassHandler<RadialColorSlider>((x, e) =>
            {
                if (e.Sender == HueSlider)
                {
                    SelectNewColor(new HSV(HueSlider.Value, S, V).ToColor(), UpdatedColorReason.HueChanged);
                }
            });
            HuePickerBase.ValueColorProperty.Changed.AddClassHandler<HuePickerBase>((x, e) =>
            {
                if (e.Sender == ValueSaturationPicker)
                {
                    SelectNewColor(new HSV(H, (byte)ValueSaturationPicker.Saturation, (byte)ValueSaturationPicker.ValueColor).ToColor(), UpdatedColorReason.ValueAndSaturationChanged);
                }
            });
            Slider.ValueProperty.Changed.AddClassHandler<Slider>((x, e) =>
            {
                if (e.Sender == AlphaSlider)
                {
                    SelectNewColor(Color.FromArgb((byte)A , (byte)R, (byte)G , (byte)B), UpdatedColorReason.AChanged);
                }
            });
            
            HexTextBox.TextInput += delegate
            {
                var isValid = Color.TryParse(HexTextBox.Text, out Color color);
                if (isValid)
                {
                    SelectNewColor(color, UpdatedColorReason.HexChanged);
                }
                else
                {
                    HexTextBox.Text = SelectedColor.ToString();
                }
            };

        }
    }
}
