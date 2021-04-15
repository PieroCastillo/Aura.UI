using Avalonia;
using Avalonia.Media;

namespace Aura.UI.Controls
{
    public partial class AuraColorPicker
    {
        private Color _PreviewColor;
        private Color _SelectedColor;
        private double _R;
        private double _G;
        private double _B;
        private double _A;
        private double _H;
        private double _S;
        private double _V;
        private string _Hexadecimal;

        public static readonly DirectProperty<AuraColorPicker, Color> PreviewColorProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, Color>(nameof(PreviewColor), o => o.SelectedColor, (o,v) => o.PreviewColor = v, Colors.Red);
        public static readonly DirectProperty<AuraColorPicker, Color> SelectedColorProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, Color>(nameof(SelectedColor), o => o.SelectedColor);
        public static readonly DirectProperty<AuraColorPicker, double> RProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(R), o => o.R);
        public static readonly DirectProperty<AuraColorPicker, double> GProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(G), o => o.G);
        public static readonly DirectProperty<AuraColorPicker, double> BProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(B), o => o.B);
        public static readonly DirectProperty<AuraColorPicker, double> AProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(A), o => o.A);
        public static readonly DirectProperty<AuraColorPicker, double> HProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(H), o => o.H);
        public static readonly DirectProperty<AuraColorPicker, double> SProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(S), o => o.S);
        public static readonly DirectProperty<AuraColorPicker, double> VProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(V), o => o.V);
        public static readonly DirectProperty<AuraColorPicker, string> HexadecimalProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, string>(nameof(Hexadecimal), o => o.Hexadecimal, (o, v) => o.Hexadecimal = v);
        
        public Color PreviewColor
        {
            get => _PreviewColor;
            set => SetAndRaise(PreviewColorProperty, ref _PreviewColor, value);
        }
        public Color SelectedColor
        {
            get => _SelectedColor;
            private set => SetAndRaise(SelectedColorProperty, ref _SelectedColor, value);
        }
        public double R
        {
            get => _R;
            private set => SetAndRaise(RProperty, ref _R, value);
        }

        public double G
        {
            get => _G;
            private set => SetAndRaise(GProperty, ref _G, value);
        }

        public double B
        {
            get => _B;
            private set => SetAndRaise(BProperty, ref _B, value);
        }

        public double A
        {
            get => _A;
            private set => SetAndRaise(AProperty, ref _A, value);
        }

        public double H
        {
            get => _H;
            private set => SetAndRaise(HProperty, ref _H, value);
        }

        public double S
        {
            get => _S;
            private set => SetAndRaise(SProperty, ref _S, value);
        }

        public double V
        {
            get => _V;
            private set => SetAndRaise(VProperty, ref _V, value);
        }

        public string Hexadecimal
        {
            get => _Hexadecimal;
            private set => SetAndRaise(HexadecimalProperty, ref _Hexadecimal, value);
        }


        private IBrush _GradientBrushForAlphaSlider;
        public IBrush GradientBrushForAlphaSlider
        {
            get => _GradientBrushForAlphaSlider;
            private set => SetAndRaise(GradientBrushForAlphaSliderProperty, ref _GradientBrushForAlphaSlider, value);
        }

        public static readonly DirectProperty<AuraColorPicker, IBrush> GradientBrushForAlphaSliderProperty =
            AvaloniaProperty.RegisterDirect<AuraColorPicker, IBrush>(nameof(GradientBrushForAlphaSlider), o => o.GradientBrushForAlphaSlider);


    }
}
