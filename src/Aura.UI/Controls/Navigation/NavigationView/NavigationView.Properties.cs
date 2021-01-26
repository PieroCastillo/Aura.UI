using Avalonia;
using Avalonia.Media;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Collections;
using System.Diagnostics;
using System.Linq;

namespace Aura.UI.Controls.Navigation
{
    public partial class NavigationView
    {
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
        public readonly static StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<NavigationView, object>(nameof(Header), "Header");

        public IImage Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        public readonly static StyledProperty<IImage> IconProperty =
            AvaloniaProperty.Register<NavigationView, IImage>(
                nameof(Icon));

        private object _title;
        public object Title
        {
            get => _title;
            private set => SetAndRaise(TitleProperty, ref _title, value);
        }
        public readonly static DirectProperty<NavigationView, object> TitleProperty =
            AvaloniaProperty.RegisterDirect<NavigationView, object>(
                nameof(Title),
                o => o.Title);

        private object _selectedcontent;
        public object SelectedContent
        {
            get => _selectedcontent;
            private set => SetAndRaise(SelectedContentProperty, ref _selectedcontent, value);
        }

        public readonly static DirectProperty<NavigationView, object> SelectedContentProperty =
            AvaloniaProperty.RegisterDirect<NavigationView, object>(
                nameof(SelectedContent),
                o => o.SelectedContent);


        public double CompactPaneLength
        {
            get => GetValue(CompactPaneLengthProperty);
            set => SetValue(CompactPaneLengthProperty, value);
        }
        public readonly static StyledProperty<double> CompactPaneLengthProperty =
            AvaloniaProperty.Register<NavigationView, double>(nameof(CompactPaneLength), 50);

        public double OpenPaneLength
        {
            get => GetValue(OpenPaneLengthProperty);
            set => SetValue(OpenPaneLengthProperty, value);
        }
        public readonly static StyledProperty<double> OpenPaneLengthProperty =
            AvaloniaProperty.Register<NavigationView, double>(nameof(OpenPaneLength), 200);

        public bool IsOpen
        {
            get => GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }
        public readonly static StyledProperty<bool> IsOpenProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(IsOpen), true);

        public bool HideTitle
        {
            get => GetValue(HideTitleProperty);
            set => SetValue(HideTitleProperty, value);
        }
        public readonly static StyledProperty<bool> HideTitleProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(HideTitle), false);

        public bool AlwaysOpen
        {
            get => GetValue(AlwaysOpenProperty);
            set => SetValue(AlwaysOpenProperty, value);
        }
        public readonly static StyledProperty<bool> AlwaysOpenProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(IsOpen), false);

        public SplitViewDisplayMode DisplayMode
        {
            get => GetValue(DisplayModeProperty);
            set => SetValue(DisplayModeProperty, value);
        }
        public static readonly StyledProperty<SplitViewDisplayMode> DisplayModeProperty =
            AvaloniaProperty.Register<NavigationView, SplitViewDisplayMode>(nameof(DisplayMode), SplitViewDisplayMode.CompactInline);

        //private AutoCompleteBox _completeBox;
        //public AutoCompleteBox CompleteBox
        //{
        //    get => _completeBox;
        //    set => SetAndRaise(CompleteBoxProperty, ref _completeBox, value);
        //}
        //public readonly static DirectProperty<NavigationView, AutoCompleteBox> CompleteBoxProperty =
        //    AvaloniaProperty.RegisterDirect<NavigationView, AutoCompleteBox>(nameof(CompleteBox),
        //                                                                     o => o.CompleteBox,
        //                                                                     (o, v) => o.CompleteBox = v);

        public bool AutoCompleteBoxIsVisible
        {
            get => GetValue(AutoCompleteBoxIsVisibleProperty);
            set => SetValue(AutoCompleteBoxIsVisibleProperty, value);
        }
        public readonly static StyledProperty<bool> AutoCompleteBoxIsVisibleProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(AutoCompleteBoxIsVisible), true);

        private IEnumerable<string> _itemsasstrings;
        public IEnumerable<string> ItemsAsStrings
        {
            get => _itemsasstrings;
            private set
            {
                Debug.WriteLine($"{value.ToList().Count()}");
                SetAndRaise(ItemsAsStringsProperty, ref _itemsasstrings, value);
            }
        }
        public readonly static DirectProperty<NavigationView, IEnumerable<string>> ItemsAsStringsProperty =
            AvaloniaProperty.RegisterDirect<NavigationView, IEnumerable<string>>(nameof(ItemsAsStrings),
                                                                                 o => o.ItemsAsStrings);
    }
}
