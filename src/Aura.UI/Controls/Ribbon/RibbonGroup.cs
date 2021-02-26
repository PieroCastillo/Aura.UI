using Aura.UI.Attributes;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using System;

namespace Aura.UI.Controls.Ribbon
{
    /// <summary>
    /// This control is to organize the Ribbon
    /// </summary>
    public class RibbonGroup : HeaderedContentControl
    {
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            var MiniButton = this.GetControl<Button>(e, "PART_MiniButton");
            MiniButton.Click += (s, _) =>
            {
                var e = new RoutedEventArgs(MiniButtonClickEvent);
                RaiseEvent(e);
                e.Handled = true;
            };
        }

        public object MiniButtonContent
        {
            get => GetValue(MiniButtonContentProperty);
            set => SetValue(MiniButtonContentProperty, value);
        }

        public static readonly StyledProperty<object> MiniButtonContentProperty =
            AvaloniaProperty.Register<RibbonGroup, object>(nameof(MiniButtonContent), "L");

        public event EventHandler<RoutedEventArgs> MiniButtonClick
        {
            add => AddHandler(MiniButtonClickEvent, value);
            remove => RemoveHandler(MiniButtonClickEvent, value);
        }

        public static readonly RoutedEvent<RoutedEventArgs> MiniButtonClickEvent =
            RoutedEvent.Register<RibbonGroup, RoutedEventArgs>(nameof(MiniButtonClick), RoutingStrategies.Bubble);
    }
}