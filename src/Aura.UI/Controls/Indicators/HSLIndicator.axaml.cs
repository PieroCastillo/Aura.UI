using Aura.UI.Attributes;
using Aura.UI.Helpers;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace Aura.UI.Controls.Indicators
{
    [TemplatePart(Name = "PART_HText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_SText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_LText", Type = typeof(TextBlock))]
    public class HSLIndicator : TemplatedControl
    {
        TextBlock H_;
        TextBlock S_;
        TextBlock L_;
        public HSLIndicator()
        {
            this.InitializeComponent();
        }

        public Color ColorToShow
        {
            get { return GetValue(ColorToShowProperty); }
            set { SetValue(ColorToShowProperty, value); }
        }
        public static readonly StyledProperty<Color> ColorToShowProperty =
            AvaloniaProperty.Register<HSLIndicator, Color>(nameof(ColorToShow), Colors.White);

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            this.H_ = this.GetControl<TextBlock>(e, "PART_HText");
            this.S_ = this.GetControl<TextBlock>(e, "PART_SText");
            this.L_ = this.GetControl<TextBlock>(e, "PART_LText");
            this.PropertyChanged += HSLIndicator_PropertyChanged;
        }

        private void HSLIndicator_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            this.UpdateHSL(new HSLStruct(ColorToShow));
        }

        internal void UpdateHSL(HSLStruct @struct)
        {
            this.H_.Text = @struct.hue.ToString();
            this.S_.Text = ((@struct.saturation / 1) * 100).ToString() + "%";
            this.L_.Text = ((@struct.lightness / 1) * 100).ToString() + "%";
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
