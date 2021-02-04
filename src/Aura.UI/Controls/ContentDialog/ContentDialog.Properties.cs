using Avalonia;

namespace Aura.UI.Controls
{
    public partial class ContentDialog
    {
        public object OkButtonContent
        {
            get => GetValue(OkButtonContentProperty);
            set => SetValue(OkButtonContentProperty, value);
        }

        public readonly static StyledProperty<object> OkButtonContentProperty =
            AvaloniaProperty.Register<ContentDialog, object>(nameof(OkButtonContent), "Ok");

        public object CancelButtonContent
        {
            get => GetValue(CancelButtonContentProperty);
            set => SetValue(CancelButtonContentProperty, value);
        }

        public readonly static StyledProperty<object> CancelButtonContentProperty =
            AvaloniaProperty.Register<ContentDialog, object>(nameof(CancelButtonContent), "Cancel");
    }
}