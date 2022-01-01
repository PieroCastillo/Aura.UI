using System.Collections.Generic;
using Aura.UI.Data;
using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;

namespace Aura.UI.Gallery.ViewModels
{
    public class ReactiveAuraTabViewPage : ViewModelBase
    {
        public ReactiveAuraTabViewPage()
        {
            var assetLoader = AvaloniaLocator.CurrentMutable.GetService<IAssetLoader>();

            ItemsSource = new List<IAuraTabItemTemplate>()
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
        public IList<IAuraTabItemTemplate> ItemsSource { get; }
    }

    public class AuraTabViewViewModel : IAuraTabItemTemplate
    {
        public object Content { get; set; }

        public object Header { get; set; }

        public bool IsClosable { get; set; }

        public IImage Icon { get; set; }
    }
}