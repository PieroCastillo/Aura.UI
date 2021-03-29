using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.UI.Gallery.ViewModels
{
    public class ModernSliderPageViewModel : ViewModelBase
    {
        public double _horizontalValue;
        public double _verticalValue;

        public double HorizontalValue
        {
            get => _horizontalValue;
            set => this.RaiseAndSetIfChanged(ref _horizontalValue, value);
        }

        public double VerticalValue
        {
            get => _verticalValue;
            set => this.RaiseAndSetIfChanged(ref _verticalValue, value);
        }
    }
}
