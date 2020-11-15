using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Input;

namespace Aura.UI.Controls
{
    public partial class ControlDesigner : TemplatedControl
    {
        public ControlDesigner()
        {
            PseudoClasses.Add(":none");
        }
        

        private ResizeDecorator dec;
        
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            dec = this.GetControl<ResizeDecorator>(e, "PART_resize");
            
            PropertyChanged += OnPropertyChanged_;
        }

        private void OnPropertyChanged_(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (ControlToDesign != null)
            {
                dec.DataContext = ControlToDesign;
            }
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            switch (EditMode)
            {
                case EditMode.None:
                    EditMode = EditMode.Resize;
                    break;
                case EditMode.Resize:
                    EditMode = EditMode.Rotate;
                    break;
                case EditMode.Rotate:
                    EditMode = EditMode.None;
                    break;
            }
        }
        
    }
}