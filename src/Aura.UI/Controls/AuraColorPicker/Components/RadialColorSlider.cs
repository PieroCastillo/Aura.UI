using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Metadata;

namespace Aura.UI.Controls.Components
{
    public class RadialColorSlider : RadialSlider, ILogical
    {
        static RadialColorSlider()
        {
            MinimumProperty.OverrideMetadata<RadialColorSlider>(new DirectPropertyMetadata<double>(0));
            MaximumProperty.OverrideMetadata<RadialColorSlider>(new DirectPropertyMetadata<double>(360));
        }

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);

            if (Content is Control c)
                c.InvalidateMeasure();
        }

        [Content]
        public object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }
        public static readonly StyledProperty<object> ContentProperty =
            AvaloniaProperty.Register<RadialColorSlider, object>(nameof(Content));
    }
}
