using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Styling;

namespace Aura.UI.Controls
{
    public class CardControl : HeaderedContentControl
    {
        public object SecondaryHeader
        {
            get => GetValue(SecondaryHeaderProperty);
            set => SetValue(SecondaryHeaderProperty, value);
        }

        public static readonly StyledProperty<object> SecondaryHeaderProperty =
            AvaloniaProperty.Register<CardControl, object>(nameof(SecondaryHeader));

        public ITemplate SecondaryHeaderTemplate
        {
            get => GetValue(SecondaryHeaderTemplateProperty);
            set => SetValue(SecondaryHeaderTemplateProperty, value);
        }

        public static readonly StyledProperty<ITemplate> SecondaryHeaderTemplateProperty =
            AvaloniaProperty.Register<CardControl, ITemplate>(nameof(SecondaryHeaderTemplate));

        public IBrush SecondaryBackground
        {
            get => GetValue(SecondaryBackgroundProperty);
            set => SetValue(SecondaryBackgroundProperty, value);
        }

        public static readonly StyledProperty<IBrush> SecondaryBackgroundProperty =
            AvaloniaProperty.Register<CardControl, IBrush>(nameof(SecondaryBackground));

        public bool ScaleOnPointerOver
        {
            get => GetValue(ScaleOnPointerOverProperty);
            set => SetValue(ScaleOnPointerOverProperty, value);
        }

        public static readonly StyledProperty<bool> ScaleOnPointerOverProperty =
            AvaloniaProperty.Register<CardControl, bool>(nameof(ScaleOnPointerOver), true);

        public BoxShadows BoxShadow
        {
            get => GetValue(BoxShadowProperty);
            set => SetValue(BoxShadowProperty, value);
        }

        public static readonly StyledProperty<BoxShadows> BoxShadowProperty =
            AvaloniaProperty.Register<CardControl, BoxShadows>(nameof(BoxShadow));

        public BoxShadows InternalBoxShadow
        {
            get => GetValue(InternalBoxShadowProperty);
            set => SetValue(InternalBoxShadowProperty, value);
        }

        public static readonly StyledProperty<BoxShadows> InternalBoxShadowProperty =
            AvaloniaProperty.Register<CardControl, BoxShadows>(nameof(InternalBoxShadow));

        /// <summary>
        /// Defines the Uniform CornerRadius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<CardControl, CornerRadius>(nameof(CornerRadius), new CornerRadius(7));

        /// <summary>
        /// Defines the Top CornerRadius
        /// </summary>
        public CornerRadius TopCornerRadius
        {
            get { return GetValue(TopCornerRadiusProperty); }
            set { SetValue(TopCornerRadiusProperty, value); }
        }

        public static readonly StyledProperty<CornerRadius> TopCornerRadiusProperty =
            AvaloniaProperty.Register<CardControl, CornerRadius>(nameof(TopCornerRadius), new CornerRadius(7, 0));

        /// <summary>
        /// Defines the Bottom CornerRadius
        /// </summary>
        public CornerRadius BottomCornerRadius
        {
            get { return GetValue(BottomCornerRadiusProperty); }
            set { SetValue(BottomCornerRadiusProperty, value); }
        }

        public static readonly StyledProperty<CornerRadius> BottomCornerRadiusProperty =
            AvaloniaProperty.Register<CardControl, CornerRadius>(nameof(BottomCornerRadius), new CornerRadius(0, 7));

        public CornerRadius InternalCornerRadius
        {
            get { return GetValue(InternalCornerRadiusProperty); }
            set { SetValue(InternalCornerRadiusProperty, value); }
        }

        public static readonly StyledProperty<CornerRadius> InternalCornerRadiusProperty =
            AvaloniaProperty.Register<CardControl, CornerRadius>(nameof(InternalCornerRadius), new CornerRadius(7));

        public Thickness InternalPadding
        {
            get { return GetValue(InternalPaddingProperty); }
            set { SetValue(InternalPaddingProperty, value); }
        }

        public static readonly StyledProperty<Thickness> InternalPaddingProperty =
            AvaloniaProperty.Register<CardControl, Thickness>(nameof(InternalPadding));
    }
}