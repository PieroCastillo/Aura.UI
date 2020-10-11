using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using ColorPicker.Structures;
using ColorPicker.Utilities;
using ColorPicker.Wheels;
using System;

namespace ColorPicker
{
    public class ColorWheel : UserControl
    {

        public static readonly StyledProperty<double> ThumbSizeProperty = AvaloniaProperty.Register<ColorWheel, double>(nameof(ThumbSize));
        public static readonly StyledProperty<double> ThetaProperty = AvaloniaProperty.Register<ColorWheel, double>(nameof(Theta));
        public static readonly StyledProperty<double> RadProperty = AvaloniaProperty.Register<ColorWheel, double>(nameof(Rad));
        public static readonly StyledProperty<RGBColor> SelectedColorProperty = AvaloniaProperty.Register<ColorWheel, RGBColor>(nameof(SelectedColor), new RGBColor(255, 255, 255), false, Avalonia.Data.BindingMode.TwoWay);


        //UI Controls (defined in XAML)
        private Ellipse _selector;
        private Grid _grid;


        private HSVColor hsv;


        private Type wheelClass = typeof(HSVWheel);
        private ColorWheelBase wheel;
        private bool isDragging = false;

        public Type WheelClass
        {
            get { return typeof(HSVWheel); }
            set 
            { 
                wheelClass = value; 
                InstantiateWheel(); 
            }
        }

        public ColorWheel()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            _selector = this.Get<Ellipse>("selector");
            _grid = this.Get<Grid>("grid");

            _selector.PointerMoved += _selector_PointerMoved;
            _selector.PointerPressed += _selector_PointerPressed;
            _selector.PointerReleased += _selector_PointerReleased;

            WheelClass = typeof(HSVWheel);
        }


        //Public properties
        public double ThumbSize
        {
            get { return (double)GetValue(ThumbSizeProperty); }
            set { SetValue(ThumbSizeProperty, value); UpdateThumbSize(); }
        }

        public double Theta
        {
            get { return (double)GetValue(ThetaProperty); }
            set { SetValue(ThetaProperty, CircularMath.Mod(value)); }
        }

        public double Rad
        {
            get { return (double)GetValue(RadProperty); }
            set { SetValue(RadProperty, value); }
        }

        public RGBColor SelectedColor
        {
            get { return GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }


        //Wheel Creation & Configuration 

        public override void Render(DrawingContext context)
        {
            UpdateSelector();
            base.Render(context);
        }

        void InstantiateWheel()
        {

            //Leaving this here in case I create more color wheel types...

            if (wheel != null)
                this._grid.Children.Remove(wheel);

            if (wheelClass != null)
            {
                wheel = (ColorWheelBase)Activator.CreateInstance(WheelClass);
                wheel.Name = "wheel";
                wheel.PointerPressed += Wheel_PointerPressed; ;
                wheel.ZIndex = -2;
                _grid.Children.Add(wheel);

                wheel.PointerPressed += Wheel_PointerPressed;
            }
        }


        private void UpdateThumbSize()
        {
            _selector.Width = ThumbSize;
            _selector.Height = ThumbSize;
        }



        //Calculations
        private double CalculateTheta(Point point)
        {
            double cx = Bounds.Width / 2;
            double cy = Bounds.Height / 2;

            double dx = point.X - cx;
            double dy = point.Y - cy;

            double angle = Math.Atan2(dx, dy) / Math.PI * 180.0;

            // Theta is offset by 180 degrees, so red appears at the top
            return CircularMath.Mod(angle - 180.0);
        }

        private double CalculateR(Point point)
        {
            double cx = Bounds.Width / 2;
            double cy = Bounds.Height / 2;

            double dx = point.X - cx;
            double dy = point.Y - cy;

            double dist = Math.Sqrt(dx * dx + dy * dy);

            return Math.Min(dist, wheel.ActualOuterRadius) / wheel.ActualOuterRadius;
            //return (float)((Math.Min(dist, wheel.ActualOuterRadius) - wheel.ActualInnerRadius) / (wheel.ActualOuterRadius - wheel.ActualInnerRadius));
        }




        //Pointer Events
        private void Wheel_PointerPressed(object sender, PointerPressedEventArgs e)
        {
            // e.Pointer.Capture(this);
            UpdateSelectorFromPoint(e.GetPosition(this));
        }

        private void _selector_PointerReleased(object sender, PointerReleasedEventArgs e)
        {
            e.Pointer.Capture(null);
            isDragging = false;
        }

        private void _selector_PointerMoved(object sender, PointerEventArgs e)
        {
            if (isDragging)
            {
                // Calculate Theta and Rad from the mouse position
                UpdateSelectorFromPoint(e.GetPosition(this));
            }
        }

        public void _selector_PointerPressed(object sender, PointerPressedEventArgs e)
        {
            isDragging = true;
            UpdateSelectorFromPoint(e.GetPosition(this));
        }



        //Thumb Selector 
        private void UpdateSelector()
        {
            if (!double.IsNaN(Theta) && !double.IsNaN(this.Rad))
            {
                double cx = Bounds.Width / 2.0;
                double cy = Bounds.Height / 2.0;

                double radius = (wheel.ActualOuterRadius - wheel.ActualInnerRadius) * this.Rad + wheel.ActualInnerRadius;

                // Snap to middle of wheel when inside InnerRadius
                if (radius < wheel.ActualInnerRadius + float.Epsilon)
                    radius = 0.0;

                double angle = Theta + 180.0f;

                double x = radius * Math.Sin(angle * Math.PI / 180.0);
                double y = radius * Math.Cos(angle * Math.PI / 180.0);

                double mx = cx + x - _selector.Bounds.Width / 2;
                double my = cy + y - _selector.Bounds.Height / 2;

                hsv.hue = (float)Theta;
                hsv.sat = (float)Rad;
                hsv.value = 1.0f;

                _selector.Margin = new Thickness(mx, my, 0, 0);
                _selector.Fill = new SolidColorBrush(SelectedColor);
            }
        }


        private void UpdateSelectorFromPoint(Point point)
        {
            Theta = CalculateTheta(point);
            Rad = CalculateR(point);
            SelectedColor = wheel.ColorMapping(Rad, Theta, 1.0);

            UpdateSelector();            
        }



        //Animation
        private void AnimateTo(Point point)
        {
            Point from = new Point(this.Theta, this.Rad);
            Point to = new Point(CalculateTheta(point), CalculateR(point));

            double _x = 0;

            // The shortest path actually crosses the 360-0 discontinuity
            if (from.X - to.X > 180.0)
                _x += 360.0;
            if (from.X - to.X < -180.0)
                _x -= 360.0;

            Bounds = new Rect(new Point(_x, to.Y), this.Bounds.Size);
        }




    }
}
