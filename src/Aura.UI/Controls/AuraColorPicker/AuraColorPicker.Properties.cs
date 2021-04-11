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

        public static readonly DirectProperty<AuraColorPicker, Color> PreviewColorProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, Color>(nameof(PreviewColor), o => o.SelectedColor, (o,v) => o.PreviewColor = v);
        public static readonly DirectProperty<AuraColorPicker, Color> SelectedColorProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, Color>(nameof(SelectedColor), o => o.SelectedColor);
        public static readonly DirectProperty<AuraColorPicker, double> RProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(R), o => o.R, (o, v) => o.R = v);
        public static readonly DirectProperty<AuraColorPicker, double> GProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(G), o => o.G, (o, v) => o.G = v);
        public static readonly DirectProperty<AuraColorPicker, double> BProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(B), o => o.B, (o, v) => o.B = v);
        public static readonly DirectProperty<AuraColorPicker, double> AProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(A), o => o.A, (o, v) => o.A = v);
        public static readonly DirectProperty<AuraColorPicker, double> HProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(H), o => o.H, (o, v) => o.H = v);
        public static readonly DirectProperty<AuraColorPicker, double> SProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(S), o => o.S, (o, v) => o.S = v);
        public static readonly DirectProperty<AuraColorPicker, double> VProperty = AvaloniaProperty.RegisterDirect<AuraColorPicker, double>(nameof(V), o => o.V, (o, v) => o.V = v);
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
            set => SetAndRaise(RProperty, ref _R, value);
        }

        public double G
        {
            get => _G;
            set => SetAndRaise(GProperty, ref _G, value);
        }

        public double B
        {
            get => _B;
            set => SetAndRaise(BProperty, ref _B, value);
        }

        public double A
        {
            get => _A;
            set => SetAndRaise(AProperty, ref _A, value);
        }

        public double H
        {
            get => _H;
            set => SetAndRaise(HProperty, ref _H, value);
        }

        public double S
        {
            get => _S;
            set => SetAndRaise(SProperty, ref _S, value);
        }

        public double V
        {
            get => _V;
            set => SetAndRaise(VProperty, ref _V, value);
        }

        public string Hexadecimal
        {
            get => _Hexadecimal;
            set => SetAndRaise(HexadecimalProperty, ref _Hexadecimal, value);
        }
    }
}
