using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using Avalonia.Media;

namespace Aura.UI.Controls
{
    public class FloatingButtonBar : ItemsControl
    {
        static FloatingButtonBar()
        {
            FocusableProperty.OverrideDefaultValue<FloatingButtonBar>(false);
        }

        public bool IsExpanded
        {
            get => GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        public static readonly StyledProperty<bool> IsExpandedProperty =
            AvaloniaProperty.Register<FloatingButtonBar, bool>(nameof(IsExpanded), false);

        public FloatingButtonBarExpandDirection ExpandDirection
        {
            get => GetValue(ExpandDirectionProperty);
            set => SetValue(ExpandDirectionProperty, value);
        }

        public static readonly StyledProperty<FloatingButtonBarExpandDirection> ExpandDirectionProperty =
            AvaloniaProperty.Register<FloatingButtonBar, FloatingButtonBarExpandDirection>(nameof(ExpandDirection), FloatingButtonBarExpandDirection.ToRight);

        public object Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly StyledProperty<object> IconProperty =
            AvaloniaProperty.Register<FloatingButtonBar, object>(nameof(Icon));


        /// <summary>
        /// Defines the <see cref="IconTemplate"/> property.
        /// </summary>
        public static readonly StyledProperty<IDataTemplate> IconTemplateProperty =
            AvaloniaProperty.Register<FloatingButtonBar, IDataTemplate>(nameof(IconTemplate));

        /// <summary>
        /// The <see cref="IDataTemplate"/> to display the <see cref="Icon"/>
        /// </summary>
        public IDataTemplate IconTemplate
        {
            get => GetValue(IconTemplateProperty);
            set => SetValue(IconTemplateProperty, value);
        }


        /// <summary>
        /// Defines the <see cref="HorizontalIconAlignment"/> property.
        /// </summary>
        public static readonly StyledProperty<HorizontalAlignment> HorizontalIconAlignmentProperty =
            AvaloniaProperty.Register<FloatingButtonBar, HorizontalAlignment>(nameof(HorizontalIconAlignment), HorizontalAlignment.Stretch);

        /// <summary>
        /// Comment
        /// </summary>
        public HorizontalAlignment HorizontalIconAlignment
        {
            get => GetValue(HorizontalIconAlignmentProperty);
            set => SetValue(HorizontalIconAlignmentProperty, value);
        }


        /// <summary>
        /// Defines the <see cref="VerticalIconAlignment"/> property.
        /// </summary>
        public static readonly StyledProperty<VerticalAlignment> VerticalIconAlignmentProperty =
            AvaloniaProperty.Register<FloatingButtonBar, VerticalAlignment>(nameof(VerticalIconAlignment), VerticalAlignment.Stretch);

        /// <summary>
        /// Comment
        /// </summary>
        public VerticalAlignment VerticalIconAlignment
        {
            get => GetValue(VerticalIconAlignmentProperty);
            set => SetValue(VerticalIconAlignmentProperty, value);
        }


        /// <summary>
        /// Defines the <see cref="IconMargin"/> property.
        /// </summary>
        public static readonly StyledProperty<Thickness> IconMarginProperty =
            AvaloniaProperty.Register<FloatingButtonBar, Thickness>(nameof(IconMargin), new Thickness());

        /// <summary>
        /// The Margin around the Icon
        /// </summary>
        public Thickness IconMargin
        {
            get => GetValue(IconMarginProperty);
            set => SetValue(IconMarginProperty, value);
        }

        /// <summary>
        /// Defines the <see cref="IconForeground"/> property.
        /// </summary>
        public static readonly StyledProperty<IBrush> IconForegroundProperty =
            AvaloniaProperty.Register<FloatingButtonBar, IBrush>(nameof(IconForeground));

        /// <summary>
        /// Gets or Sets the Foreground of the Icon
        /// </summary>
        public IBrush IconForeground
        {
            get => GetValue(IconForegroundProperty);
            set => SetValue(IconForegroundProperty, value);
        }



        /// <summary>
        /// Defines the <see cref="IconBackground"/> property.
        /// </summary>
        public static readonly StyledProperty<IBrush> IconBackgroundProperty =
            AvaloniaProperty.Register<FloatingButtonBar, IBrush>(nameof(IconBackground));

        /// <summary>
        /// Gets or Sets the Background of the Icon
        /// </summary>
        public IBrush IconBackground
        {
            get => GetValue(IconBackgroundProperty);
            set => SetValue(IconBackgroundProperty, value);
        }


        public double OpenLength
        {
            get => GetValue(OpenLengthProperty);
            set => SetValue(OpenLengthProperty, value);
        }

        public readonly static StyledProperty<double> OpenLengthProperty =
            AvaloniaProperty.Register<FloatingButtonBar, double>(nameof(OpenLength));
    }

    public enum FloatingButtonBarExpandDirection
    {
        ToLeft,
        ToRight,
        ToTop,
        ToBottom
    }
}