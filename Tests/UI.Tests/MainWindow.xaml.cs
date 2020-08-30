using Aura.UI.UIExtensions;
using Aura.UI.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Input;
using Microsoft.Toolkit.Extensions;
using System;
using UI.Tests.Views;

namespace UI.Tests
{
    public class MainWindow : ContentWindow
    {
        TabControl tabc;
        Button addbtn;
        Button cbtn;
        Button open_pages;
        Button open_tabbed;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            tabc = this.Find<TabControl>("tabview");
            addbtn = this.Find<Button>("btn");
            cbtn = this.Find<Button>("cbtn");
            open_pages = this.Find<Button>("open_pages");
            open_tabbed = this.Find<Button>("open_tabbedwin");

            addbtn.Click += Addbtn_Click;
            cbtn.Click += Cbtn_Click;
            open_pages.Click += Open_pages_Click;
            open_tabbed.Click += Open_tabbed_Click;

            EnableFeatures();
        }

        private void Open_tabbed_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var tabwin = new TabbedWindowTest();
            tabwin.ShowDialog(this);
        }

        private void Open_pages_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var pages_test = new PagesTest();
            pages_test.ShowDialog(this);
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
            //App.Selector.EnableThemes(this);
            App.Manager.EnableLanguages(this); 
        }
    }
}
