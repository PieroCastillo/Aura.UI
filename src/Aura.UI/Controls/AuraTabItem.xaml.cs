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

namespace Aura.UI.Controls
{
    [InDevelopingFeatures(Name = "Dragging")]
    public class AuraTabItem : TabItem
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
        internal void Close(object nevermatter) 
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
        protected virtual void OnClosing(object sender, RoutedEventArgs e)
        {
            
        }

        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            base.OnTemplateApplied(e);

            CloseButton = this.GetControl<Button>(e, "PART_CloseButton");
            CloseButton.Click += CloseButton_Click; 
        }
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
        #endregion


    }
}

