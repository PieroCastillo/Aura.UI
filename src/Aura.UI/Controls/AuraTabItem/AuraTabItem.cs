using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
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
        /// <summary>
        /// This button close its AuraTabItem parent
        /// </summary>
        private Button CloseButton;

        public AuraTabItem()
        {
            Closing += OnClosing;
            //EnableDragDrop();
        }

        static AuraTabItem()
        {
            CanBeDraggedProperty.Changed.AddClassHandler<AuraTabItem>((x, e) => x.OnCanDraggablePropertyChanged(x, e));
            IsSelectedProperty.Changed.AddClassHandler<AuraTabItem>((x, e) => x.UpdatePseudoClass(x, e));
            RenderTransformProperty.Changed.Subscribe(onNext: e =>
            {
                if(e.Sender is AuraTabItem t)
                    t.InvalidateArrange();
            });
        }
        
        private void UpdatePseudoClass(AuraTabItem item, AvaloniaPropertyChangedEventArgs e)
        {
            if (item.IsSelected == false)
            {
                item.PseudoClasses.Remove(":dragging");
            }
        }

        internal void CloseCore()
        {
            var x = Parent as TabControl;
            x.CloseTab(this);
        }

        /// <summary>
        /// Close the Tab
        /// </summary>
        public void Close()
        {
            var e = new RoutedEventArgs(ClosingEvent);
            RaiseEvent(e);
            CloseCore();
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

            CloseButton = this.GetControl<Button>(e, "PART_CloseButton");
            if (IsClosable != false)
            {
                CloseButton.Click += CloseButton_Click;
            }
            else
            {
                CloseButton.IsVisible = false;
            }
        }

        private void CloseButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Close();
        }
    }
}