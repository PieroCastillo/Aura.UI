﻿using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aura.UI.Gallery.ViewModels
{
    public class MainViewViewModel : ViewModelBase
    {
        public MainViewViewModel()
        {
            Descriptions = new();
            Titles = new();
        }

        private void AddNavItems()
        {

        }

        public Titles Titles { get; }
        public Descriptions Descriptions { get; }
        public IReadOnlyList<NavigationViewItemViewModel> NavItems
        {
            get;
            set;
        }
    }

    public class Descriptions
    {
        public string FloattingButtonBar => "A Bar that contains Buttons and can be opened and closed.";
        public string ModernSlider => "Slider with AcrylicStyle.";
        public string ProgressRing => "Shows a Progress or a value of an Application.";
        public string GroupBox => "Can organize Controls, has a Title and a Content.";
        public string CardCollection => "Organizes Controls using Cards.";
        public string AuraTabView => "A TabControl powered-up, and its Tabs can be dragged.";
        public string NavigationView => "Common layout for TopLevel User Interfaces.";
        public string Ribbon => "Organizes Controls by Tabs.";
        public string ContentDialog => "A Dialog with Content, has two buttons.";
        public string MessageDialog => "A Closable-Dialog, recommended to show information to the user.";
        public string RadialSlider => "Selects a numeric value on a circular display.";
        public string BlurryImage => "A Image with a nice Blur.";
        public string Badge => "Badge control displays a Badge overlay its content.";
    }

    public class Titles
    {
        public string FloattingButtonBar => GetTitle();
        public string ModernSlider => GetTitle();
        public string ProgressRing => GetTitle();
        public string GroupBox => GetTitle();
        public string CardCollection => GetTitle();
        public string AuraTabView => GetTitle();
        public string NavigationView => GetTitle();
        public string Ribbon => GetTitle();
        public string ContentDialog => GetTitle();
        public string MessageDialog => GetTitle();
        public string BlurryImage => GetTitle();
        public string MVVM => GetTitle();
        public string Badge => GetTitle();
        public string RadialSlider => GetTitle();

        public string GetTitle([CallerMemberName] string title = "title") => title;
    }

    public class NavigationViewItemViewModel
    {
        public IImage Icon
        {
            get;
            set;
        }
        public object Header
        {
            get;
            set;
        }

        public object Title
        {
            get;
            set;
        }

        public object Content
        {
            get;
            set;
        }

        public IReadOnlyList<NavigationViewItemViewModel> NavItems
        {
            get;
            set;
        }
    }
}
