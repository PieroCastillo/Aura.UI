using Aura.UI.Attributes;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Aura.UI.Controls
{
    [TemplatePart(Name = "PART_AdderButton", Type = typeof(Button))]
    public class AuraTabView : TabControl
    {
        public Button AdderButton;
        public AuraTabView()
        {
            this.InitializeComponent();
            AdderButton.Click += OnAdding;
        }

        protected void OnAdding(object sender, RoutedEventArgs e)
        {
            
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


    }
}
