using Avalonia;
using Avalonia.Media;
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

        private IImage _icon;
        public IImage Icon
        {
            get => _icon;
            set => SetAndRaise(IconProperty, ref _icon, value);
        }
        public readonly static DirectProperty<SuperNavigationView, IImage> IconProperty =
            AvaloniaProperty.RegisterDirect<SuperNavigationView, IImage>(
                nameof(Icon),
                o => o.Icon,
                (o,v) => o.Icon = v);

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
    }
}
