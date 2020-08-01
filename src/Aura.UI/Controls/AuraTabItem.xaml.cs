using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;
using Aura.UI.UIExtensions;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Avalonia.Controls.Primitives;

namespace Aura.UI.Controls
{
    public class AuraTabItem : TabItem
    {
        Button CloseButton;
        public AuraTabItem()
        {
            this.InitializeComponent();
            
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
    }
}

