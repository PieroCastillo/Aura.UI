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

            this.Icon = new WindowIcon(new Bitmap(@"auraui-logov2.png"));

           #if DEBUG
            this.AttachDevTools();
            #endif
           
            tabc = this.Find<TabControl>("tabview");

            tabvw = this.Find<AuraTabView>("tabvw_");
            tabvw.ClickOnAddingButton += delegate(object? sender, RoutedEventArgs args)
            {
                AddTab();
            };

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
        }

        public void HandItems(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }
        
        public void OpenToolWindow(object sender, RoutedEventArgs e)
        {
            var win = new ToolWindowTest();
            win.ShowDialog(this);
        }

        private void AddTab()
        {
            var t__ = new TextBlock() { Text = "HeaderTest" + " " + $"{tabvw.ItemCount}", Background = Brushes.Transparent};
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
