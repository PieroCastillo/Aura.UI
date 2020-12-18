using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Navigation
{
    public partial class SuperNavigationViewItem : TreeViewItem, IHeadered
    {
        private object _content = "Content";
        public object Content
        {
            get => _content;
            set => SetAndRaise(ContentProperty, ref _content, value);
        }
        public static readonly DirectProperty<SuperNavigationViewItem, object> ContentProperty =
            AvaloniaProperty.RegisterDirect<SuperNavigationViewItem, object>(
                nameof(Content),
                o => o.Content,
                (o,v) => o.Content = v);

        private IImage _icon;
        public IImage Icon
        {
            get => _icon;
            set => SetAndRaise(IconProperty, ref _icon, value);
        }
        public readonly static DirectProperty<SuperNavigationViewItem, IImage> IconProperty =
            AvaloniaProperty.RegisterDirect<SuperNavigationViewItem, IImage>(
                nameof(Icon),
                o => o.Icon,
                (o, v) => o.Icon = v);

        private object _title = "Title";
        public object Title
        {
            get => _title;
            set => SetAndRaise(TitleProperty, ref _title, value);
        }
        public static readonly DirectProperty<SuperNavigationViewItem, object> TitleProperty =
            AvaloniaProperty.RegisterDirect<SuperNavigationViewItem, object>(
                nameof(Title),
                o => o.Title,
                (o, v) => o.Title = v);
    }
}
