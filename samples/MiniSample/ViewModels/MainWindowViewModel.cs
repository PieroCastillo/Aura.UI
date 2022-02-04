using Avalonia.Media;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            this.WhenPropertyChanged(x => x.R).Subscribe(x =>
            {
                BackgroundColor = Color.FromRgb((byte)R, (byte)G, (byte)B);
            });


            this.WhenPropertyChanged(x => x.G).Subscribe(x =>
            {
                BackgroundColor = Color.FromRgb((byte)R, (byte)G, (byte)B);
            });


            this.WhenPropertyChanged(x => x.B).Subscribe(x =>
            {
                BackgroundColor = Color.FromRgb((byte)R, (byte)G, (byte)B);
            });
        }

        private Color _BackgroundColor = Color.Parse("#FFe0e0e0");
        private double _Radius = 60;
        private double _Distance = 20;
        private double _Intensity = 0.15;
        private double _Blur = 60;
        private double _R = 0xe0;
        private double _G = 0xe0;
        private double _B = 0xe0;

        public Color BackgroundColor
        {
            get => _BackgroundColor;
            set => this.RaiseAndSetIfChanged(ref _BackgroundColor, value);
        }

        public double Radius
        {
            get => _Radius;
            set => this.RaiseAndSetIfChanged(ref _Radius, value);
        }

        public double Distance
        {
            get => _Distance;
            set => this.RaiseAndSetIfChanged(ref _Distance, value);
        }

        public double Intensity
        {
            get => _Intensity;
            set => this.RaiseAndSetIfChanged(ref _Intensity, value);
        }

        public double Blur
        {
            get => _Blur;
            set => this.RaiseAndSetIfChanged(ref _Blur, value);
        }

        public double R
        {
            get => _R;
            set => this.RaiseAndSetIfChanged(ref _R, value);
        }

        public double G
        {
            get => _G;
            set => this.RaiseAndSetIfChanged(ref _G, value);
        }

        public double B
        {
            get => _B;
            set => this.RaiseAndSetIfChanged(ref _B, value);
        }
    }
}
