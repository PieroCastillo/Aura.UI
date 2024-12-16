using Aura.UI.Extensions;
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

            var miniButton = this.GetControl<Button>(e, "PART_MiniButton");
            
            if(miniButton is null)
                throw new Exception("MiniButton not found");
            
            miniButton.Click += (s, _) =>
            {
                var e = new RoutedEventArgs(MiniButtonClickEvent);
                RaiseEvent(e);
                e.Handled = true;
            };
        }

        public bool MiniButtonIsVisible
        {
            get => GetValue(MiniButtonIsVisibleProperty);
            set => SetValue(MiniButtonIsVisibleProperty, value);
        }

        public static readonly StyledProperty<bool> MiniButtonIsVisibleProperty =
            AvaloniaProperty.Register<RibbonGroup, bool>(nameof(MiniButtonIsVisible), true);

        public event EventHandler<RoutedEventArgs> MiniButtonClick
        {
            add => AddHandler(MiniButtonClickEvent, value);
            remove => RemoveHandler(MiniButtonClickEvent, value);
        }

        public static readonly RoutedEvent<RoutedEventArgs> MiniButtonClickEvent =
            RoutedEvent.Register<RibbonGroup, RoutedEventArgs>(nameof(MiniButtonClick), RoutingStrategies.Bubble);
    }
}