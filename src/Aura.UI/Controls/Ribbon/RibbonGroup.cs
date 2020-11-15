using Aura.UI.Attributes;
using Aura.UI.Extensions;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Interactivity;

namespace Aura.UI.Controls.Ribbon
{
    /// <summary>
    /// This control is to organize the Ribbon
    /// </summary>
    [TemplatePart(Name = "PART_MiniButton", Type = typeof(MaterialButton))]
    public class RibbonGroup : HeaderedContentControl
    {
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            MiniButton = this.GetControl<MaterialButton>(e, "PART_MiniButton");
            MiniButton.Click += (s, _) =>
            {
                var e = new RoutedEventArgs(MiniButtonClickEvent);
                RaiseEvent(e);
                e.Handled = true;
            };
        }

        //[Obsolete("Use the event, maybe this property will be deleted")]
        protected MaterialButton MiniButton
        {
            get { return GetValue(MiniButtonProperty); }
            set { SetValue(MiniButtonProperty, value); }
        }
        public static readonly StyledProperty<MaterialButton> MiniButtonProperty =
            AvaloniaProperty.Register<RibbonGroup, MaterialButton>(nameof(MiniButton), new MaterialButton());

        public object MiniButtonContent
        {
            get { return GetValue(MiniButtonContentProperty); }
            set { SetValue(MiniButtonContentProperty, value); }
        }
        public static readonly StyledProperty<object> MiniButtonContentProperty =
            AvaloniaProperty.Register<RibbonGroup, object>(nameof(MiniButtonContent),"L");

        public event EventHandler<RoutedEventArgs> MiniButtonClick
        {
            add => AddHandler(MiniButtonClickEvent, value);
            remove => RemoveHandler(MiniButtonClickEvent, value);
        }
        public static readonly RoutedEvent<RoutedEventArgs> MiniButtonClickEvent = 
            RoutedEvent.Register<RibbonGroup, RoutedEventArgs>(nameof(MiniButtonClick), RoutingStrategies.Bubble);
    }
}
