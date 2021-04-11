using Aura.UI.Controls.Components;
using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class AuraColorPicker : TemplatedControl
    {
        private Slider AlphaSlider, RedSlider, BlueSlider, GreenSlider;
        private TextBox HexTextBox; //AlphaTextBox, RedTextBox, BlueTextBox, GreenTextBox, ;
        private IHuePicker ValueSaturationPicker;
        private RadialColorSlider HueSlider;

        protected void SelectNewColor(Color color, UpdatedColorReason reason)
        {
            var oldColor = SelectedColor;

            SelectedColor = color;

            switch (reason)
            {
                case UpdatedColorReason.RChanged:
                    UpdateGreenSlider();
                    UpdateBlueSlider();
                    UpdateHueSlider();
                    UpdateHexText();
                    UpdateSaturationValuePicker();
                    break;
                case UpdatedColorReason.GChanged:
                    UpdateRedSlider();
                    UpdateBlueSlider();
                    UpdateHueSlider();
                    UpdateHexText();
                    UpdateSaturationValuePicker(); break;
                case UpdatedColorReason.BChanged:
                    UpdateRedSlider();
                    UpdateGreenSlider();
                    UpdateHueSlider();
                    UpdateHexText();
                    UpdateSaturationValuePicker(); break;
                case UpdatedColorReason.AChanged:
                    UpdateHexText();
                    break;
                case UpdatedColorReason.HueChanged:
                    UpdateRedSlider();
                    UpdateGreenSlider();
                    UpdateBlueSlider();
                    UpdateSaturationValuePicker();
                    UpdateHexText();
                    break;
                case UpdatedColorReason.ValueAndSaturationChanged:
                    UpdateRedSlider();
                    UpdateGreenSlider();
                    UpdateBlueSlider();
                    UpdateHexText();
                    break;
                case UpdatedColorReason.HexChanged:
                    UpdateRedSlider();
                    UpdateGreenSlider();
                    UpdateBlueSlider();
                    UpdateAlphaSlider();
                    UpdateHueSlider();
                    UpdateSaturationValuePicker();
                    break;

                case UpdatedColorReason.ColorPickerInitializated:
                    UpdateRedSlider();
                    UpdateGreenSlider();
                    UpdateBlueSlider();
                    UpdateAlphaSlider();
                    UpdateHueSlider();
                    UpdateSaturationValuePicker();
                    UpdateHexText();
                    break;
            }

            var args = new ColorChangedEventArgs(ColorChangedEvent, PreviewColor, oldColor, color, reason);
            RaiseEvent(args);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            //gets sliders
            AlphaSlider = this.GetControl<Slider>(e, "PART_AlphaSlider");
            RedSlider = this.GetControl<Slider>(e, "PART_AlphaSlider");
            BlueSlider = this.GetControl<Slider>(e, "PART_AlphaSlider");
            GreenSlider = this.GetControl<Slider>(e, "PART_AlphaSlider");

            //gets textboxs
            /*AlphaTextBox = this.GetControl<TextBox>(e, "PART_AlphaTextBox");
            RedTextBox = this.GetControl<TextBox>(e, "PART_AlphaTextBox");
            BlueTextBox = this.GetControl<TextBox>(e, "PART_AlphaTextBox");
            GreenTextBox = this.GetControl<TextBox>(e, "PART_AlphaTextBox");*/

            HexTextBox = this.GetControl<TextBox>(e, "PART_HexTextBox");

            ValueSaturationPicker = this.GetControl<HuePickerBase>(e, "PART_SaturationValuePicker");

            HueSlider = this.GetControl<RadialColorSlider>(e, "PART_HueSlider");

            RadialColorSlider.ValueProperty.Changed.Subscribe(x => 
            {
                if(e.Source == HueSlider)
                {
                    SelectNewColor(Extensions.ColorExtensions.FromHSV((float)HueSlider.Value, (byte)S, (byte)V), UpdatedColorReason.HexChanged);
                }
            });
            HuePickerBase.ValueColorProperty.Changed.Subscribe(x =>
            {
                if (e.Source == ValueSaturationPicker)
                {
                    SelectNewColor(Extensions.ColorExtensions.FromHSV((float)H, (byte)S, (byte)ValueSaturationPicker.ValueColor), UpdatedColorReason.ValueAndSaturationChanged);
                }
            });
            HuePickerBase.SaturationProperty.Changed.Subscribe(x =>
            {
                if (e.Source == ValueSaturationPicker)
                {
                    SelectNewColor(Extensions.ColorExtensions.FromHSV((float)H, (byte)ValueSaturationPicker.Saturation, (byte)V), UpdatedColorReason.ValueAndSaturationChanged);
                }
            });
            Slider.ValueProperty.Changed.Subscribe(x =>
            {
                if(e.Source == AlphaSlider)
                {
                    SelectNewColor(Color.FromArgb((byte)AlphaSlider.Value, (byte)R, (byte)G, (byte)B), UpdatedColorReason.AChanged);
                }
            });
            Slider.ValueProperty.Changed.Subscribe(x =>
            {
                if (e.Source == RedSlider)
                {
                    SelectNewColor(Color.FromArgb((byte)A, (byte)RedSlider.Value, (byte)G, (byte)B), UpdatedColorReason.RChanged);
                }
            });
            Slider.ValueProperty.Changed.Subscribe(x =>
            {
                if (e.Source == GreenSlider)
                {
                    SelectNewColor(Color.FromArgb((byte)A, (byte)R, (byte)GreenSlider.Value, (byte)B), UpdatedColorReason.GChanged);
                }
            });
            Slider.ValueProperty.Changed.Subscribe(x =>
            {
                if (e.Source == BlueSlider)
                {
                    SelectNewColor(Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)BlueSlider.Value), UpdatedColorReason.BChanged);
                }
            });
            HexTextBox.LostFocus += delegate
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

            SelectNewColor(PreviewColor, UpdatedColorReason.ColorPickerInitializated);
        }
    }
}
