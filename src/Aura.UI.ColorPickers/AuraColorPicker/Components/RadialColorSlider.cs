using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Media;
using Avalonia.Metadata;

namespace Aura.UI.Controls.Components
{
    public class RadialColorSlider : RadialSlider, ILogical
    {
        static RadialColorSlider()
        {
            MinimumProperty.OverrideMetadata<RadialColorSlider>(new DirectPropertyMetadata<double>(0));
            MaximumProperty.OverrideMetadata<RadialColorSlider>(new DirectPropertyMetadata<double>(360));

            BoundsProperty.Changed.Subscribe(x =>
            {
                if (x.Sender is RadialColorSlider r)
                {
                    r.InternalWidth = r.Bounds.Width - (r.StrokeWidth * 2);
                }
            });

            ValueProperty.Changed.Subscribe(x =>
            {
                if(x.Sender is RadialColorSlider r)
                {
                    r.HueColor = new HSV(r.Value, 1, 1).ToColor(); 
                }
            });
        }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            //if (Helpers.Maths.CircularCrownContainsPoint(e.GetPosition(null), Bounds.Center, (Bounds.Width - StrokeWidth) / 2, Bounds.Width / 2))
            //{
                base.OnPointerMoved(e);
            //}
        }

        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        {
            base.OnPropertyChanged(change);

            if (Content is TrianglePicker t && (change.Property == BoundsProperty))
            {
                Debug.WriteLine(InternalWidth.ToString());
                Debug.WriteLine(Bounds.Height.ToString());
                YTranslation = (InternalWidth - (t.Bounds.Width));
                Debug.WriteLine(YTranslation.ToString());
            }
        }

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);

            if (Content is Control c)
            {
                c.InvalidateMeasure();
            }
        }


        private double _YTranslation;
        public double YTranslation
        {
            get => _YTranslation;
            private set => SetAndRaise(YTranslationProperty, ref _YTranslation, value);
        }

        public static readonly DirectProperty<RadialColorSlider, double> YTranslationProperty =
            AvaloniaProperty.RegisterDirect<RadialColorSlider, double>(nameof(YTranslation), o => o.YTranslation);

        [Content]
        public object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }
        public static readonly StyledProperty<object> ContentProperty =
            AvaloniaProperty.Register<RadialColorSlider, object>(nameof(Content));


        private double _InternalWidth;
        public double InternalWidth
        {
            get => _InternalWidth;
            private set => SetAndRaise(InternalWidthProperty, ref _InternalWidth, value);
        }

        public static readonly DirectProperty<RadialColorSlider, double> InternalWidthProperty =
            AvaloniaProperty.RegisterDirect<RadialColorSlider, double>(nameof(InternalWidth), o => o.InternalWidth);


        private bool _IsLocked;
        public bool IsLocked
        {
            get => _IsLocked;
            set => SetAndRaise(IsLockedProperty, ref _IsLocked, value);
        }

        public static readonly DirectProperty<RadialColorSlider, bool> IsLockedProperty =
            AvaloniaProperty.RegisterDirect<RadialColorSlider, bool>(nameof(IsLocked), o => o.IsLocked, (o, v) => o.IsLocked = v);

        private Color _HueColor;
        public Color HueColor
        {
            get => _HueColor;
            private set => SetAndRaise(HueColorProperty, ref _HueColor, value);
        }

        public static readonly DirectProperty<RadialColorSlider, Color> HueColorProperty =
            AvaloniaProperty.RegisterDirect<RadialColorSlider, Color>(nameof(HueColor), o => o.HueColor, unsetValue: Colors.Red);


    }
}
