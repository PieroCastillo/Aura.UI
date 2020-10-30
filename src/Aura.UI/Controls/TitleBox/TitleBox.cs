using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Aura.UI.UIExtensions;
using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Avalonia.Interactivity;

namespace Aura.UI.Controls
{
    /// <summary>
    /// It's similar to <see cref="GroupBox"/>, but has a Two button on the TopRight
    /// </summary>
    [TemplatePart(Name = "PART_B1", Type = typeof(Button))]
    [TemplatePart(Name = "PART_B2", Type = typeof(Button))]
    public partial class TitleBox : HeaderedContentControl, ICustomCornerRadius
    {
        Button B1;
        Button B2;

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            B1 = this.GetControl<Button>(e, "PART_B1");
            B2 = this.GetControl<Button>(e, "PART_B2");
            B1.Click += B1_Click;
            B2.Click += B2_Click;
        }

        protected void B2_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var _e = new RoutedEventArgs(SecondaryButtonClickEvent);
            RaiseEvent(_e);
            _e.Handled = true;

            this.OnClickInButton2();
        }

        protected void B1_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.OnClickInButton1();

            var _e = new RoutedEventArgs(MainButtonClickEvent);
            RaiseEvent(_e);
            _e.Handled = true;
        }

        /// <summary>
        /// Do something when the first button is clicked
        /// </summary>
        public virtual void OnClickInButton1() { }
        /// <summary>
        /// Do something when the second button is clicked
        /// </summary>
        public virtual void OnClickInButton2() { }
    }
}
