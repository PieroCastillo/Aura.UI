using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;

namespace Aura.UI.Painting.Controls
{
    public class AuraColorPicker : TemplatedControl
    {
        HueColorSelector hueSelector;
        SaturationValueColorSelector satValueSelector;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            this.GetControl(e, "PART_Hue", out hueSelector);
            this.GetControl(e, "PART_SV", out satValueSelector);

            this.GetObservable(SelectedColorProperty).Subscribe(x =>
            {
                var hsv = x.ToHSV();

                hueSelector.Value = hsv.H;
                satValueSelector.Saturation = hsv.S;
                satValueSelector.Value = hsv.V;
                satValueSelector.UpdatePositionsFromValues(double.NaN);
            });
        }

        private Color _SelectedColor;
        public Color SelectedColor
        {
            get => _SelectedColor;
            set => SetAndRaise(SelectedColorProperty, ref _SelectedColor, value);
        }

        public static readonly DirectProperty<AuraColorPicker, Color> SelectedColorProperty =
            AvaloniaProperty.RegisterDirect<AuraColorPicker, Color>(nameof(SelectedColor), o => o.SelectedColor, (o, v) => o.SelectedColor = v);

        public double StrokeWidth
        {
            get => GetValue(StrokeWidthProperty);
            set => SetValue(StrokeWidthProperty, value);
        }

        public static readonly StyledProperty<double> StrokeWidthProperty =
            AvaloniaProperty.Register<AuraColorPicker, double>(nameof(StrokeWidth), 10);


    }
}
