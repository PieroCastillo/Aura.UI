using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aura.UI.Extensions;

namespace Aura.UI.Controls.Painting
{
    public class HSVViewer : TemplatedControl
    {
        public HSVViewer()
        {
            this.GetObservable(HueProperty).Subscribe(UpdateColor);
            this.GetObservable(ValueProperty).Subscribe(UpdateColor);
            this.GetObservable(SaturationProperty).Subscribe(UpdateColor);
        }

        private void UpdateColor(double @object)
        {
            SelectedColor = new HSV(Hue, Saturation, Value).ToColor();
            //await Task.Run(() =>
            //{
            //    
            //});
        }

        public double Hue
        {
            get => GetValue(HueProperty);
            set => SetValue(HueProperty, value);
        }

        public static readonly StyledProperty<double> HueProperty =
            AvaloniaProperty.Register<HSVViewer, double>(nameof(Hue), 0);

        public double Saturation
        {
            get => GetValue(SaturationProperty);
            set => SetValue(SaturationProperty, value);
        }

        public static readonly StyledProperty<double> SaturationProperty =
            AvaloniaProperty.Register<HSVViewer, double>(nameof(Saturation), 0);

        public double Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly StyledProperty<double> ValueProperty =
            AvaloniaProperty.Register<HSVViewer, double>(nameof(Value), 1);


        private Color _SelectedColor;
        public Color SelectedColor
        {
            get => _SelectedColor;
            set => SetAndRaise(SelectedColorProperty, ref _SelectedColor, value);
        }

        public static readonly DirectProperty<HSVViewer, Color> SelectedColorProperty =
            AvaloniaProperty.RegisterDirect<HSVViewer, Color>(nameof(SelectedColor), o => o.SelectedColor, (o, v) => o.SelectedColor = v);


    }
}
