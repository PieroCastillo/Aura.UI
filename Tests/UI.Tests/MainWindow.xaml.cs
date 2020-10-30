using Aura.UI.UIExtensions;
using Aura.UI.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Input;
using Microsoft.Toolkit.Extensions;
using System;
using UI.Tests.Views;
using Avalonia.Controls.Primitives;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Avalonia.Interactivity;
using System.IO;
using System.Diagnostics;
using MessageBox.Avalonia;

namespace UI.Tests
{
    public class MainWindow : ContentWindow
    {
        TabControl tabc;
        AuraTabView tabvw;
        Button addbtn;
        Button cbtn;
        Button open_pages;
        ColorPickerButton pickerButton;
        Border border_bg;
        Border drag;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
           //this.Icon = new WindowIcon(new Bitmap(@"auraui-logov2.png"));

            tabc = this.Find<TabControl>("tabview");

            tabvw = this.Find<AuraTabView>("tabvw_");
            tabvw.AddActionToAdderButton(AddTab);

            addbtn = this.Find<Button>("btn");
            cbtn = this.Find<Button>("cbtn");
            open_pages = this.Find<Button>("open_pages");
            pickerButton = this.Find<ColorPickerButton>("CP_btn");
            border_bg = this.Find<Border>("border_bg");
            drag = this.Find<Border>("drag_b");

            addbtn.Click += Addbtn_Click;
            cbtn.Click += Cbtn_Click;
            open_pages.Click += Open_pages_Click;

            drag.PointerPressed += Drag_PointerPressed;

            border_bg.Background = pickerButton.Background;

            var xdd = new AuraTabItem();
            //EnableFeatures();
        }

        public void OpenTabbedWindow(object sender, RoutedEventArgs e)
        {
            var win = new TabbedWindowTest();
            win.Show();
        }

        public void OpenToolWindow(object sender, RoutedEventArgs e)
        {
            var win = new ToolWindowTest();
            win.ShowDialog(this);
        }

        private void AddTab()
        {
            var t__ = new TextBlock() { Text = "HeaderTest" };
            var t = new AuraTabItem() { Header = t__ , Content = "ContentTest" };

            t.Closing += (s, e) =>
            {
                Debug.WriteLine("The Tab has been closed");
                //CloseMessage();
            };
            tabvw.AddTab(t, true);
        }

        public void CloseMessage()
        {
            var m = MessageBoxManager.GetMessageBoxStandardWindow("Close Event", "The tabitem has been closed correctly");
             m.Show();
        }

        private void Drag_PointerPressed(object sender, PointerPressedEventArgs e)
        {
            this.BeginMoveDrag(e);
        }

        public void OpenDefaultNavigationView(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var win = new NavigationViewWindowDefault();
            win.ShowDialog(this);
        }

        public void OpenCustomNavigationView(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var win = new CustomNavigationViewWindow();
            win.ShowDialog(this);
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
            //App.Manager.EnableLanguages(this); 
        }
    }
}
