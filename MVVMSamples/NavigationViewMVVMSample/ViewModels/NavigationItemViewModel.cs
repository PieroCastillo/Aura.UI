using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationViewMVVMSample.ViewModels
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private ObservableCollection<NavigationItemViewModel> _navigationItems;



        public ObservableCollection<NavigationItemViewModel> NavigationItems 
        {
            get => _navigationItems;
            set => this.RaiseAndSetIfChanged(ref _navigationItems, value);
        }
    }
}
