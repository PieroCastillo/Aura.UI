using Aura.UI.Attributes;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Shapes;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Platform;
using DynamicData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ThemeEditor.Controls.ColorPicker;
using Aura.UI.UIExtensions;
using MessageBox.Avalonia;
using MessageBox.Avalonia.DTO;

namespace Aura.UI.Controls
{
    [InDeveloping]
    [DonotUse(Reason = "For now this control does not work as I want")]
    public class GradientEditor : UserControl, ICloneable
    {
        Rectangle rect1;
        Rectangle rect2;
        Button AddStopButton;
        Button DeleteStopButton;
        Slider OffsetSlider;
        ColorPicker Picker;
        ComboBox ComboList;
        Grid ParentContainer;
        public GradientEditor()  
        {
            this.InitializeComponent();
            this.Gradients = new AvaloniaList<GradientStop>();

            #region Declare Components
            rect1 = this.Find<Rectangle>("rect_1_bg_");
            rect2 = this.Find<Rectangle>("rect_2_bg_");
            ComboList = this.Find<ComboBox>("combo_");
            AddStopButton = this.Find<Button>("add_stop_");
            DeleteStopButton = this.Find<Button>("delete_stop_");
            OffsetSlider = this.Find<Slider>("offset_value_");
            Picker = this.Find<ColorPicker>("cp_");
            ParentContainer = this.Find<Grid>("container");

            #endregion
            #region Events
            AddStopButton.Click += AddStopButton_Click;
            DeleteStopButton.Click += DeleteStopButton_Click;
            #endregion

            Gradients.Add(new GradientStop(Colors.White, 0));
            Gradients.Add(new GradientStop(Colors.Black, 1));

        }

        private void DeleteStopButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (ComboList.SelectedItem != null & Gradients.Count() > 2)
            {
                Gradients.Remove(Gradients[ComboList.SelectedIndex]);
                (ComboList.Items as IList).Remove(ComboList.SelectedItem);
                UpdateGradient();
            }
            else
            {
                var msgbox = MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams()
                {
                    ContentTitle = "Gradient Editor",
                    ContentHeader = "Alert!",
                    ContentMessage =  "There aren't a Gradient selected or \n There can be no less than 2 Gradient Stops",
                    CanResize = false,
                    ShowInCenter = true,
                    Style = MessageBox.Avalonia.Enums.Style.RoundButtons,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                });
                msgbox.ShowDialog(this.GetParentWindowOfLogical());
            }
        }

        private void AddStopButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var color = Picker.Color;
            var stop = new GradientStop() { Color = color };           
           // ComboList.SelectedItem = new ComboBoxItem() { Content = color.ToString() };
            SelectedStop = stop;
            Gradients.Add(stop);
            UpdateGradient();                        
        }

        internal void UpdateGradient()
        {
            rect1.Fill = null;
            rect2.Fill = null;

            (ComboList.Items as IList).Clear();

            var g_list = Gradients;

            
            
            var g1 = new LinearGradientBrush()
            {
                StartPoint = new RelativePoint(new Point(0.0,0.5), RelativeUnit.Relative),
                EndPoint = new RelativePoint(new Point(1,0.5), RelativeUnit.Relative)
            };
            g1.GradientStops.AddRange(Gradients);

            var g2 = new LinearGradientBrush()
            {
                StartPoint = new RelativePoint(new Point(0.0, 0.5), RelativeUnit.Relative),
                EndPoint = new RelativePoint(new Point(1, 0.5), RelativeUnit.Relative)
            };
            g2.GradientStops.AddRange(Gradients);

            rect1.Fill = g2;
            rect2.Fill = g1;

            SelectedGradient = g1;
                
        }

        public IGradientBrush GetGeneratedGradient()
        {
            return SelectedGradient;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public IGradientBrush SelectedGradient
        {
            get { return GetValue(SelectedGradientBrush); }
            set { SetValue(SelectedGradientBrush, value); }
        }
        public static readonly StyledProperty<IGradientBrush> SelectedGradientBrush =
            AvaloniaProperty.Register<GradientEditor, IGradientBrush>(nameof(SelectedGradient));
        public GradientStop SelectedStop
        {
            get;set;
        }
        public IList<GradientStop> Gradients
        {
            get;set;
        }
        public int OffSet { get; set; }
    }
}
