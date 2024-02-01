using System.Collections.Generic;
using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;

namespace Aura.UI.Gallery.ViewModels
{
    public class ReactiveAuraTabViewPage : ViewModelBase
    {
        public ReactiveAuraTabViewPage()
        {
            ItemsSource = new List<AuraTabViewViewModel>()
            {
                new AuraTabViewViewModel()
                {
                    Content = "Dynamic Content",
                    Header = "Tab 1"
                },
                new AuraTabViewViewModel()
                {

                },
                new AuraTabViewViewModel()
                {

                },
                new AuraTabViewViewModel()
                {

                }
            };
        }
        public IList<AuraTabViewViewModel> ItemsSource { get; }
    }

    public class AuraTabViewViewModel
    {
        public object Content { get; set; }

        public object Header { get; set; }

        public bool IsClosable { get; set; }

        public IImage Icon { get; set; }
    }
}