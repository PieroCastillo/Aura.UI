using Avalonia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class ProgressRing
    {
        /// <summary>
        /// The ProgressRing Value, from 0 to 100
        /// </summary>
        public double Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        public static readonly StyledProperty<double> ValueProperty =
            AvaloniaProperty.Register<ProgressRing, double>(nameof(Value), 0);

        /// <summary>
        /// Gets or sets if the ProgressRing is Indeterminate
        /// </summary>
        public bool IsIndeterminate
        {
            get => GetValue(IsIndeterminateProperty);
            set => SetValue(IsIndeterminateProperty, value);
        }
        public static readonly StyledProperty<bool> IsIndeterminateProperty =
            AvaloniaProperty.Register<ProgressRing, bool>(nameof(IsIndeterminate), false);

        public double XAngle
        {
            get;
            set;
        }

        public double YAngle
        {
            get;
            set;
        }
    }
}
