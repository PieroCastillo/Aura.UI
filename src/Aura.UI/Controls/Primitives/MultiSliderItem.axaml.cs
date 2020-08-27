using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Aura.UI.Controls.Primitives
{
    public class MultiSliderItem : Slider, INotifyPropertyChanged, ISelectable
    {
        #region Properties
        public double LeftValue
        {
            get { return (double)GetValue(LeftValueProperty); }
            set { SetValue(LeftValueProperty, value); }
        }
        public static readonly StyledProperty<double> LeftValueProperty =
            AvaloniaProperty.Register<MultiSliderItem, double>(nameof(LeftValue), double.MinValue); //LeftValueChanged
        public double RightValue
        {
            get { return (double)GetValue(RightValueProperty); }
            set { SetValue(RightValueProperty, value); }
        }
        public static readonly StyledProperty<double> RightValueProperty =
            AvaloniaProperty.Register<MultiSliderItem, double>(nameof(RightValue), double.MaxValue);
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set
            {
                SetValue(IsSelectedProperty, value);
                this.FirePropertyChanged();
            }
        }
        public static readonly StyledProperty<bool> IsSelectedProperty =
            AvaloniaProperty.Register<MultiSliderItem, bool>(nameof(IsSelected), false);

        #region Events
        public event EventHandler<RoutedEventArgs> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }
        public static readonly RoutedEvent<RoutedEventArgs> ValueChangedEvent =
            RoutedEvent.Register<MultiSliderItem, RoutedEventArgs>(nameof(ValueChanged), RoutingStrategies.Bubble);
        #endregion
        public bool IsFirst { get; set; }

        public bool IsLast { get; set; }

        private static void LeftValueChanged(AvaloniaObject d, AvaloniaPropertyChangedEventArgs e)
        {
            var sliderItem = d as MultiSliderItem;

            sliderItem.Value = (double)e.NewValue;

        }

        private static void MaximumValueChanged(AvaloniaObject d, AvaloniaPropertyChangedEventArgs e)
        {
            var sliderItem = d as MultiSliderItem;

            sliderItem.RightValue = (double)e.NewValue;

        }

        #endregion

        public MultiSliderItem()
        {
            InitializeComponent();
            IsFirst = false;
            IsLast = false;

            Maximum = double.MaxValue;
            Minimum = double.MinValue;
        }
        internal void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }        
    }
}
