using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.UI.Gallery.ViewModels
{
    public class BlurImagePageViewModel : ViewModelBase
    {
        private float _blurvalue;
        public float BlurValue
        {
            get => _blurvalue;
            set => this.RaiseAndSetIfChanged(ref _blurvalue, value);
        }
    }
}
