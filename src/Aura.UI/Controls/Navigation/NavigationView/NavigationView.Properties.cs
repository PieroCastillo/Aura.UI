using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
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
        private bool _HeaderVisible;
        private AutoCompleteBox _autoCompleteBox;

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

        public readonly static StyledProperty<IDataTemplate> TitleTemplateProperty =
            AvaloniaProperty.Register<NavigationView, IDataTemplate>(nameof(TitleTemplate));

        public readonly static StyledProperty<IDataTemplate> SelectedContentTemplateProperty =
            AvaloniaProperty.Register<NavigationView, IDataTemplate>(nameof(SelectedContentTemplate));

        public readonly static StyledProperty<double> CompactPaneLengthProperty =
            AvaloniaProperty.Register<NavigationView, double>(nameof(CompactPaneLength));

        public readonly static StyledProperty<double> OpenPaneLengthProperty =
            AvaloniaProperty.Register<NavigationView, double>(nameof(OpenPaneLength));

        public readonly static StyledProperty<bool> IsOpenProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(IsOpen), true);

        public readonly static StyledProperty<bool> DynamicDisplayModeProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(DynamicDisplayMode), true);

        public readonly static StyledProperty<bool> HideTitleProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(HideTitle), false);

        public static readonly StyledProperty<SplitViewDisplayMode> DisplayModeProperty =
            AvaloniaProperty.Register<NavigationView, SplitViewDisplayMode>(nameof(DisplayMode), SplitViewDisplayMode.CompactInline);

        public readonly static StyledProperty<bool> AlwaysOpenProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(AlwaysOpen), false);

        public readonly static StyledProperty<bool> AutoCompleteBoxIsVisibleProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(AutoCompleteBoxIsVisible), true);

        public readonly static StyledProperty<ExperimentalAcrylicMaterial> PanelMaterialProperty =
            AvaloniaProperty.Register<NavigationView, ExperimentalAcrylicMaterial>(nameof(PanelMaterial));

        public readonly static DirectProperty<NavigationView, IEnumerable<string>> ItemsAsStringsProperty =
            AvaloniaProperty.RegisterDirect<NavigationView, IEnumerable<string>>(nameof(ItemsAsStrings), o => o.ItemsAsStrings);

        public readonly static StyledProperty<bool> IsFloatingHeaderProperty =
            AvaloniaProperty.Register<NavigationView, bool>(nameof(IsFloatingHeader));

        public readonly static DirectProperty<NavigationView, bool> HeaderVisibleProperty =
            AvaloniaProperty.RegisterDirect<NavigationView, bool>(nameof(HeaderVisible), o => o.HeaderVisible);

        public readonly static DirectProperty<NavigationView, AutoCompleteBox> AutoCompleteBoxProperty =
            AvaloniaProperty.RegisterDirect<NavigationView, AutoCompleteBox>(nameof(AutoCompleteBox), o => o.AutoCompleteBox, (o, v) => o.AutoCompleteBox = v);

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

        public ExperimentalAcrylicMaterial PanelMaterial
        {
            get => GetValue(PanelMaterialProperty);
            set => SetValue(PanelMaterialProperty, value);
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

        public IDataTemplate TitleTemplate
        {
            get => GetValue(TitleTemplateProperty);
            set => SetValue(TitleTemplateProperty, value);
        }


        public IDataTemplate SelectedContentTemplate
        {
            get => GetValue(SelectedContentTemplateProperty);
            set => SetValue(SelectedContentTemplateProperty, value);
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

        public bool IsFloatingHeader
        {
            get => GetValue(IsFloatingHeaderProperty);
            set => SetValue(IsFloatingHeaderProperty, value);
        }

        public bool HeaderVisible
        {
            get => _HeaderVisible;
            private set => SetAndRaise(HeaderVisibleProperty, ref _HeaderVisible, value);
        }

        public AutoCompleteBox AutoCompleteBox
        {
            get => _autoCompleteBox;
            set => SetAndRaise(AutoCompleteBoxProperty, ref _autoCompleteBox, value);
        }
    }
}