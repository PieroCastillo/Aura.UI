using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

#nullable enable

namespace Aura.UI.Controls.Primitives
{
    public class WindowButtons : TemplatedControl
    {
        public Button? LeftButton { get; private set; }
        public Button? CenterButton { get; private set; }
        public Button? RightButton { get; private set; }

        private Window? _hostwindow;
        public Window? HostWindow
        {
            get => _hostwindow;
            set => SetAndRaise(HostWindowProperty, ref _hostwindow, value);
        }
        public readonly static DirectProperty<WindowButtons, Window?> HostWindowProperty =
            AvaloniaProperty.RegisterDirect<WindowButtons, Window?>(nameof(HostWindow), o => o.HostWindow, (o, v) => o.HostWindow = v);

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            LeftButton = this.GetControl<Button>(e, "PART_LeftButton");
            CenterButton = this.GetControl<Button>(e, "PART_CenterButton");
            RightButton = this.GetControl<Button>(e, "PART_RightButton");

            if(LeftButton is null || CenterButton is null || RightButton is null)
            {
                throw new System.Exception("Not all buttons are found");
            }
            
            LeftButton.PointerReleased += delegate
            {
                if (HostWindow is not null)
                {
                    HostWindow.WindowState = WindowState.Minimized;
                }
            };
            CenterButton.PointerReleased += delegate
            {
                if (HostWindow is not null)
                {
                    switch (HostWindow.WindowState)
                    {
                        case WindowState.Maximized:
                            HostWindow.WindowState = WindowState.Normal;
                            break;
                        case WindowState.Normal:
                            HostWindow.WindowState = WindowState.Maximized;
                            break;
                        case WindowState.FullScreen:
                            HostWindow.WindowState = WindowState.Maximized;
                            break;
                    }
                }
            };
            RightButton.PointerReleased += delegate
            {
                if (HostWindow is not null)
                {
                    HostWindow.Close();
                }
            };
        }
    }

    public enum WindowButtonsAlignment
    {
        Left, Right
    }
}
