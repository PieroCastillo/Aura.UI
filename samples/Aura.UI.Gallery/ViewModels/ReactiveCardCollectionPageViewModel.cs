using System;
using System.Collections.Generic;
using System.Reactive;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;

namespace Aura.UI.Gallery.ViewModels
{
    public class ReactiveCardCollectionPageViewModel : ViewModelBase
    {
        public ReactiveCardCollectionPageViewModel()
        {
            CardCollectionItems = new List<CardControlViewModel>()
            {
                new CardControlViewModel()
                {
                    Header = "20000",
                    SecondaryHeader = "Colbreakz",
                    Content = new Border()
                    {
                        Child = new Image
                        {
                            Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Aura.UI.Gallery/Assets/20000.jpg")))
                        }
                    },
                    Command = ReactiveCommand.Create<object,Unit>(Do),
                    CommandParameter = "hello"
                },
                new CardControlViewModel()
                {
                    Header = "Summer Ashes VIP",
                    SecondaryHeader = "KDrew",
                    Content = new Border()
                    {
                        Child = new Image
                        {
                            Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Aura.UI.Gallery/Assets/summershesvip.jpg")))
                        }
                    },
                    Command = ReactiveCommand.Create<object,Unit>(Do),
                    CommandParameter = "hello"
                },
                new CardControlViewModel()
                {
                    Header = "Virus",
                    SecondaryHeader = "Martin Garrix",
                    Content = new Border()
                    {
                        Child = new Image
                        {
                            Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Aura.UI.Gallery/Assets/virus.jpg")))
                        }
                    },
                    Command = ReactiveCommand.Create<object,Unit>(Do),
                    CommandParameter = "hello"
                },
                new CardControlViewModel()
                {
                    Header = "Greenlights",
                    SecondaryHeader = "Krewella",
                    Content = new Border()
                    {
                        Child = new Image
                        {
                            Source = new Bitmap(AssetLoader.Open(new Uri($"avares://Aura.UI.Gallery/Assets/greenlights.jpg")))
                        }
                    },
                    Command = ReactiveCommand.Create<object,Unit>(Do),
                    CommandParameter = "hello"
                }
            };
        }

        public Unit Do(object s)
        {
            return new Unit();
        }

        private IList<CardControlViewModel> _cardCollectionItems;

        public IList<CardControlViewModel> CardCollectionItems
        {
            get => _cardCollectionItems;
            set => this.RaiseAndSetIfChanged(ref _cardCollectionItems, value);
        }
    }
}