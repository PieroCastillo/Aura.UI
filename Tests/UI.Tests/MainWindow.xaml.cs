using Aura.UI.UIExtensions;
using Aura.UI.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.VisualTree;
using Avalonia.Layout;
using Avalonia.Controls.Notifications;
using Aura.CommonCore.IO;
using Aura.UI.Windows;
using Avalonia.Controls.Primitives;
using Aura.UI.Managers;

namespace UI.Tests
{
    public class MainWindow : TitleBarWindow
    {
        TabControl tabc;
        Button addbtn;
        Button cbtn;
        public MainWindow()
        {
            InitializeComponent();
            this.AttachDevTools();
           // App.Selector?.EnableThemes(this);
            tabc = this.Find<TabControl>("tabview");
            addbtn = this.Find<Button>("btn");
            cbtn = this.Find<Button>("cbtn");
            App.Selector.EnableThemes(this);
            App.Manager.EnableLanguages(this);
            addbtn.Click += Addbtn_Click;
            cbtn.Click += Cbtn_Click;
        }

        private void Cbtn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            tabc.CloseTab(tabc.ItemCount);
        }

        private void Addbtn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var a_C = "This Tab is Closable";
            tabc.AddTab(new AuraTabItem() { Header = "AuraTabItem", Content = a_C },true);
        } 

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
