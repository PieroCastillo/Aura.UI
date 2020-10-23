using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using Avalonia.Input;
using Avalonia.Interactivity;
using Aura.UI.UIExtensions;
using Aura.UI.Attributes;
using System.Diagnostics;

namespace Aura.UI.Controls
{
    /// <summary>
    /// This tabitem is closable
    /// </summary>
    //[TemplatePart(Name = "PART_Thumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
    [InDevelopingFeatures(Name = "Dragging")]
    public class AuraTabItem : TabItem
    {
        /// <summary>
        /// This button close its AuraTabItem parent
        /// </summary>
        Button CloseButton;
        public AuraTabItem()
        {
            this.Closing += new EventHandler<RoutedEventArgs>(OnClosing);
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
            e.Handled = true;
            RaiseEvent(e);
            this.Close(null);
        }
        /// <summary>
        /// Is called before <see cref="AuraTabItem.Closing"/> occurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnClosing(object sender, RoutedEventArgs e)
        {
            
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            CloseButton = this.GetControl<Button>(e, "PART_CloseButton");
            //thumb = this.GetControl<Thumb>(e, "PART_Thumb");
            if(this.IsClosable != false)
            {
                CloseButton.Click += CloseButton_Click;
            }
            else
            {
                CloseButton.IsVisible = false;
            }

            //set thumb configuration

            //thumb.DragStarted += Thumb_DragStarted;
            //thumb.DragDelta += Thumb_DragDelta;
            //thumb.DragCompleted += Thumb_DragCompleted;
        }

        //double localX = -1;
        //double localY = -1;
        //protected virtual void Thumb_DragStarted(object sender, VectorEventArgs e)
        //{
        //    Debug.WriteLine("Drag Started");

        //    localX = e.Vector.X;
        //    localY = e.Vector.Y;
        //}
        //protected virtual void Thumb_DragDelta(object sender, VectorEventArgs e)
        //{
        //    Debug.WriteLine("Drag is happening");
        //}
        //protected virtual void Thumb_DragCompleted(object sender, VectorEventArgs e)
        //{
        //    Debug.WriteLine("Drag completed");
        //}


        private void CloseButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This property defines if the AuraTabItem can be closed
        /// </summary>
        public bool IsClosable
        {
            get { return GetValue(IsClosableProperty); }
            set { SetValue(IsClosableProperty, value); }
        }
        public static readonly StyledProperty<bool> IsClosableProperty =
            AvaloniaProperty.Register<AuraTabItem, bool>(nameof(IsClosable), true);

        //public bool CanBeDragged { get; }
        //public static readonly StyledProperty<bool> CanBeDraggedProperty =
        //    AvaloniaProperty.Register<AuraTabItem, bool>(nameof(CanBeDragged), true);

        #region Events
        public event EventHandler<RoutedEventArgs> Closing
        {
            add { AddHandler(ClosingEvent, value); }
            remove { RemoveHandler(ClosingEvent, value); }
        }
        public static readonly RoutedEvent<RoutedEventArgs> ClosingEvent =
            RoutedEvent.Register<AuraTabItem, RoutedEventArgs>(nameof(Closing), RoutingStrategies.Bubble);
        #endregion

    }
}

