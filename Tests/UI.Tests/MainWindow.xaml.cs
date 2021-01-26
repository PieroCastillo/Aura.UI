﻿using Aura.UI.UIExtensions;
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
using Aura.UI.Services;

namespace UI.Tests
{
    public class MainWindow : Window
    {
        TabControl tabc;
        AuraTabView tabvw;
        Button addbtn;
        Button cbtn;
        Button open_pages;
        Border border_bg;
        Border drag;
        public MainWindow()
        {
            InitializeComponent();

            //this.Icon = new WindowIcon(new Bitmap("./auraui-logov2.png"));

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
            border_bg = this.Find<Border>("border_bg");
            drag = this.Find<Border>("drag_b");

            addbtn.Click += Addbtn_Click;
            cbtn.Click += Cbtn_Click;
            open_pages.Click += Open_pages_Click;

            drag.PointerPressed += Drag_PointerPressed;

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

        public void OpenDefaultNavigationView(object sender, RoutedEventArgs e)
        {
            var win = new NavigationViewWindowDefault();
            win.ShowDialog(this);
        }

        public void OpenCustomNavigationView(object sender, RoutedEventArgs e)
        {
            var win = new CustomNavigationViewWindow();
        }

        private void Open_pages_Click(object sender, RoutedEventArgs e)
        {
            var pages_test = new PagesTest();
            pages_test.ShowDialog(this);
        }

        public void OpenContentDialog(object sender, RoutedEventArgs e)
        {
            this.NewContentDialog("I'm a Content Dialog :D",
                                  (s, e) => { Debug.WriteLine("Ok Button Pressed"); },
                                  (s, e) => { Debug.WriteLine("Cancel Button Pressed"); }, 
                                  "Ok",
                                  "Cancel");
        }

        public void OpenMessageDialog(object sender, RoutedEventArgs e)
        {
            this.NewMessageDialog("I'm a MessageDialog :D", 
                                    "Use me when you just show info or \n un-interactive messages", 
                                    (s,e) => { Debug.WriteLine("MessageDialog Closed"); });
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
