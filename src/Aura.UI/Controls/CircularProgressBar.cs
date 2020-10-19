//using Avalonia;
//using Avalonia.Controls;
//using Avalonia.Controls.Primitives;
//using Avalonia.Media;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Aura.UI.Controls
//{
//    public class CircularProgressBar : RangeBase
//    {
//        public IBrush TextBrush
//        {
//            get => GetValue(TextBrushProperty);
//            set => SetValue(TextBrushProperty, value);
//        }
//        public static readonly StyledProperty<IBrush> TextBrushProperty =
//            AvaloniaProperty.Register<CircularProgressBar, IBrush>(nameof(TextBrush));
        
//        public double Radius
//        {
//            get => GetValue(RadiusProperty);
//            set => SetValue(RadiusProperty, value);
//        }
//        public static readonly StyledProperty<double> RadiusProperty =
//            AvaloniaProperty.Register<CircularProgressBar, double>(nameof(Radius), 5);

//        public double Diameter
//        {
//            get => GetValue(DiameterProperty);
//            set => SetValue(DiameterProperty, value);
//        }
//        public static readonly StyledProperty<double> DiameterProperty =
//            AvaloniaProperty.Register<CircularProgressBar, double>(nameof(Diameter), 100);

//        public Thickness RadiusPadding
//        {
//            get => GetValue(RadiusPaddingProperty);
//            private set => SetValue(RadiusPaddingProperty, value);
//        }
//        public static readonly StyledProperty<Thickness> RadiusPaddingProperty =
//            AvaloniaProperty.Register<CircularProgressBar, Thickness>(nameof(RadiusPadding), new Thickness(5));

//        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
//        {
//            base.OnPropertyChanged(change);

//            if(change.Property == RadiusProperty)
//            {
//                RadiusPadding = new Thickness(Radius);
//            }
//        }
//    }
//}
