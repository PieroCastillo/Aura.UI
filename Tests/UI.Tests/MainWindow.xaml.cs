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

namespace UI.Tests
{
    public class MainWindow : TitleBarWindow
    {
        TabControl tabc;
        Button addbtn;
        Button cbtn;
        WindowNotificationManager notificationManager;
        ToggleButton toggle_language;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif 
            App.Selector?.EnableThemes(this);
            tabc = this.Find<TabControl>("tabview");
            addbtn = this.Find<Button>("btn");
            cbtn = this.Find<Button>("cbtn");
            addbtn.Click += Addbtn_Click;
            cbtn.Click += Cbtn_Click;
            notificationManager = new WindowNotificationManager(this) { Position = NotificationPosition.BottomRight, MaxItems = 3 };
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
