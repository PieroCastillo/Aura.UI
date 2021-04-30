using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Aura.UI.Controls.Navigation
{
    public partial class NavigationView
    {

        private object _title;
        private object _selectedcontent;
        private IEnumerable<string> _itemsasstrings;
        //private bool _canGoBack;
        //private bool _canGoForward;

        public readonly static StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<NavigationView, object>(nameof(Header), "Header");

        public readonly static StyledProperty<IImage> IconProperty =
            AvaloniaProperty.Register<NavigationView, IImage>(
                nameof(Icon));

        public readonly static DirectProperty<NavigationView, object> TitleProperty =
            AvaloniaProperty.RegisterDirect<NavigationView, object>(
                nameof(Title),
                o => o.Title);
        public readonly static DirectProperty<NavigationView, object> SelectedContentProperty =
            AvaloniaProperty.RegisterDirect<NavigationView, object>(
                nameof(SelectedContent),
                o => o.SelectedContent);
        public readonly static StyledProperty<double> CompactPaneLengthProperty =
            AvaloniaProperty.Register<NavigationView, double>(nameof(CompactPaneLength), 50);
        public readonly static StyledProperty<double> OpenPaneLengthProperty =
            AvaloniaProperty.Register<NavigationView, double>(nameof(OpenPaneLength), 200);
        public readonly static StyledProperty<bool> IsOpenProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(IsOpen), true);

        public readonly static StyledProperty<bool> DynamicDisplayModeProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(DynamicDisplayMode), true);

        public readonly static StyledProperty<bool> HideTitleProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(HideTitle), false);
        public static readonly StyledProperty<SplitViewDisplayMode> DisplayModeProperty =
            AvaloniaProperty.Register<NavigationView, SplitViewDisplayMode>(nameof(DisplayMode), SplitViewDisplayMode.CompactInline);
        public readonly static StyledProperty<bool> AlwaysOpenProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(IsOpen), false);
        public readonly static StyledProperty<bool> AutoCompleteBoxIsVisibleProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(AutoCompleteBoxIsVisible), true);
        public readonly static DirectProperty<NavigationView, IEnumerable<string>> ItemsAsStringsProperty =
            AvaloniaProperty.RegisterDirect<NavigationView, IEnumerable<string>>(nameof(ItemsAsStrings),
                                                                                 o => o.ItemsAsStrings);
        //public readonly static DirectProperty<NavigationView, bool> CanGoBackProperty =
        //    AvaloniaProperty.RegisterDirect<NavigationView, bool>(nameof(CanGoBack),
        //                                                          o => o.CanGoBack, unsetValue: false);
        //public readonly static DirectProperty<NavigationView, bool> CanGoForwardProperty =
        //    AvaloniaProperty.RegisterDirect<NavigationView, bool>(nameof(CanGoForward),
        //                                                          o => o.CanGoForward, unsetValue: false);
        //public readonly static StyledProperty<bool> ShowGoForwardProperty =
        //    AvaloniaProperty.Register<NavigationView, bool>(nameof(ShowGoBack), true);
        //public readonly static StyledProperty<bool> ShowGoBackProperty =
        //    AvaloniaProperty.Register<NavigationView, bool>(nameof(ShowGoBack), true);


        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public IImage Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }


        public object Title
        {
            get => _title;
            private set => SetAndRaise(TitleProperty, ref _title, value);
        }


        public object SelectedContent
        {
            get => _selectedcontent;
            private set => SetAndRaise(SelectedContentProperty, ref _selectedcontent, value);
        }


        public double CompactPaneLength
        {
            get => GetValue(CompactPaneLengthProperty);
            set => SetValue(CompactPaneLengthProperty, value);
        }


        public double OpenPaneLength
        {
            get => GetValue(OpenPaneLengthProperty);
            set => SetValue(OpenPaneLengthProperty, value);
        }


        public bool IsOpen
        {
            get => GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }


        public bool HideTitle
        {
            get => GetValue(HideTitleProperty);
            set => SetValue(HideTitleProperty, value);
        }

        public bool AlwaysOpen
        {
            get => GetValue(AlwaysOpenProperty);
            set => SetValue(AlwaysOpenProperty, value);
        }


        public SplitViewDisplayMode DisplayMode
        {
            get => GetValue(DisplayModeProperty);
            set => SetValue(DisplayModeProperty, value);
        }


        public bool AutoCompleteBoxIsVisible
        {
            get => GetValue(AutoCompleteBoxIsVisibleProperty);
            set => SetValue(AutoCompleteBoxIsVisibleProperty, value);
        }


        public IEnumerable<string> ItemsAsStrings
        {
            get => _itemsasstrings;
            private set
            {
                Debug.WriteLine($"{value.ToList().Count()}");
                SetAndRaise(ItemsAsStringsProperty, ref _itemsasstrings, value);
            }
        }

        public bool DynamicDisplayMode
        {
            get => GetValue(DynamicDisplayModeProperty);
            set => SetValue(DynamicDisplayModeProperty, value);
        }

        //public bool CanGoBack
        //{
        //    get => _canGoBack;
        //    private set => SetAndRaise(CanGoBackProperty, ref _canGoBack, value);
        //}

        //public bool CanGoForward
        //{
        //    get => _canGoForward;
        //    private set => SetAndRaise(CanGoForwardProperty, ref _canGoForward, value);
        //}

        //public bool ShowGoForward
        //{
        //    get => GetValue(ShowGoForwardProperty);
        //    set => SetValue(ShowGoForwardProperty, value);
        //}

        //public bool ShowGoBack
        //{
        //    get => GetValue(ShowGoBackProperty);
        //    set => SetValue(ShowGoBackProperty, value);
        //}

    }
}