using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;
using Aura.UI.UIExtensions;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using Avalonia.Input;
using System.Drawing.Printing;
using Aura.UI.Events;

namespace Aura.UI.Controls
{
    public class AuraTabItem : TabItem
    {
        Button CloseButton;
        public AuraTabItem()
        {
            this.InitializeComponent();
            var data_DStd = new DragStartedEventArgs();
            try
            {
               
                data_DStd.IsCompleted = true;
                data_DStd.IsToOut = true;
                OnDragStarted(data_DStd);
            }
            catch
            {
                data_DStd.IsCompleted = false;
                data_DStd.IsToOut = true;
                OnDragStarted(data_DStd);
            }
        }

        public event EventHandler<DragStartedEventArgs> DragStarted;

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
            this.OnClosing();
            this.Close(null);
        }

        public virtual void OnClosing()
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

        protected virtual void OnDragStarted(DragStartedEventArgs e)
        {
            DragStarted?.Invoke(this, e);
        }
    }
}

