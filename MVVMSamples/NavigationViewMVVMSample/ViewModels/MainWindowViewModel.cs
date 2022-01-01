using Aura.UI.Data;
using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NavigationViewMVVMSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<INavigationViewItemTemplate> _navigationViewsItems;

        public MainWindowViewModel()
        {
            Items = new();
            Items.Add(new NavItem("content 1", "header 1", "title 1")
                .Add(new NavItem("content 10", "header 10", "title 10"))
                .Add(new NavItem("content 11", "header 11", "title 11"))
                .Add(new NavItem("content 12", "header 12", "title 12"))
                .Add(new NavItem("content 13", "header 13", "title 13"))
                .Add(new NavItem("content 14", "header 14", "title 14")));


            Items.Add(new NavItem("content 2", "header 2", "title 2")
                .Add(new NavItem("content 20", "header 20", "title 20"))
                .Add(new NavItem("content 21", "header 21", "title 21"))
                .Add(new NavItem("content 22", "header 22", "title 22"))
                .Add(new NavItem("content 23", "header 23", "title 23"))
                .Add(new NavItem("content 24", "header 24", "title 24")));

            Items.Add(new NavItem("content 3", "header 13", "title 3")
                .Add(new NavItem("content 30", "header 30", "title 30"))
                .Add(new NavItem("content 31", "header 31", "title 31"))
                .Add(new NavItem("content 32", "header 32", "title 32"))
                .Add(new NavItem("content 33", "header 33", "title 33"))
                .Add(new NavItem("content 34", "header 34", "title 34")));

            Items.Add(new NavItem("content 4", "header 4", "title 4")
                .Add(new NavItem("content 40", "header 40", "title 40"))
                .Add(new NavItem("content 41", "header 41", "title 41"))
                .Add(new NavItem("content 42", "header 42", "title 42"))
                .Add(new NavItem("content 43", "header 43", "title 43"))
                .Add(new NavItem("content 44", "header 44", "title 44")));
        }

        public ObservableCollection<INavigationViewItemTemplate> Items
        {
            get => _navigationViewsItems;
            set => this.RaiseAndSetIfChanged(ref _navigationViewsItems, value);
        }
    }

    public class NavItem : INavigationViewItemTemplate
    {
        public NavItem(object content, object header, object title)
        {
            Content = content;
            Header = header;
            Title = title;
            Items = new ObservableCollection<INavigationViewItemTemplate>();
        }

        public NavItem Add(NavItem item)
        {
            Items.Add(item);
            return this;
        }

        public IImage? Icon => null;

        public object Content { get; set; }

        public object Header { get; set; }

        public object Title { get; set; }

        public IList<INavigationViewItemTemplate> Items { get; set; }
    }
}
