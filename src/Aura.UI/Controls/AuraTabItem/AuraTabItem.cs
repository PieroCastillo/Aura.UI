﻿using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;

namespace Aura.UI.Controls
{
    /// <summary>
    /// This tabitem is closable
    /// </summary>
    //[TemplatePart(Name = "PART_Thumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
    [PseudoClasses(":dragging", ":lockdrag")]
    public partial class AuraTabItem : TabItem, ICustomCornerRadius
    {
        /// <summary>
        /// This button close its AuraTabItem parent
        /// </summary>
        private Button CloseButton;

        public AuraTabItem()
        {
            this.Closing += OnClosing;

            EnableDragDrop();
            //tab_parent = this.GetParentTOfLogical<AuraTabView>();
        }

        static AuraTabItem()
        {
            CanBeDraggedProperty.Changed.AddClassHandler<AuraTabItem>((x, e) => x.OnCanDraggablePropertyChanged(x, e));
            IsSelectedProperty.Changed.AddClassHandler<AuraTabItem>((x, e) => x.UpdatePseudoClass(x, e));
        }

        private void UpdatePseudoClass(AuraTabItem item, AvaloniaPropertyChangedEventArgs e)
        {
            if (item.IsSelected == false)
            {
                item.PseudoClasses.Remove(":dragging");
            }
        }

        /// <summary>
        /// Close now the tab
        /// </summary>
        /// <param name="parameter">Does nothing, only for the requeriments of C# </param>
        internal void Close(object nevermatter)
        {
            var x = this.Parent as TabControl;
            x.CloseTab(this);
        }

        /// <summary>
        /// Close the Tab
        /// </summary>
        public void Close()
        {
            var e = new RoutedEventArgs(ClosingEvent);
            RaiseEvent(e);
            this.Close(null);
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

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            CloseButton = this.GetControl<Button>(e, "PART_CloseButton");
            if (this.IsClosable != false)
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
            this.Close();
        }
    }
}