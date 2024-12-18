using Aura.UI.Controls.Primitives;
using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using System;

namespace Aura.UI.Controls
{
    /// <summary>
    ///A Closable & Draggable TabItem
    /// </summary>
    [PseudoClasses(":dragging", ":lockdrag")]
    public partial class AuraTabItem : TabItem, ICustomCornerRadius
    {
        private Button? CloseButton;

        public AuraTabItem()
        {
            Closing += OnClosing;
        }

        static AuraTabItem()
        {
            CanBeDraggedProperty.Changed.AddClassHandler<AuraTabItem>((x, e) => x.OnCanDraggablePropertyChanged(x, e));
            IsSelectedProperty.Changed.AddClassHandler<AuraTabItem>((x, e) => x.UpdatePseudoClass(x, e));
            IsClosableProperty.Changed.Subscribe(e =>
            {
                if (e.Sender is AuraTabItem a && a.CloseButton != null)
                {
                    a.CloseButton.IsVisible = a.IsClosable;
                }
            });
        }

        private void UpdatePseudoClass(AuraTabItem item, AvaloniaPropertyChangedEventArgs e)
        {
            if (item.IsSelected == false)
            {
                item.PseudoClasses.Remove(":dragging");
            }
        }

        internal bool CloseCore()
        {
            if (Parent is TabControl x)
            {
                try
                {
                    x.CloseTab(this);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Close the Tab
        /// </summary>
        public bool Close()
        {
            RaiseEvent(new RoutedEventArgs(ClosingEvent));
            return CloseCore();
        }

        protected void OnCanDraggablePropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (CanBeDragged == true)
            {
                PseudoClasses.Add(":lockdrag");
            }
            else if (CanBeDragged == false)
            {
                PseudoClasses.Remove(":lockdrag");
            }
        }

        /// <inheritdoc/>
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            
            var closeButton = this.GetControl<Button>(e, "PART_CloseButton");

            CloseButton = closeButton ?? throw new Exception("CloseButton not found");
            
            if (IsClosable != false)
            {
                CloseButton.Click += CloseButton_Click;
            }
            else
            {
                CloseButton.IsVisible = false;
            }
        }

        private void CloseButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(CloseButtonClickEvent));
            Close();
        }
    }
}