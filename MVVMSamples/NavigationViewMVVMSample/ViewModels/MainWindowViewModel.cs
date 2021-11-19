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
        private int _selectedIndex;

        public MainWindowViewModel()
        {
            Items = new();
            
        }

        public ObservableCollection<INavigationViewItemTemplate> Items 
        {
            get => _navigationViewsItems;
            set => this.RaiseAndSetIfChanged(ref _navigationViewsItems, value);
        }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set => this.RaiseAndSetIfChanged(ref _selectedIndex, value);
        }
    }

    public class NavItem : INavigationViewItemTemplate
    {
        public NavItem(object content, object header, object title)
        {
            Content = content;
            Header = header;
            Title = title;
            Items = new ObservableCollection<NavItem>();
        }

        public void Add(NavItem item) => (Items as IList<INavigationViewItemTemplate>).Add(item);

        public IImage Icon => null;

        public object Content { get; set; }

        public object Header { get; set;}

        public object Title { get; set; }

        public IEnumerable<INavigationViewItemTemplate> Items { get; set; }
    }
}
