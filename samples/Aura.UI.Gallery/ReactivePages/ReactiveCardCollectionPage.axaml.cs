using System.Threading.Tasks;
using Aura.UI.Gallery.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace Aura.UI.Gallery.ReactivePages
{
    public partial class ReactiveCardCollectionPage : UserControl// ReactiveUserControl<ReactiveCardCollectionPageViewModel>
    {
        public ReactiveCardCollectionPage()
        {
            InitializeComponent();
            
        }

        // private async Task ShowDialog(InteractionContext<CardControlViewModel, object> vm)
        // {
        //     
        // }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}