using Aura.UI.Controls.Primitives;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    public class TileControl : HeaderedContentControl, ICustomCornerRadius, IMaterial
    {
        public object SecondaryHeader
        {
            get => GetValue(SecondaryHeaderProperty);
            set => SetValue(SecondaryHeaderProperty, value);
        }
        public static readonly StyledProperty<object> SecondaryHeaderProperty =
            AvaloniaProperty.Register<TileControl, object>(nameof(SecondaryHeader));

        public ITemplate SecondaryHeaderTemplate
        {
            get => GetValue(SecondaryHeaderTemplateProperty);
            set => SetValue(SecondaryHeaderTemplateProperty, value);
        }
        public static readonly StyledProperty<ITemplate> SecondaryHeaderTemplateProperty =
            AvaloniaProperty.Register<TileControl, ITemplate>(nameof(SecondaryHeaderTemplate));

        public IBrush SecondaryBackground
        {
            get => GetValue(SecondaryBackgroundProperty);
            set => SetValue(SecondaryBackgroundProperty, value);
        }
        public static readonly StyledProperty<IBrush> SecondaryBackgroundProperty =
            AvaloniaProperty.Register<TileControl, IBrush>(nameof(SecondaryBackground));

        public bool ScaleOnPointerOver
        {
            get => GetValue(ScaleOnPointerOverProperty);
            set => SetValue(ScaleOnPointerOverProperty, value);
        }
        public static readonly StyledProperty<bool> ScaleOnPointerOverProperty =
            AvaloniaProperty.Register<TileControl, bool>(nameof(ScaleOnPointerOver), true);

        public BoxShadows BoxShadow
        {
            get => GetValue(BoxShadowProperty);
            set => SetValue(BoxShadowProperty, value);
        }
        public static readonly StyledProperty<BoxShadows> BoxShadowProperty =
            AvaloniaProperty.Register<TileControl, BoxShadows>(nameof(BoxShadow));

        public BoxShadows InternalBoxShadow
        {
            get => GetValue(InternalBoxShadowProperty);
            set => SetValue(InternalBoxShadowProperty, value);
        }
        public static readonly StyledProperty<BoxShadows> InternalBoxShadowProperty =
            AvaloniaProperty.Register<TileControl, BoxShadows>(nameof(InternalBoxShadow));

        /// <summary>
        /// Defines the Material for the AcrylicBorder in the Template
        /// </summary>
        public ExperimentalAcrylicMaterial Material
        {
            get { return GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }
        public static readonly StyledProperty<ExperimentalAcrylicMaterial> MaterialProperty =
            AvaloniaProperty.Register<TileControl, ExperimentalAcrylicMaterial>(nameof(Material));
        /// <summary>
        /// Defines if the Material can be visible
        /// </summary>
        public bool MaterialIsVisible
        {
            get { return GetValue(MaterialIsVisibleProperty); }
            set { SetValue(MaterialIsVisibleProperty, value); }
        }
        public static readonly StyledProperty<bool> MaterialIsVisibleProperty =
             AvaloniaProperty.Register<TileControl, bool>(nameof(MaterialIsVisible), true);

        /// <summary>
        /// Defines the CornerRadius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly StyledProperty<CornerRadius> CornerRadiusProperty =
            AvaloniaProperty.Register<TileControl, CornerRadius>(nameof(CornerRadius), new CornerRadius(7));

        public CornerRadius InternalCornerRadius
        {
            get { return GetValue(InternalCornerRadiusProperty); }
            set { SetValue(InternalCornerRadiusProperty, value); }
        }
        public static readonly StyledProperty<CornerRadius> InternalCornerRadiusProperty =
            AvaloniaProperty.Register<TileControl, CornerRadius>(nameof(InternalCornerRadius), new CornerRadius(7));

        public Thickness InternalPadding
        {
            get { return GetValue(InternalPaddingProperty); }
            set { SetValue(InternalPaddingProperty, value); }
        }
        public static readonly StyledProperty<Thickness> InternalPaddingProperty=
            AvaloniaProperty.Register<TileControl, Thickness>(nameof(InternalPadding));
    }
}
