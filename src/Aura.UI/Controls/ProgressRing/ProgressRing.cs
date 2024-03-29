﻿using Aura.UI.Helpers;
using Avalonia;
using Avalonia.Controls.Primitives;
using System;

namespace Aura.UI.Controls
{
    public partial class ProgressRing : RangeBase
    {
        static ProgressRing()
        {
            MaximumProperty.Changed.Subscribe(CalibrateAngles);
            MinimumProperty.Changed.Subscribe(CalibrateAngles);
            ValueProperty.Changed.Subscribe(CalibrateAngles);

            MaximumProperty.OverrideMetadata<ProgressRing>(new StyledPropertyMetadata<double>(100));
            MinimumProperty.OverrideMetadata<ProgressRing>(new StyledPropertyMetadata<double>(0));
            ValueProperty.OverrideMetadata<ProgressRing>(new StyledPropertyMetadata<double>(25));

            AffectsRender<ProgressRing>(XAngleProperty, YAngleProperty);
        }

        private static void CalibrateAngles(AvaloniaPropertyChangedEventArgs<double> e)
        {
            var pr = e.Sender as ProgressRing;

            if (pr != null)
            {
                pr.XAngle = -90;
                pr.YAngle = Maths.AngleFromMinMaxValue(pr.Value, pr.Minimum, pr.Maximum);
            }
        }
    }
}