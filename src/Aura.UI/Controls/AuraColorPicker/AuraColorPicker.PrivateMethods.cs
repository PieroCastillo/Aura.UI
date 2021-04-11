using Aura.UI.Extensions;
using Avalonia.Media;
using System;

namespace Aura.UI.Controls
{
    public partial class AuraColorPicker
    {
        private void UpdateHueSlider()
        {
            HueSlider.Value = SelectedColor.GetHue();
        }
        private void UpdateSaturationValuePicker()
        {
            SelectedColor.ToHSV(out _, out byte saturation, out byte value);
            ValueSaturationPicker.Saturation = saturation;
            ValueSaturationPicker.ValueColor = value;
            ValueSaturationPicker.Hue = SelectedColor;
        }
        private void UpdateAlphaSlider()
        {
            AlphaSlider.Value = SelectedColor.A;
        }
        private void UpdateRedSlider()
        {
            RedSlider.Value = SelectedColor.R;
        }

        private void UpdateGreenSlider()
        {
            GreenSlider.Value = SelectedColor.G;
        }

        private void UpdateBlueSlider()
        {
            BlueSlider.Value = SelectedColor.B;
        }
        /*private void UpdateAlphaTextBox()
        {
            AlphaTextBox.Text = SelectedColor.A.ToString();
        }
        private void UpdateRedTextBox()
        {
            RedTextBox.Text = SelectedColor.R.ToString();
        }

        private void UpdateGreenTextBox()
        {
            GreenTextBox.Text = SelectedColor.G.ToString();
        }

        private void UpdateBlueTextBox()
        {
            BlueTextBox.Text = SelectedColor.B.ToString();
        }*/
        private void UpdateHexText()
        {
            HexTextBox.Text = SelectedColor.ToString();
        }
    }
}
