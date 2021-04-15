using Aura.UI.Extensions;
using Avalonia.Media;
using System;

namespace Aura.UI.Controls
{
    public partial class AuraColorPicker
    {
        private void UpdateHueSlider()
        {
            HueSlider.Value = SelectedColor.ToHSV().H;
        }
        private void UpdateSaturationValuePicker()
        {
            ValueSaturationPicker.Saturation = S;
            ValueSaturationPicker.ValueColor = V;
            ValueSaturationPicker.Hue = new HSV(H, 1,1).ToColor();
        }
        private void UpdateAlphaSlider()
        {
            AlphaSlider.Value = SelectedColor.A;
        }
        private void UpdateHexText()
        {
            HexTextBox.Text = SelectedColor.ToString();
        }
    }
}
