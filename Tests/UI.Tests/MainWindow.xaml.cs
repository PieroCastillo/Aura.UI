using Aura.UI.UIExtensions;
using Aura.UI.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.VisualTree;
using Avalonia.Layout;
using Avalonia.Controls.Notifications;
using Aura.UI.Windows;
using Avalonia.Controls.Primitives;
using Aura.UI.Managers;

namespace UI.Tests
{
    public class MainWindow : Window
    {
        TabControl tabc;
        Button addbtn;
        Button cbtn;
        Button NextPage_btn;
        Button PreviousPage_btn; 
        PagesView pagesvw;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            tabc = this.Find<TabControl>("tabview");
            addbtn = this.Find<Button>("btn");
            cbtn = this.Find<Button>("cbtn");
            PreviousPage_btn = this.Find<Button>("P_pages");
            NextPage_btn = this.Find<Button>("N_pages");
            pagesvw = this.Find<PagesView>("PagesVW");

            addbtn.Click += Addbtn_Click;
            cbtn.Click += Cbtn_Click;

            PreviousPage_btn.Click += PreviousPage_btn_Click;
            NextPage_btn.Click += NextPage_btn_Click;

            EnableFeatures();
        }

        private void NextPage_btn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            pagesvw.Next();
        }

        private void PreviousPage_btn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            pagesvw.Previous();
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

        private void EnableFeatures()
        {
            App.Manager.EnableLanguages(this);
            App.Selector.EnableThemes(this);
        }
    }
}
