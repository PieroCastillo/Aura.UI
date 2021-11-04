using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AuraTabViewMVVMSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<TabItemVM> tabs;

        public MainWindowViewModel()
        {
            Tabs = new();
            Tabs.Add(new() { Header = "Header 1", Content = "Content 1" });
            Tabs.Add(new() { Header = "Header 2", Content = "Content 2" });
            Tabs.Add(new() { Header = "Header 3", Content = "Content 3" });
            Tabs.Add(new() { Header = "Header 4", Content = "Content 4" });
        }

        public ObservableCollection<TabItemVM> Tabs
        {
            get => tabs;
            set => this.RaiseAndSetIfChanged(ref tabs, value);
        }
    }
}
