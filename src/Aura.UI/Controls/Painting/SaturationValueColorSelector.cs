﻿using Aura.UI.Extensions;
using Aura.UI.Helpers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Rendering;
using System;
using System.Reactive;
using System.Collections.Generic;
using System.Text;
using Avalonia.Media;

namespace Aura.UI.Controls
{
    public class SaturationValueColorSelector : TemplatedControl
    {
        bool pressed;

        public SaturationValueColorSelector()
        {
            this.GetObservable(SaturationProperty).Subscribe(UpdatePositionsFromValues);
            this.GetObservable(ValueProperty).Subscribe(UpdatePositionsFromValues);
        }

        static SaturationValueColorSelector()
        {
            ClipToBoundsProperty.OverrideDefaultValue<SaturationValueColorSelector>(false);
        }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            base.OnPointerMoved(e);
            if (pressed)
            {
                var point = e.GetCurrentPoint(this).Position;
                UpdateValuesFromPoint(point);
                UpdatePositionsFromPoint(point);
            }
        }
        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            pressed = true;
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);
            pressed = false;
        }

        protected virtual void UpdateValuesFromPoint(Point point)
        {
            if (Maths.TriangleContains(new Point(Bounds.Width / 2, 0), Bounds.BottomLeft, Bounds.BottomRight, point))
            {
                var valueDistance = Bounds.BottomLeft.DistanceWith(point);
                var saturationDistance = Bounds.BottomRight.DistanceWith(point);
                var totalDistance = Bounds.Width;

                Value = valueDistance / totalDistance / 100;
                Saturation =saturationDistance / totalDistance / 100;
            }
        }
        protected virtual void UpdatePositionsFromPoint(Point point) => UpdatePositionsCore(point.X, point.Y);

        protected virtual void UpdatePositionsFromValues(double @object)
        {
            var totalDistance = Bounds.Width;

            UpdatePositionsCore(totalDistance * Value, totalDistance * Saturation);
        }

        private void UpdatePositionsCore(double x, double y)
        {
            if(Maths.TriangleContains(new Point(Bounds.Width / 2,0), Bounds.BottomLeft, Bounds.BottomRight, new Point(x, y)))
            {
                XPosition = x;
                YPosition = y;
            }
        }

        public double Saturation
        {
            get => GetValue(SaturationProperty);
            set => SetValue(SaturationProperty, value);
        }

        public static readonly StyledProperty<double> SaturationProperty =
            AvaloniaProperty.Register<SaturationValueColorSelector, double>(nameof(Saturation));

        public double Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly StyledProperty<double> ValueProperty =
            AvaloniaProperty.Register<SaturationValueColorSelector, double>(nameof(Value));


        private double _XPosition;
        public double XPosition
        {
            get => _XPosition;
            set => SetAndRaise(XPositionProperty, ref _XPosition, value);
        }

        public static readonly DirectProperty<SaturationValueColorSelector, double> XPositionProperty =
            AvaloniaProperty.RegisterDirect<SaturationValueColorSelector, double>(nameof(XPosition), o => o.XPosition, (o, v) => o.XPosition = v);


        private double _YPosition;
        public double YPosition
        {
            get => _YPosition;
            set => SetAndRaise(YPositionProperty, ref _YPosition, value);
        }

        public static readonly DirectProperty<SaturationValueColorSelector, double> YPositionProperty =
            AvaloniaProperty.RegisterDirect<SaturationValueColorSelector, double>(nameof(YPosition), o => o.YPosition, (o, v) => o.YPosition = v);

        public Color ColorToShow
        {
            get => GetValue(ColorToShowProperty);
            set => SetValue(ColorToShowProperty, value);
        }

        public static readonly StyledProperty<Color> ColorToShowProperty =
            AvaloniaProperty.Register<SaturationValueColorSelector, Color>(nameof(ColorToShow), Colors.Red);
    }
}
