using Aura.UI.Attributes;
using Aura.UI.Collections;
using Aura.UI.Controls.Primitives;
using Aura.UI.Events;
using Aura.UI.Exceptions;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace Aura.UI.Controls
{
    [InDeveloping]
    [DonotUse]
    [TemplatePart(Name ="PART_Root", Type = typeof(Grid))]
    public class MultiSlider : ClickableSelectingItemsControl, IMinMaxValue
    { 
       
        Grid Root;
        public MultiSlider() : base()
        {
            this.InitializeComponent();
            PseudoClasses.Set(":vertical", Orientation is Orientation.Vertical);
            PseudoClasses.Set(":horizontal", Orientation is Orientation.Horizontal);
            var sl1 = new MultiSliderItem();
            var sl2 = new MultiSliderItem();

            ArrangeSliders();
        }

        internal void ArrangeSliders()
        {
            foreach(MultiSliderItem item in (Items as IList))
            {
                item.Minimum = this.MinimumValue;
                item.Maximum = this.MaximumValue;
            }
        }
        internal void UpdateValues()
        {
            foreach (MultiSliderItem item in (Items as IList))
            {
                if(this.MinimumValue < item.Value & item.Value < this.MaximumValue)
                {
                    Values[(Items as IList).IndexOf(item)] = item.Value;
                }
            }
        }

        protected override void OnClick()
        {
            base.OnClick();
           
            CreateSlider();
        }

        public void CreateSlider()
        {
            var slc = new MultiSliderItem();
            (Items as IList).Add(slc);
            ArrangeSliders();
            UpdateValues();
        }
        public double[] Values
        {
            get;
            set;
        }
        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            base.OnTemplateApplied(e);
            Root = this.GetControl<Grid>(e, "Root");
        }
        public double MinimumValue 
        {
            get { return GetValue(MinimumValueProperty); }
            set { SetValue(MinimumValueProperty, value); }
        }
        public static readonly StyledProperty<double> MinimumValueProperty =
            AvaloniaProperty.Register<MultiSlider, double>(nameof(MinimumValue), 0);
        public double MaximumValue
        {
            get { return GetValue(MaximumValueProperty); }
            set { SetValue(MaximumValueProperty, value); }
        }
        public static readonly StyledProperty<double> MaximumValueProperty =
            AvaloniaProperty.Register<MultiSlider, double>(nameof(MaximumValue), 100);
        public Orientation Orientation
        {
            get { return GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
        public static readonly StyledProperty<Orientation> OrientationProperty =
            AvaloniaProperty.Register<MultiSlider, Orientation>(nameof(Orientation), Orientation.Horizontal);
        
        public new AvaloniaList<MultiSliderItem> Items
        {
            get { return GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public new static readonly StyledProperty<AvaloniaList<MultiSliderItem>> ItemsProperty =
            AvaloniaProperty.Register<MultiSlider, AvaloniaList<MultiSliderItem>>(nameof(Items));
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            ArrangeSliders();
            UpdateValues();
        }
    }
}
