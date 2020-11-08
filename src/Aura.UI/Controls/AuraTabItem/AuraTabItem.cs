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
using Aura.UI.Controls.Primitives;
using Avalonia.Threading;

namespace Aura.UI.Controls
{
    /// <summary>
    /// This tabitem is closable
    /// </summary>
    //[TemplatePart(Name = "PART_Thumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
    [InDevelopingFeatures(Name = "Dragging")]
    public partial class AuraTabItem : TabItem, ICustomCornerRadius
    {
        /// <summary>
        /// This button close its AuraTabItem parent
        /// </summary>
        Button CloseButton;
        Thumb thumb;
        public AuraTabItem()
        {
            this.Closing += new EventHandler<RoutedEventArgs>(OnClosing);
            //tab_parent = this.GetParentTOfLogical<AuraTabView>();
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
            // if (timetoelapse != null)
            // {
            //     timetoelapse = new TimeSpan(0, 0, 0, 0, 400);
            // }
            //
            // var timer = new DispatcherTimer();
            // timer.Interval = timetoelapse;
            // timer.Start();
            // timer.Tick += (s, e_) =>
            // {
               var e = new RoutedEventArgs(ClosingEvent);
                RaiseEvent(e);
                e.Handled = true;
                this.Close(null);
            // };
        }


        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            CloseButton = this.GetControl<Button>(e, "PART_CloseButton");
            if(this.IsClosable != false)
            {
                CloseButton.Click += CloseButton_Click;
            }
            else
            {
                CloseButton.IsVisible = false;
            }
            // set up tab dragging
            thumb = this.GetControl<Thumb>(e, "PART_TabThumb");
            this.PointerPressed += (s, e) =>
            {
                IsSelected = true;
            };
            //thumb.DragStarted += OnDragStarted;
            //thumb.DragDelta += OnDragDelta;
            //thumb.DragCompleted += OnDragCompleted;
        }
        private void CloseButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }



    }
}

