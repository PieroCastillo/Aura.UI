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
        ObservableCollection<TabItemVM> tabs2;

        public MainWindowViewModel()
        {
            Tabs = new();
            Tabs.Add(new() { Header = "Header 1", Content = "Content 1" });
            Tabs.Add(new() { Header = "Header 2", Content = "Content 2" });
            Tabs.Add(new() { Header = "Header 3", Content = "Content 3" });
            Tabs.Add(new() { Header = "Header 4", Content = "Content 4" });

            Tabs2 = new();
            Tabs2.Add(new() { Header = "Student 1", Content = new Student { Name = "Jessica Ramírez", Age = 25 } });
            Tabs2.Add(new() { Header = "Student 2", Content = new Student { Name = "Carlos Villareal Faz", Age = 24 } });
            Tabs2.Add(new() { Header = "Student 3", Content = new Student { Name = "Luis Pimentel", Age = 23 } });
            Tabs2.Add(new() { Header = "Student 4", Content = new Student { Name = "Dary González Viornery", Age = 26 } });
        }

        public ObservableCollection<TabItemVM> Tabs
        {
            get => tabs;
            set => this.RaiseAndSetIfChanged(ref tabs, value);
        }
        public ObservableCollection<TabItemVM> Tabs2
        {
            get => tabs2;
            set => this.RaiseAndSetIfChanged(ref tabs2, value);
        }
    }

    public class Student : ViewModelBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
