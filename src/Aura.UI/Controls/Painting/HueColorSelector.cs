using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Input;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Painting
{
    public class HueColorSelector : RadialSlider
    {
        static HueColorSelector()
        {
            ClipToBoundsProperty.OverrideDefaultValue<HueColorSelector>(false);
            MaximumProperty.OverrideMetadata<HueColorSelector>(new DirectPropertyMetadata<double>(360));
            MinimumProperty.OverrideMetadata<HueColorSelector>(new DirectPropertyMetadata<double>(0));
            ValueProperty.OverrideMetadata<HueColorSelector>(new DirectPropertyMetadata<double>(0));
        }

        public HueColorSelector()
        {
            this.GetObservable(ValueProperty).Subscribe((d) =>
            {
                RawColor = new HSV(Value, 1, 1).ToColor();
            });
        }

        public ControlTemplate ThumbTemplate
        {
            get => GetValue(ThumbTemplateProperty);
            set => SetValue(ThumbTemplateProperty, value);
        }

        public static readonly StyledProperty<ControlTemplate> ThumbTemplateProperty =
            AvaloniaProperty.Register<HueColorSelector, ControlTemplate>(nameof(ThumbTemplate));


        private Color _RawColor;
        public Color RawColor
        {
            get => _RawColor;
            private set => SetAndRaise(RawColorProperty, ref _RawColor, value);
        }

        public static readonly DirectProperty<HueColorSelector, Color> RawColorProperty =
            AvaloniaProperty.RegisterDirect<HueColorSelector, Color>(nameof(RawColor), o => o.RawColor);


    }
}
