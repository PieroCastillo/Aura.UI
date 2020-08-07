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

namespace UI.Tests
{
    public class MainWindow : Window
    {
        TabControl tabc;
        Button addbtn;
        Button cbtn;
        WindowNotificationManager notificationManager;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
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
            tabc.VisualToPDF("test");
        }

        private void Addbtn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            tabc.AddTab(new AuraTabItem() { Header = "WOW!" , Content = new ColorPickerButton() { Height = 20 , Width = 20 } },true);

             notificationManager.Show(new Notification("Notification", "That Tab has been added", NotificationType.Information));
        } 

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
