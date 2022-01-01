using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.UI.Gallery.ViewModels
{
    public class ProgressRingPageViewModel : ViewModelBase
    {
        private string _minimum = 0.ToString();
        private string _maximum = 100.ToString();
        private double _currentValue;
        private bool _running;

        public string Minimum
        {
            get => _minimum;
            set => this.RaiseAndSetIfChanged(ref _minimum, value);
        }
        public string Maximum
        {
            get => _maximum;
            set => this.RaiseAndSetIfChanged(ref _maximum, value);
        }

        public double CurrentValue
        {
            get => _currentValue;
            set => this.RaiseAndSetIfChanged(ref _currentValue, value);
        }

        public bool IsRunning
        {
            get => _running;
            set => this.RaiseAndSetIfChanged(ref _running, value);
        }
    }
}
