//using Aura.UI.Attributes;
//using Avalonia;
//using Avalonia.Controls;
//using Avalonia.Controls.Shapes;
//using Avalonia.Data;
//using Avalonia.Data.Core;
//using Avalonia.Input;
//using Avalonia.Markup.Xaml;
//using Avalonia.Media;
//using Avalonia.Native.Interop;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Aura.UI.Xaml
//{
//    [DonotUse(Reason = "THIS EXTENSION IS IN DEVELOPING")]
//    [InDeveloping]
//    public class RevealExtension : MarkupExtension
//    {
//        public override object ProvideValue(IServiceProvider serviceProvider)
//        {
//            var provide_target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
//            var target = provide_target.TargetObject as Control;
//            control_ = target;
//            control_.PointerMoved += Control__PointerMoved;
//            control_.PointerMoved += (sender, e) =>
//            {
//                Canvas.SetLeft(ellipse, Y);
//                Canvas.SetRight(ellipse, Y);
//                Canvas.SetTop(ellipse, X);
//            };
//            var b = CreateBrush() as VisualBrush;
            
//            return b;
//        }


//        private void Control__PointerMoved(object sender, Avalonia.Input.PointerEventArgs e)
//        {
//            X = e.GetPosition(control_).X;
//            Y = e.GetPosition(control_).Y;
//            ellipse.Height = X;
//            ellipse.Width = Y;
//        }

//        public IVisualBrush CreateBrush()
//        {
//            var el = new Ellipse()
//            {
//                Width = CursorRadius,
//                Height = CursorRadius,
//                Fill = GenerateRadialBrush()
//            };
//            ellipse = el;
//            cnv.Height = control_.Height;
//            cnv.Width = control_.Width;
//            cnv.Children.Add(ellipse);

//            return new VisualBrush(ellipse) { TileMode = TileMode.None, Stretch = Stretch.None };
//        }

//        public static Canvas GenerateCanvas()
//        {
//            return new Canvas() { HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
//                                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch   };
//        }

//        public IRadialGradientBrush GenerateRadialBrush()
//        {
//            var r = new RadialGradientBrush();
//            //var c = CursorRadius / 2;
//            r.GradientStops.Add(new GradientStop(TintColor, 0));
//            r.GradientStops.Add(new GradientStop(Colors.Transparent, 1));
//            r.GradientOrigin = CreateRelativePoint();
//            r.Center = CreateRelativePoint();
//            return r;
//        }

//        public RelativePoint CreateRelativePoint()
//        {
//            return new RelativePoint(X, Y, RelativeUnit.Relative);
//        }

//        public Color TintColor { get; set; } = Colors.Gray;
//        public double CursorRadius { get; set; } = 20;

//        public double Opacity { get; set; } = 0.5;

//        private Ellipse ellipse;
        
//        private Control control_;

//        private Canvas cnv = GenerateCanvas();

//        private double X;
//        private double Y;
//    }

//    public class RevealObject
//    {
//        public readonly static StyledProperty<Brush> PointerOverForegroundBrushProperty =
//            AvaloniaProperty.RegisterAttached<RevealObject, Control, Brush>("PointerOverForegroundBrush");
//    }
//}
