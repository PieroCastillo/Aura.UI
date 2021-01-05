using Avalonia;
using Avalonia.Media;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Navigation
{
    public partial class SuperNavigationView
    {
        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
        public readonly static StyledProperty<object> HeaderProperty =
            AvaloniaProperty.Register<SuperNavigationView, object>(nameof(Header), "Header");

        public IImage Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
        public readonly static StyledProperty<IImage> IconProperty =
            AvaloniaProperty.Register<SuperNavigationView, IImage>(
                nameof(Icon));

        private object _title;
        public object Title
        {
            get => _title;
            private set => SetAndRaise(TitleProperty, ref _title, value);
        }
        public readonly static DirectProperty<SuperNavigationView, object> TitleProperty =
            AvaloniaProperty.RegisterDirect<SuperNavigationView, object>(
                nameof(Title),
                o => o.Title);

        private object _selectedcontent;
        public object SelectedContent
        {
            get => _selectedcontent;
            private set => SetAndRaise(SelectedContentProperty, ref _selectedcontent, value);
        }

        public readonly static DirectProperty<SuperNavigationView, object> SelectedContentProperty =
            AvaloniaProperty.RegisterDirect<SuperNavigationView, object>(
                nameof(SelectedContent),
                o => o.SelectedContent);


        public double CompactPaneLength
        {
            get => GetValue(CompactPaneLengthProperty);
            set => SetValue(CompactPaneLengthProperty, value);
        }
        public readonly static StyledProperty<double> CompactPaneLengthProperty =
            AvaloniaProperty.Register<SuperNavigationView, double>(nameof(CompactPaneLength), 50);

        public double OpenPaneLength
        {
            get => GetValue(OpenPaneLengthProperty);
            set => SetValue(OpenPaneLengthProperty, value);
        }
        public readonly static StyledProperty<double> OpenPaneLengthProperty =
            AvaloniaProperty.Register<SuperNavigationView, double>(nameof(OpenPaneLength), 200);

        public bool IsOpen
        {
            get => GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }
        public readonly static StyledProperty<bool> IsOpenProperty =
            AvaloniaProperty.Register<SuperNavigationView, bool>(nameof(IsOpen), true);

        public bool HideTitle
        {
            get => GetValue(HideTitleProperty);
            set => SetValue(HideTitleProperty, value);
        }
        public readonly static StyledProperty<bool> HideTitleProperty =
            AvaloniaProperty.Register<SuperNavigationView, bool>(nameof(HideTitle), false);

        public bool AlwaysOpen
        {
            get => GetValue(AlwaysOpenProperty);
            set => SetValue(AlwaysOpenProperty, value);
        }
        public readonly static StyledProperty<bool> AlwaysOpenProperty =
            AvaloniaProperty.Register<SuperNavigationView, bool>(nameof(IsOpen), false);

        public SplitViewDisplayMode DisplayMode
        {
            get => GetValue(DisplayModeProperty);
            set => SetValue(DisplayModeProperty, value);
        }
        public static readonly StyledProperty<SplitViewDisplayMode> DisplayModeProperty =
            AvaloniaProperty.Register<SuperNavigationView, SplitViewDisplayMode>(nameof(DisplayMode), SplitViewDisplayMode.CompactInline);
    }
}
