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
using Aura.UI.Events;
using Aura.UI.UIExtensions;
using Aura.UI.Controls.Primitives;

namespace Aura.UI.Controls
{
    public class AuraTabItem : TabItem, IDraggable
    {
        Button CloseButton;
        public AuraTabItem()
        {
            this.InitializeComponent();
            this.Closing += new EventHandler<RoutedEventArgs>(OnClosing);
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        /// <summary>
        /// Close now the tab
        /// </summary>
        /// <param name="parameter">Does nothing, only for the requeriments of C# </param>
        protected void Close(object parameter)
        {
            var x = this.Parent as TabControl;
            x.CloseTab(this);
        }

        public void Close()
        {
             var e = new RoutedEventArgs(ClosingEvent);
            e.Handled = true;
            RaiseEvent(e);
            this.Close(null);
        }
        public void DragTo(IDraggableHost host)
        {
            
        }
        protected virtual void OnClosing(object sender, RoutedEventArgs e)
        {
            
        }

        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            base.OnTemplateApplied(e);

            CloseButton = this.GetControl<Button>(e, "PART_CloseButton");
            CloseButton.Click += CloseButton_Click; 
        }
        protected void OnDraggingStarted(object DraggedObject, DraggingStartedEventArgs draggingStartedEventArgs) { }
        protected void OnDraggingEnded(object DraggedObject, DraggingEndedEventArgs draggingEndedEventArgs) { }
        private void CloseButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }

        #region Events
        public event EventHandler<RoutedEventArgs> Closing
        {
            add { AddHandler(ClosingEvent, value); }
            remove { RemoveHandler(ClosingEvent, value); }
        }
        public static readonly RoutedEvent<RoutedEventArgs> ClosingEvent =
            RoutedEvent.Register<AuraTabItem, RoutedEventArgs>(nameof(Closing), RoutingStrategies.Bubble);

        public event EventHandler<DraggingStartedEventArgs> DraggingStarted
        {
            add { AddHandler(DraggingStartedEvent, value); }
            remove { RemoveHandler(DraggingEndedEvent, value); }
        }
        public static readonly RoutedEvent<DraggingStartedEventArgs> DraggingStartedEvent;

        public event EventHandler<DraggingEndedEventArgs> DraggingEnded
        {
            add { AddHandler(DraggingEndedEvent, value); }
            remove { RemoveHandler(DraggingEndedEvent, value); }
        }
        public static readonly RoutedEvent<DraggingEndedEventArgs> DraggingEndedEvent =
            RoutedEvent.Register<AuraTabItem, DraggingEndedEventArgs>(nameof(DraggingEnded), RoutingStrategies.Bubble);
        #endregion


    }
}

